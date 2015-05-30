"/Applications/Xamarin Studio.app/Contents/MacOS/mdtool" build ../src/iOS/FloatLabeledEntry.iOS.sln "-c:Release"

nuget pack FloatLabeledEntry.iOS.nuspec -NoDefaultExcludes
nuget pack FloatLabeledEntry.iOS.Dialog.nuspec -NoDefaultExcludes