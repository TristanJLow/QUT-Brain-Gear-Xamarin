using SQLite.Net;
using Xamarin.Forms;
using System.Linq;
using System.Collections.Generic;
using GalaSoft.MvvmLight.Ioc;

namespace QUTBraingear.Data
{
	public class QUTBrainGearDB
	{
		SQLiteConnection database;

		public QUTBrainGearDB ()
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
			if (database.TableMappings.All(t => t.MappedType.Name != typeof(QA).Name)) {
				database.CreateTable<QA> ();
				database.Commit ();
			}
			if (database.TableMappings.All(t => t.MappedType.Name != typeof(Skills).Name)) {
				database.CreateTable<Skills> ();
				database.Commit ();
			}
		}

		public List<Module> GetAllModules(){
			var items = database.Table<Module> ().ToList<Module>();
			return items;
		}

		public List<QA> GetAllQA(){
			var items = database.Table<QA> ().ToList<QA>();

			return items;
		}
			
		public int InsertOrUpdateQA(QA qa){
			return database.Table<QA> ().Where (x => x.qaId == qa.qaId).Any() 
				? database.Update (qa) : database.Insert (qa);
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

		public List<Skills> GetAllSkills(){
			var items = database.Table<Skills> ().ToList<Skills>();

			return items;
		}
			
		public int InsertOrUpdateSkill(Skills skills){
			return database.Table<Skills> ().Where (x => x.skillId == skills.skillId).Any() 
				? database.Update (skills) : database.Insert (skills);
		}
	}
}

