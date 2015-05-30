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

using MonoTouch.Dialog;
using UIKit;
using CoreGraphics;

namespace FloatLabeledEntry
{
	public class FloatLabeledEntryElement : EntryElement
	{
		private readonly FloatLabeledTextField _textField;

		public FloatLabeledEntryElement(string placeholder, string value = null, string caption = null, bool isPassword = false)
			: base(caption, placeholder, value, isPassword)
		{
			_textField = new FloatLabeledTextField(CGRect.Empty)
			{
				AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleLeftMargin,
				Placeholder = placeholder,
				Text = value,
				SecureTextEntry = isPassword
			};
		}

		public UIColor FloatingLabelTextColor
		{ 
			get { return _textField.FloatingLabelTextColor; }
			set { _textField.FloatingLabelTextColor = value; }
		}

		public UIColor FloatingLabelActiveTextColor
		{
			get { return _textField.FloatingLabelActiveTextColor; }
			set { _textField.FloatingLabelActiveTextColor = value; }
		}

		public UIFont FloatingLabelFont
		{
			get { return _textField.FloatingLabelFont; }
			set { _textField.FloatingLabelFont = value; }
		}

		protected override UITextField CreateTextField(CGRect frame)
		{
			_textField.Frame = frame;

			return _textField;
		}

		public override UITableViewCell GetCell(UITableView tv)
		{
			var cell = base.GetCell(tv);

			_textField.Frame = new CGRect(_textField.Frame.X, 0, _textField.Frame.Width, cell.Frame.Height);

			return cell;
		}
	}
}