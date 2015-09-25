using System;
using SQLite.Net;
using Xamarin.Forms;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.Ioc;


namespace QUTBraingear.Data
{
	public class QADatabase
	{
		SQLiteConnection database;

		public QADatabase ()
		{
			database = DependencyService.Get<ISqlite> ().GetConnection ();
			if (database.TableMappings.All(t => t.MappedType.Name != typeof(QA).Name)) {
				database.CreateTable<QA> ();
				database.Commit ();
			}
		}

		public List<QA> GetAll(){
			var items = database.Table<QA> ().ToList<QA>();

			return items;
		}


		public int InsertOrUpdateQA(QA qa){
			return database.Table<QA> ().Where (x => x.qaId == qa.qaId).Any() 
				? database.Update (qa) : database.Insert (qa);
		}


	}
}

