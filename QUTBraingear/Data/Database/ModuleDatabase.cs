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
			if (database.TableMappings.All(t => t.MappedType.Name != typeof(Comment).Name)) {
				database.CreateTable<Comment> ();
				database.Commit ();
			}
		}

		public List<Module> GetAll(){
			var items = database.Table<Module> ().ToList<Module>();
			return items;
		}

		public List<Comment> GetModuleComments(int moduleId){
			var items = database.Table<Comment> ().Where(x => x.moduleId == moduleId).ToList();
			return items;
		}

		public Module GetModule(int moduleId) {
			return database.Table<Module> ().Where (x => x.moduleID == moduleId).First();
		}


		public int InsertOrUpdateModules(Module modules){
			return database.Table<Module> ().Where (x => x.moduleID == modules.moduleID).Any() 
				? database.Update (modules) : database.Insert (modules);
		}

		public int InsertOrUpdateComments(Comment comments){
			return database.Table<Comment> ().Where (x => x.moduleId == comments.moduleId && x.commentId == comments.commentId).Any() 
				? database.Update (comments) : database.Insert (comments);
		}
	}
}

