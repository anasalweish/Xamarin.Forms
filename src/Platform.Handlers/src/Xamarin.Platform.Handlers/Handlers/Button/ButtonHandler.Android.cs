using AndroidX.AppCompat.Widget;
using Xamarin.Forms;

namespace Xamarin.Platform.Handlers
{
    public partial class ButtonHandler : AbstractViewHandler<IButton, AppCompatButton>
    {
        protected override AppCompatButton CreateView() => new AppCompatButton(Context);

		public override SizeRequest GetDesiredSize(double wConstraint, double hConstraint)
		{
			var hint = TypedNativeView?.Hint;
			bool setHint = TypedNativeView?.LayoutParameters != null;

			if (TypedNativeView != null && !string.IsNullOrWhiteSpace(hint) && setHint)
			{
				TypedNativeView.Hint = string.Empty;
			}

			int widthConstraint = wConstraint == double.MaxValue ? int.MaxValue : (int)wConstraint;
			int heightConstraint = hConstraint == double.MaxValue ? int.MaxValue : (int)hConstraint;

			TypedNativeView?.Measure(widthConstraint, heightConstraint);

			if (TypedNativeView != null && setHint)
				TypedNativeView.Hint = hint;

			var previousHeight = TypedNativeView?.MeasuredHeight;
			var previousWidth = TypedNativeView?.MeasuredWidth;

			if (View != null)
			{
				// If the measure of the view has changed then trigger a request for layout
				// If the measure hasn't changed then force a layout of the button
				if (previousHeight != View.MeasuredHeight || previousWidth != View.MeasuredWidth)
					View.RequestLayout();
				else
					View.ForceLayout();

				var result = new SizeRequest(new Size(View.MeasuredWidth, View.MeasuredHeight), Size.Zero);

				return result;
			}

			return base.GetDesiredSize(widthConstraint, heightConstraint);
		}
	}
}