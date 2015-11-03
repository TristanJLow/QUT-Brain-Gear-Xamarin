using Xamarin.Forms;
using System.Linq;
using System.Collections.Generic;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;
using System;
using System.Collections.ObjectModel;
using Microsoft.WindowsAzure.MobileServices.Sync;

namespace QUTBraingear.Data
{
	public static class QUTBrainGearDB
	{
		public static IMobileServiceSyncTable<Module> ModuleTable { get; set; }
		public static IMobileServiceSyncTable<QA> QATable { get; set; }
		public static IMobileServiceSyncTable<Comment> CommentTable { get; set; }
		public static IMobileServiceSyncTable<Skills> SkillsTable { get; set; }

		public static IMobileServiceClient MobileService { get; set; }

		public static void SyncAsync()
		{
			MobileService.SyncContext.PushAsync().ConfigureAwait(false);

			ModuleTable.PullAsync ("allModules", ModuleTable.CreateQuery());
			QATable.PullAsync ("allQA", QATable.CreateQuery());
			CommentTable.PullAsync ("allComments", CommentTable.CreateQuery());
			SkillsTable.PullAsync("allSkills", SkillsTable.CreateQuery());
		}

		public static async Task<ObservableCollection<Module>> GetAllModules(){
			var x = new ObservableCollection<Module>(await ModuleTable.ToCollectionAsync<Module>().ConfigureAwait(false));
			return x;
		}

		public static async Task<ObservableCollection<QA>> GetAllQA(){
			var x = new ObservableCollection<QA>(await QATable.ToCollectionAsync<QA>().ConfigureAwait(false));
			return x;
		}

		public static async Task<ObservableCollection<Skills>> GetAllSkills(){
			var x = new ObservableCollection<Skills>(await SkillsTable.ToCollectionAsync<Skills>().ConfigureAwait(false));
			return x;
		}

		public static async Task<Module> GetModule(string moduleId) {
			var x = new Module ();
			x = await ModuleTable.LookupAsync (moduleId).ConfigureAwait(false);
			return x;
		}

		public static async Task<ObservableCollection<Comment>> GetModuleComments(string moduleId){
			var x = new ObservableCollection<Comment>(await CommentTable.Where(y => y.moduleId == moduleId).ToCollectionAsync<Comment>().ConfigureAwait(false));
			return x;
		}

		public static int InsertOrUpdateQA(QA qa){
			var lookup = MobileService.GetTable<QA> ().LookupAsync (qa.id);
			if (lookup == null || qa.id == null) {
				QATable.InsertAsync (qa);
			} else {
				QATable.UpdateAsync (qa);
			}
			MobileService.SyncContext.PushAsync();
			return 1;
		}

		public static int InsertOrUpdateModules(Module module){
			var lookup = ModuleTable.LookupAsync (module.id);
			if (lookup == null || module.id == null) {
				ModuleTable.InsertAsync (module);
			} else {
				ModuleTable.UpdateAsync (module);
			}
			MobileService.SyncContext.PushAsync();
			return 1;
		}

		public static int InsertOrUpdateComments(Comment comment){
			var lookup = CommentTable.LookupAsync (comment.id);
			if (lookup == null || comment.id == null) {
				CommentTable.InsertAsync (comment);
			} else {
				CommentTable.UpdateAsync (comment);
			}
			MobileService.SyncContext.PushAsync();
			return 1;
		}

		public static int InsertOrUpdateSkills(Skills skill){
			var lookup = SkillsTable.LookupAsync (skill.id);
			if (lookup == null || skill.id == null) {
				SkillsTable.InsertAsync (skill);
			} else {
				SkillsTable.UpdateAsync (skill);
			}
			MobileService.SyncContext.PushAsync();
			return 1;
		}
	}
}

