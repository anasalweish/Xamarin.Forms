﻿using Android.Content.Res;
using Android.Graphics.Drawables;
using Android.Views;
using Xamarin.Forms;
using System;

namespace Xamarin.Platform
{
	internal class BorderBackgroundManager : IDisposable
	{
		Drawable? _defaultDrawable;
		BorderDrawable? _backgroundDrawable;
		RippleDrawable? _rippleDrawable;
		bool _drawableEnabled;

		IViewHandler? _handler;
		IBorder? _border;
		readonly View? _nativeView;
		 
		readonly bool _drawOutlineWithBackground;

		public BorderBackgroundManager(IViewHandler handler, IBorder border) : this(handler, border, true)
		{
		}

		public BorderBackgroundManager(IViewHandler handler, IBorder border, bool drawOutlineWithBackground)
		{
			_handler = handler;
			_nativeView = _handler.NativeView as View;
			_border = border;
			_drawOutlineWithBackground = drawOutlineWithBackground;
		}

		public static Color ColorButtonNormalOverride { get; set; }

		public void UpdateDrawable()
		{
			if (_border == null || _handler == null)
				return;

			bool cornerRadiusIsDefault = _border.CornerRadius == BorderDrawable.DefaultCornerRadius;
			bool backgroundColorIsDefault = _border.BackgroundColor == Color.Default;
			bool borderColorIsDefault = _border.BorderColor == Color.Default;
			bool borderWidthIsDefault = _border.BorderWidth == 0.0d;

			if (backgroundColorIsDefault
				&& cornerRadiusIsDefault
				&& borderColorIsDefault
				&& borderWidthIsDefault)
			{
				if (!_drawableEnabled)
					return;

				if (_defaultDrawable != null)
					_nativeView?.SetBackground(_defaultDrawable);

				_drawableEnabled = false;
				Reset();
			}
			else
			{
				if (_nativeView != null && _backgroundDrawable == null)
					_backgroundDrawable = new BorderDrawable(_nativeView.Context!.ToPixels, _nativeView.GetColorButtonNormal(), _drawOutlineWithBackground);

				if (_backgroundDrawable != null)
					_backgroundDrawable.BorderElement = _border;

				if (_drawableEnabled)
					return;

				if (_defaultDrawable == null)
					_defaultDrawable = _nativeView?.Background;

				if (!backgroundColorIsDefault || _drawOutlineWithBackground)
				{
					if (NativeVersion.IsAtLeast(21))
					{
						var rippleColor = _backgroundDrawable?.PressedBackgroundColor.ToNative();

						if (rippleColor.HasValue)
						{
							_rippleDrawable = new RippleDrawable(ColorStateList.ValueOf(rippleColor.Value), _backgroundDrawable, null);
							_nativeView?.SetBackground(_rippleDrawable);
						}
					}
					else
					{
						if (_backgroundDrawable != null)
							_nativeView?.SetBackground(_backgroundDrawable);
					}
				}

				_drawableEnabled = true;
			}

			_nativeView?.Invalidate();
		}

		public void Reset()
		{
			if (_drawableEnabled)
			{
				_drawableEnabled = false;
				_backgroundDrawable?.Reset();
				_backgroundDrawable = null;
				_rippleDrawable = null;
			}
		}

		public void Dispose()
		{
			_backgroundDrawable?.Dispose();
			_backgroundDrawable = null;
			_defaultDrawable?.Dispose();
			_defaultDrawable = null;
			_rippleDrawable?.Dispose();
			_rippleDrawable = null;

			_border = null;
			_handler = null;
		}
	}
}