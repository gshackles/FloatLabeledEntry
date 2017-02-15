//  The MIT License (MIT)
//
//  Copyright (c) 2015 Greg Shackles
//  Original implementation by Jared Verdi
//	https://github.com/jverdi/JVFloatLabeledTextField
//  Original Concept by Matt D. Smith
//  http://dribbble.com/shots/1254439--GIF-Mobile-Form-Interaction?list=users
//
//  Permission is hereby granted, free of charge, to any person obtaining a copy of
//  this software and associated documentation files (the "Software"), to deal in
//  the Software without restriction, including without limitation the rights to
//  use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
//  the Software, and to permit persons to whom the Software is furnished to do so,
//  subject to the following conditions:
//
//  The above copyright notice and this permission notice shall be included in all
//  copies or substantial portions of the Software.
//
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
//  FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
//  COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
//  IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
//  CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

using System;
using UIKit;
using CoreGraphics;
using Foundation;
using System.ComponentModel;

namespace FloatLabeledEntry
{
    [Register("FloatLabeledTextField"), DesignTimeVisible(true)]
	public class FloatLabeledTextField : UITextField 
	{
		private UILabel _floatingLabel;

        [DisplayName("Label Color"), Export("FloatingLabelTextColor"), Browsable(true)]
        public UIColor FloatingLabelTextColor { get; set; } = UIColor.Gray;

        [DisplayName("Label Active Color"), Export("FloatingLabelActiveTextColor"), Browsable(true)]
        public UIColor FloatingLabelActiveTextColor { get; set; } = UIColor.Blue;

        public UIFont FloatingLabelFont
        {
            get { return _floatingLabel.Font; }
            set { _floatingLabel.Font = value; }
        }

        public FloatLabeledTextField(CGRect frame)
            : base(frame)
        {
            InitializeLabel();
        }

        public FloatLabeledTextField(IntPtr handle)
            : base(handle)
        {
        }

        public override void AwakeFromNib() => InitializeLabel();

        private void InitializeLabel()
        {
            _floatingLabel = new UILabel
            {
                Alpha = 0.0f,
                Font = UIFont.BoldSystemFontOfSize(12)
            };

            AddSubview(_floatingLabel);

            Placeholder = Placeholder; // sets up label frame
        }

		public override string Placeholder 
		{
			get { return base.Placeholder; }
			set 
			{
				base.Placeholder = value;

				_floatingLabel.Text = value;
				_floatingLabel.SizeToFit();
				_floatingLabel.Frame = 
					new CGRect(
						0, _floatingLabel.Font.LineHeight, 
						_floatingLabel.Frame.Size.Width, _floatingLabel.Frame.Size.Height);
			}
		}

		public override CGRect TextRect(CGRect forBounds)
		{
			if (_floatingLabel == null)
				return base.TextRect(forBounds);

			return InsetRect(base.TextRect(forBounds), new UIEdgeInsets(_floatingLabel.Font.LineHeight, 0, 0, 0));
		}

		public override CGRect EditingRect(CGRect forBounds)
		{
			if (_floatingLabel == null)
				return base.EditingRect(forBounds);

			return InsetRect(base.EditingRect(forBounds), new UIEdgeInsets(_floatingLabel.Font.LineHeight, 0, 0, 0));
		}

		public override CGRect ClearButtonRect(CGRect forBounds)
		{
			var rect = base.ClearButtonRect(forBounds);

			if (_floatingLabel == null)
				return rect;

			return new CGRect(
				rect.X, rect.Y + _floatingLabel.Font.LineHeight / 2.0f, 
				rect.Size.Width, rect.Size.Height);
		}

		public override void LayoutSubviews()
		{
			base.LayoutSubviews();

			Action updateLabel = () =>
			{
				if (!string.IsNullOrEmpty(Text))
				{
					_floatingLabel.Alpha = 1.0f;
					_floatingLabel.Frame = 
						new CGRect(
							_floatingLabel.Frame.Location.X, 
							2.0f, 
							_floatingLabel.Frame.Size.Width, 
							_floatingLabel.Frame.Size.Height);
				}
				else
				{
					_floatingLabel.Alpha = 0.0f;
					_floatingLabel.Frame = 
						new CGRect(
							_floatingLabel.Frame.Location.X,
							_floatingLabel.Font.LineHeight,
							_floatingLabel.Frame.Size.Width,
							_floatingLabel.Frame.Size.Height);
				}
			};

			if (IsFirstResponder)
			{
                _floatingLabel.TextColor = FloatingLabelActiveTextColor;

                var shouldFloat = !string.IsNullOrEmpty(Text);
                var isFloating = _floatingLabel.Alpha == 1f;

                if (shouldFloat == isFloating)
                {
                    updateLabel();
                }
                else
                {
                    Animate(
                        0.3f, 0.0f, 
                        UIViewAnimationOptions.BeginFromCurrentState
                        | UIViewAnimationOptions.CurveEaseOut,
                        () => updateLabel(),
                        () => {});
                }
			}
			else
			{
				_floatingLabel.TextColor = FloatingLabelTextColor;

				updateLabel();
			}
		}

		private static CGRect InsetRect(CGRect rect, UIEdgeInsets insets) =>
			new CGRect(
    			rect.X + insets.Left, 
    			rect.Y + insets.Top, 
    			rect.Width - insets.Left - insets.Right, 
    			rect.Height - insets.Top - insets.Bottom);
	}
}