using System;
using System.Drawing;
using System.IO;
using System.Linq;
using Applitools.Images;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Android;
using Xamarin.UITest.Queries;

namespace imagesandroidxamarinUITest
{
    [TestFixture]
    public class Tests
    {
        AndroidApp app;
        Eyes eyes;

        [SetUp]
        public void BeforeEachTest()
        {
            var dir = System.IO.Directory.GetParent(System.IO.Directory.GetCurrentDirectory());
            Console.WriteLine(dir);
            app = ConfigureApp
                .Android
                .ApkFile("../../lib/selendroid-test-app.apk")
                .EnableLocalScreenshots()
                .PreferIdeSettings()
                .StartApp();

            eyes = new Eyes();
            eyes.ApiKey = "your-api-key";
            eyes.SetAppEnvironment("Nexus 6P ", "MyNewTest");
        }

        [Test]
        public void AppLaunches()
        {
            try
            {
                eyes.Open("Android-test-one", "Xamarin-UI-Test-demo");
                app.Tap(x => x.Id("startUserRegistration"));
                var eyesImage1 = app.Screenshot("Home Page screen.").FullName;
                Console.WriteLine(eyesImage1);
                eyes.CheckImageFile(eyesImage1);
                app.EnterText(x => x.Id("inputUsername"), "Eyes");
                app.EnterText(x => x.Id("inputEmail"), "hello@applitools.com");
                app.EnterText(x => x.Id("inputPassword"), "ApPl!t0ols");
                app.ClearText((x => x.Id("inputName")));
                app.EnterText(x => x.Id("inputName"), "Hello World");
                app.DismissKeyboard();
                app.Tap(x => x.Id("input_preferedProgrammingLanguage"));
                app.TapCoordinates(79, 1070);
                app.Tap(x => x.Id("input_adds"));
                System.Threading.Thread.Sleep(2);//For Demo.Feel free to remove this line. 
                var eyesImage2 = app.Screenshot("After Input- screen.").FullName;

                eyes.CheckImageFile(eyesImage2);
                app.Tap(x => x.Id("btnRegisterUser"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                eyes.Close();
                eyes.AbortIfNotClosed();
            }
        }
    }
}
