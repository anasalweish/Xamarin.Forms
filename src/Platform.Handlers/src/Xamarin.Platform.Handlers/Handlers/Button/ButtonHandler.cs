namespace Xamarin.Platform.Handlers
{
	public partial class ButtonHandler 
	{
		public static PropertyMapper<IButton, ButtonHandler> ButtonMapper = new PropertyMapper<IButton, ButtonHandler>(ViewHandler.ViewMapper)
		{
			[nameof(IText.Text)] = MapText,
			[nameof(IText.Color)] = MapColor,
			[nameof(IText.Font)] = MapFont,
			[nameof(IText.CharacterSpacing)] = MapCharacterSpacing,
			[nameof(IBorder.CornerRadius)] = MapCornerRadius,
			[nameof(IBorder.BorderColor)] = MapBorderColor,
			[nameof(IBorder.BorderWidth)] = MapBorderWidth,
			[nameof(IFont.FontSize)] = MapFont,
			[nameof(IFont.FontAttributes)] = MapFont,
			[nameof(IButton.ContentLayout)] = MapContentLayout,
			[nameof(IPadding.Padding)] = MapPadding
		};

		public static void MapText(ButtonHandler handler, IButton button)
		{
			ViewHandler.CheckParameters(handler, button);
			handler.TypedNativeView?.UpdateText(button);
		}

		public static void MapColor(ButtonHandler handler, IButton button)
		{
			ViewHandler.CheckParameters(handler, button);
			handler.TypedNativeView?.UpdateColor(button);
		}

		public static void MapFont(ButtonHandler handler, IButton button)
		{
			ViewHandler.CheckParameters(handler, button);
			handler.TypedNativeView?.UpdateFont(button);
		}

		public static void MapCharacterSpacing(ButtonHandler handler, IButton button)
		{
			ViewHandler.CheckParameters(handler, button);
			handler.TypedNativeView?.UpdateCharacterSpacing(button);
		}

		public static void MapCornerRadius(ButtonHandler handler, IButton button)
		{
			ViewHandler.CheckParameters(handler, button);
			handler.TypedNativeView?.UpdateCornerRadius(button);
		}

		public static void MapBorderColor(ButtonHandler handler, IButton button)
		{
			ViewHandler.CheckParameters(handler, button);
			handler.TypedNativeView?.UpdateBorderColor(button);
		}

		public static void MapBorderWidth(ButtonHandler handler, IButton button)
		{
			ViewHandler.CheckParameters(handler, button);
			handler.TypedNativeView?.UpdateBorderWidth(button);
		}

		public static void MapContentLayout(ButtonHandler handler, IButton button)
		{
			ViewHandler.CheckParameters(handler, button);
			handler.TypedNativeView?.UpdateContentLayout(button);
		}

		public static void MapPadding(ButtonHandler handler, IButton button)
		{
			ViewHandler.CheckParameters(handler, button);
			handler.TypedNativeView?.UpdatePadding(button);
		}

		public ButtonHandler() : base(ButtonMapper)
		{

		}

		public ButtonHandler(PropertyMapper mapper) : base(mapper ?? ButtonMapper)
		{

		}
	}
}