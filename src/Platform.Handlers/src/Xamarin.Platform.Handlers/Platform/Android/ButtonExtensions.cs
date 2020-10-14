using Android.Content.Res;
using AndroidX.AppCompat.Widget;
using Xamarin.Forms;

namespace Xamarin.Platform
{
	public static class ButtonExtensions
	{
		public static void UpdateColor(this AppCompatButton button, Color color, ColorStateList? defaultColor)
		{
			if (color.IsDefault)
				button.SetTextColor(defaultColor);
			else
				button.SetTextColor(color.ToNative());
		}

		public static void UpdateColor(this AppCompatButton appCompatButton, IButton button) =>
			appCompatButton.UpdateColor(button.Color, appCompatButton.TextColors);

		public static void UpdateColor(this AppCompatButton appCompatButton, IButton button, Color defaultColor) =>
			appCompatButton.SetTextColor(button.Color.Cleanse(defaultColor).ToNative());

		public static void UpdateText(this AppCompatButton appCompatButton, IButton button) =>
			appCompatButton.Text = button.Text;

		public static void UpdateFont(this AppCompatButton AppCompatButton, IButton button)
		{
		
		}

		public static void UpdateCharacterSpacing(this AppCompatButton appCompatButton, IButton button)
		{

		}

		public static void UpdateCornerRadius(this AppCompatButton appCompatButton, IButton button)
		{

		}

		public static void UpdateBorderColor(this AppCompatButton appCompatButton, IButton button)
		{

		}

		public static void UpdateBorderWidth(this AppCompatButton appCompatButton, IButton button)
		{

		}

		public static void UpdateContentLayout(this AppCompatButton appCompatButton, IButton button)
		{

		}

		public static void UpdatePadding(this AppCompatButton appCompatButton, IButton button)
		{

		}

		static Color Cleanse(this Color color, Color defaultColor) => color.IsDefault ? defaultColor : color;
	}
}
