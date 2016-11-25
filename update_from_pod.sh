mkdir sharpie_output
cd sharpie_output

sharpie pod init iphoneos Mixpanel
sharpie pod bind -n Mixpanel
sharpie bind -n Mixpanel -sdk iphoneos Binding/Mixpanel.framework/Headers/Mixpanel.h Binding/Mixpanel.framework/Headers/MPSurvey.h -scope Binding/Mixpanel.framework/Headers -c -F .

cd ..
cp sharpie_output/ApiDefinitions.cs ApiDefinition.cs

rm -rf Mixpanel.framework
cp -r sharpie_output/Binding/Mixpanel.framework .

rm -rf sharpie_output