using System;
namespace XRDemo
{
    public class TestApp
    {
        public TestApp()
        {
        }

        [Test]
        public void MyFirstTest()
        {
            var app = ConfigureApp
              .Android
              .ApkFile(“MyApkFile.apk”)
              .StartApp();

            app.EnterText(“NameField”, “Rasmus”);
            app.Tap(“SubmitButton”);
        }
    }
}
