# eyes.images.XamarinUI-Test
A sample project to showcase Applitools Eyes integration with Xamarin.UI Test framework

### Requirements
In order to run Xamarin.UI Tests with Visual Studio for Mac, the following dependencies must be met:

* NUnit 2.6.x (2.6.4) – Xamarin.UITest is not compatible with NUnit 3.x.
* Android SDK – Only if testing Android apps.
* Java Developers Kit – Only if testing Android apps.
* Xcode Command Line Tools – Only for testing iOS apps.

## Xamarin.UITest API
All test interactions with the mobile application occur through an instance of Xamarin.UITest.IApp. This interface defines the methods that are crucial for the test to collaborate with the application and interact with the user interface. There are two concrete implementations of this interface:

Xamarin.UITest.iOS.iOSApp – This class will automate tests against iOS.
Xamarin.UITest.Android.AndroidApp – This class is for automating tests on Android.

Xamarin.UI Test expects an Emulator to be already running, it can pick up the emulators that's running. If incase, you have one or more devices running, you need to pass in a device id to Xamarin.UI instance
```
 app = ConfigureApp
                .Android
                .ApkFile("../../lib/selendroid-test-app.apk")
                .DeviceSerial("")
```
## Applitools Eyes Images SDK

All eyes methods that are required for visual validations can be invoked via an instance of Eyes class.
```
Eyes eyes = new Eyes()
```
