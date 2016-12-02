using MixpanelLib;
using UIKit;

namespace MixpanelDemo
{
	public static class AppTweaks
	{
		public static readonly Tweak<bool> ShowLabel = Tweak.Declare("Show label", defaultValue: true);
		public static readonly Tweak<int> IntLabelValue = Tweak.Declare("Int label value", defaultValue: 5, min: 0, max: 5);
		public static readonly Tweak<float> FloatLabelValue = Tweak.Declare("Float label value", defaultValue: 1.5f, min: 0.5f, max: 10f);
		public static readonly Tweak<string> LabelText = Tweak.Declare("Label text", defaultValue: "Hello tweak!");
		public static readonly Tweak<string> LabelColor = Tweak.Declare("Label text color str", defaultValue: "#ff0000");
	}
}
