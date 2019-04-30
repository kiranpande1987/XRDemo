using NUnit.Framework;
using System;
using Xamarin.UITest;

namespace XRDemoTest
{
    [TestFixture()]
    public class SampleTest
    {
        [Test()]
        public void TestCase()
        {
            var app = ConfigureApp
                            .Android
                            .ApkFile("/Users/kiran/Desktop/xrdemoapk/app.apk")
                            .StartApp();

            app.Tap("Basic UI Demo");
            app.Tap("SUBMIT");
        }
    }
}
