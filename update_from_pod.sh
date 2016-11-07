mkdir sharpie_output
cd sharpie_output

sharpie pod init iphoneos Mixpanel
sharpie pod bind -n Mixpanel

cd ..
cp sharpie_output/Binding/Mixpanel_ApiDefinitions.cs ApiDefinition.cs
cp sharpie_output/Binding/Mixpanel_StructsAndEnums.cs Structs.cs

rm -rf Mixpanel.framework
cp -r sharpie_output/Binding/Mixpanel.framework .

rm -rf sharpie_output