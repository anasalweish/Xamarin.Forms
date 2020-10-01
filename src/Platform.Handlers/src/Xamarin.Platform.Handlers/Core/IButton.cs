using Xamarin.Forms;

namespace Xamarin.Platform
{
	public interface IButton : IText, IBorder, IPadding
	{
		ButtonContentLayout ContentLayout { get; }

		void Pressed();
		void Released();
		void Clicked();
	}
}