using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using Plugin.LocalNotifications;
using UIKit;
using UserNotifications;
using Xamarin.Forms;

namespace XRDemo.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            DependencyService.Register<LocalNotificationsImplementation>();

            LoadApplication(new App());

            //var settings = UIUserNotificationSettings.GetSettingsForTypes(
            //                    UIUserNotificationType.Alert
            //                    | UIUserNotificationType.Badge
            //                    | UIUserNotificationType.Sound,
            //                    new NSSet());
            //UIApplication.SharedApplication.RegisterUserNotificationSettings(settings);



            UserNotifications.UNUserNotificationCenter center = UNUserNotificationCenter.Current;
            UNAuthorizationOptions optio = UNAuthorizationOptions.Alert | UNAuthorizationOptions.Sound | UNAuthorizationOptions.CriticalAlert;
            center.RequestAuthorization(optio, (bool success, NSError error) => { });
        
            return base.FinishedLaunching(app, options);
        }
    }
}
