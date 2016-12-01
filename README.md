# Mixpanel bindings for Xamarin.iOS

Current Mixpanel SDK version: **3.0.6**

## How to use?

Download [Mixpanel.dll](Mixpanel.dll) and add it as a reference to your project.

## How to update to a newer version?

### Prerequisites

- [Carthage](https://github.com/Carthage/Carthage)
- [Objective Sharpie](https://download.xamarin.com/objective-sharpie/ObjectiveSharpie.pkg)

### Updating

1. Run `update.sh` in the root folder to update using Carthage.
2. Check `[Verify]` items in the `ApiDefinition.cs`.
3. Build Xamarin Binding project using `build.sh` and fix error, if any.