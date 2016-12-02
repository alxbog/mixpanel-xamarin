# Mixpanel bindings for Xamarin.iOS

Current Mixpanel SDK version: **3.0.6**

## How to use?

Download [Mixpanel.dll](Mixpanel.dll) and add it as a reference to your project.

## How to use A/B developer tweaks?

This binding implementation supports A/B testing developer tweaks.

### Declare all tweaks

Create a class with tweaks declarations:
```
public static class AppTweaks
{
    public static readonly Tweak<bool> ShowLabel = Tweak.Declare("Show label", defaultValue: true);
    public static readonly Tweak<int> IntLabelValue = Tweak.Declare("Int label value", defaultValue: 5, min: 0, max: 5);
    public static readonly Tweak<float> FloatLabelValue = Tweak.Declare("Float label value", defaultValue: 1.5f, min: 0.5f, max: 10f);
    public static readonly Tweak<string> LabelText = Tweak.Declare("Label text", defaultValue: "Hello tweak!");
    public static readonly Tweak<string> LabelColor = Tweak.Declare("Label text color str", defaultValue: "#ff0000");
}
```
Supported types: `string`, `bool`, `int`, `float`. Numeric types `int` and `float` also support ranges (setting min/max values).

### Register tweaks class

Right *before* Mixpanel initialization register tweaks class:
```
MixpanelTweaks.Register(typeof(AppTweaks));
Mixpanel.SharedInstanceWithToken("<YOUR TOKEN>");
```

*IMPORTANT:* Registration of tweaks should be strictly before initialization. Otherwise, it breaks tweaks persistance.

### Use tweak value

```
label.Text = AppTweaks.LabelText.GetValue();
```

### Use tweak bindings

```
_binding = AppTweaks.LabelText.Bind(text => label.Text = text);
```

*IMPORTANT:* `Tweak.Bind()` method returns disposable binding object that should be used to control binding lifetime.
Generally you should save this binding object as a `ViewController`'s field variable, so the binding will be disposed with this `ViewController`.


## How to update to a newer version?

### Prerequisites

- [Carthage](https://github.com/Carthage/Carthage)
- [Objective Sharpie](https://download.xamarin.com/objective-sharpie/ObjectiveSharpie.pkg)

### Updating

1. Run `update.sh` in the root folder to update using Carthage.
2. Check `[Verify]` items in the `ApiDefinition.cs`.
3. Build Xamarin Binding project using `build.sh` and fix error, if any.
