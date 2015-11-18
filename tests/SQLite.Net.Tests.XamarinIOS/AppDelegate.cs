using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace SQLite.Net.Tests.XamarinIOS
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init();

			// This will load all tests within the current project
			var nunit = new NUnit.Runner.App();

			// If you want to add tests in another assembly
			//nunit.AddTestAssembly(typof(MyTests).Assembly);

			// Do you want to automatically run tests when the app starts?
			nunit.AutoRun = true;

			LoadApplication(nunit);

			return base.FinishedLaunching(app, options);
		}
	}
}

