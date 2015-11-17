using System.Reflection;
using Android.App;
using Android.OS;
using Xamarin.Android.NUnitLite;
using NUnit.Runner;

namespace SQLite.Net.Tests.XamarinAndroid
{
	[Activity (Label = "SQLite.Net.Tests.XamarinAndroid", MainLauncher = true)]
	public class MainActivity : TestSuiteActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			global::Xamarin.Forms.Forms.Init(this, bundle);
			LoadApplication(new NUnit.Runner.App());
		}
	}
}

