using SQLite.Net;
using Xamarin.Forms;
using System.Linq;
using System.Collections.Generic;
using GalaSoft.MvvmLight.Ioc;

namespace QUTBraingear.Data
{
	public class ModuleDatabase
	{
		SQLiteConnection database;

		public ModuleDatabase ()
		{
			database = DependencyService.Get<ISqlite> ().GetConnection ();
			if (database.TableMappings.All(t => t.MappedType.Name != typeof(Module).Name)) {
				database.CreateTable<Module> ();
				database.Commit ();
			}
		}

		public List<Module> GetAll(){
			var items = database.Table<Module> ().ToList<Module>();

			return items;
		}


		public int InsertOrUpdateSkill(Module modules){
			return database.Table<Module> ().Where (x => x.moduleID == modules.moduleID).Any() 
				? database.Update (modules) : database.Insert (modules);
		}
	}
}

