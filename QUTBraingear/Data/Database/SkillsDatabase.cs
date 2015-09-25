using SQLite.Net;
using Xamarin.Forms;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.Ioc;


namespace QUTBraingear.Data
{
	public class SkillsDatabase
	{
		SQLiteConnection database;

		public SkillsDatabase ()
		{
			database = DependencyService.Get<ISqlite> ().GetConnection ();
			if (database.TableMappings.All(t => t.MappedType.Name != typeof(Skills).Name)) {
				database.CreateTable<Skills> ();
				database.Commit ();
			}
		}

		public List<Skills> GetAll(){
			var items = database.Table<Skills> ().ToList<Skills>();

			return items;
		}


		public int InsertOrUpdateSkill(Skills skills){
			return database.Table<Skills> ().Where (x => x.skillId == skills.skillId).Any() 
				? database.Update (skills) : database.Insert (skills);
		}


	}
}

