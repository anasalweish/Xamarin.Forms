using Android.Content.Res;
using Android.Graphics;
using Android.Util;
using AndroidX.AppCompat.Widget;
using Xamarin.Forms;
using AView = Android.Views.View;
using XColor = Xamarin.Forms.Color;

namespace Xamarin.Platform
{
	public static class ButtonExtensions
	{
		static bool ColorButtonNormalSet;
		static XColor ColorButtonNormal = XColor.Default;

		static float DefaultFontSize;
		static Typeface? DefaultTypeface;

		public static void UpdateColor(this AppCompatButton button, XColor color, ColorStateList? defaultColor)
		{
			if (color.IsDefault)
				button.SetTextColor(defaultColor);
			else
				button.SetTextColor(color.ToNative());
		}

		public static void UpdateColor(this AppCompatButton appCompatButton, IButton button) =>
			appCompatButton.UpdateColor(button.Color, appCompatButton.TextColors);

		public static void UpdateColor(this AppCompatButton appCompatButton, IButton button, XColor defaultColor) =>
			appCompatButton.SetTextColor(button.Color.Cleanse(defaultColor).ToNative());

		public static void UpdateText(this AppCompatButton appCompatButton, IButton button) =>
			appCompatButton.Text = button.Text;

		public static void UpdateFont(this AppCompatButton appCompatButton, IButton button)
		{
			Font font = button.Font;

			if (font == Font.Default && DefaultFontSize == 0f)
			{
				return;
			}

			if (DefaultFontSize == 0f)
			{
				DefaultTypeface = appCompatButton.Typeface;
				DefaultFontSize = appCompatButton.TextSize;
			}

			if (font == Font.Default)
			{
				appCompatButton.Typeface = DefaultTypeface;
				appCompatButton.SetTextSize(ComplexUnitType.Px, DefaultFontSize);
			}
			else
			{
				appCompatButton.Typeface = font.ToTypeface();
				appCompatButton.SetTextSize(ComplexUnitType.Sp, font.ToScaledPixel());
			}
		}

		public static void UpdateCharacterSpacing(this AppCompatButton appCompatButton, IButton button)
		{
			if (NativeVersion.IsAtLeast(21))
			{
				appCompatButton.LetterSpacing = button.CharacterSpacing.ToEm();
			}
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

		public static XColor GetColorButtonNormal(this AView appCompatButton)
		{
			if (!ColorButtonNormalSet)
			{
				ColorButtonNormal = appCompatButton.GetButtonColor();
				ColorButtonNormalSet = true;
			}

			return ColorButtonNormal;
		}

		static XColor GetButtonColor(this AView appCompatButton)
		{
			XColor rc = XColor.Default;

			if (appCompatButton == null || appCompatButton.Context == null)
				return rc;

			using (var value = new TypedValue())
			{
				if (appCompatButton.Context.Theme != null)
				{
					int? colorButtonNormal = appCompatButton.Context.Resources?.GetIdentifier("colorButtonNormal", "attr", appCompatButton.Context.PackageName);

					if (appCompatButton.Context.Theme.ResolveAttribute(global::Android.Resource.Attribute.ColorButtonNormal, value, true) && NativeVersion.IsAtLeast(21)) // Android 5.0+
					{
						rc = XColor.FromUint((uint)value.Data);
					}
					else if (colorButtonNormal.HasValue && appCompatButton.Context.Theme.ResolveAttribute(colorButtonNormal.Value, value, true))  // < Android 5.0
					{
						rc = XColor.FromUint((uint)value.Data);
					}
				}
			}

			return rc;
		}

		static XColor Cleanse(this XColor color, XColor defaultColor) => color.IsDefault ? defaultColor : color;
	}
}
