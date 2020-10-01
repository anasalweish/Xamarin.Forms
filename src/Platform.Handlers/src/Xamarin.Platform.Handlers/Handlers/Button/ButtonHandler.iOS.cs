using UIKit;

namespace Xamarin.Platform.Handlers
{
    public partial class ButtonHandler : AbstractViewHandler<IButton, UIButton>
    {
        protected override UIButton CreateView() => new UIButton();
    }
}