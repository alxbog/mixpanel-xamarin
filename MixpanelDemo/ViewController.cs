using System;
using MixpanelLib;
using UIKit;

namespace MixpanelDemo
{
	public partial class ViewController : UIViewController
	{
		TweakBinding _boolBinding;
		TweakBinding _stringBinding;
		TweakBinding _colorBinding;
		TweakBinding _intBinding;
		TweakBinding _floatBinding;

		protected ViewController(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.

			var boolValue = AppTweaks.ShowLabel.GetValue();
			var intValue = AppTweaks.IntLabelValue.GetValue();
			var floatValue = AppTweaks.FloatLabelValue.GetValue();
			var stringValue = AppTweaks.LabelText.GetValue();

			Console.WriteLine($"{boolValue} - {intValue} - {floatValue} - {stringValue}");

			_boolBinding = AppTweaks.ShowLabel.Bind(b => helloLabel.Hidden = !b);
			_stringBinding = AppTweaks.LabelText.Bind(s => helloLabel.Text = s);
			_colorBinding = AppTweaks.LabelColor.Bind(c => helloLabel.TextColor = GetColorFromHEX(c));
			_intBinding = AppTweaks.IntLabelValue.Bind(len => intLabel.Text = AppTweaks.IntLabelValue.GetValue().ToString());
			_floatBinding = AppTweaks.FloatLabelValue.Bind(ch => floatLabel.Text = AppTweaks.FloatLabelValue.GetValue().ToString());
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}

		private UIColor GetColorFromHEX(string hex)
		{
			if (hex.Length != 7)
				return UIColor.Black;
			return UIColor.FromRGBA(Convert.ToByte(hex.Substring(1, 2), 16), Convert.ToByte(hex.Substring(3, 2), 16), Convert.ToByte(hex.Substring(5, 2), 16), (byte)255);
		}

		~ViewController()
		{
			_boolBinding.Dispose();
			_stringBinding.Dispose();
			_colorBinding.Dispose();
			_intBinding.Dispose();
			_floatBinding.Dispose();
		}
	}
}
