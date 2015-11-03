using System;
using Microsoft.WindowsAzure.MobileServices;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using QUTBraingear.Data;
using System.IO;
using Microsoft.WindowsAzure.MobileServices.Sync;

namespace QUTBraingear.Droid
{
	[Activity (Label = "QUTBraingear.Droid", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
	{
		const string localDbFilename = "localstore.db";

		private MobileServiceClient MobileService;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			global::Xamarin.Forms.Forms.Init (this, bundle);
			
			CurrentPlatform.Init();

			MobileService = new MobileServiceClient(
				"https://qutbraingearapp.azure-mobile.net/",
				"dqTWRsEygjexEvHVQYjzrneKfvTKBU73"
			);

			// new code to initialize the SQLite store
			string path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), localDbFilename);

			if (!File.Exists(path))
			{
				File.Create(path).Dispose();
			}

			var store = new MobileServiceSQLiteStore(path);
			store.DefineTable<Module>();
			store.DefineTable<QA>();
			store.DefineTable<Comment>();
			store.DefineTable<Skills>();

			// Uses the default conflict handler, which fails on conflict
			MobileService.SyncContext.InitializeAsync(store, new MobileServiceSyncHandler ()).Wait ();
			QUTBrainGearDB.MobileService = MobileService;

			QUTBrainGearDB.ModuleTable = MobileService.GetSyncTable <Module> ();
			QUTBrainGearDB.QATable = MobileService.GetSyncTable <QA> ();
			QUTBrainGearDB.CommentTable = MobileService.GetSyncTable <Comment> ();
			QUTBrainGearDB.SkillsTable = MobileService.GetSyncTable <Skills> ();

			QUTBrainGearDB.SyncAsync ();


			LoadApplication (new App());
		}
	}
}

