using Xamarin.Forms;
using System.Linq;
using System.Collections.Generic;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;
using System;
using System.Collections.ObjectModel;

namespace QUTBraingear.Data
{
	public class QUTBrainGearDB
	{
		public static MobileServiceClient MobileService = new MobileServiceClient(
			"https://qutbraingearapp.azure-mobile.net/",
			"dqTWRsEygjexEvHVQYjzrneKfvTKBU73"
		);

		public QUTBrainGearDB () {
		}

		public async Task<ObservableCollection<Module>> GetAllModules(){
			var x = new ObservableCollection<Module>(await MobileService.GetTable<Module>().ToCollectionAsync<Module>());
			return x;
		}

		public async Task<ObservableCollection<QA>> GetAllQA(){
			var x = new ObservableCollection<QA>(await MobileService.GetTable<QA>().ToCollectionAsync<QA>());
			return x;
		}

		public async Task<ObservableCollection<Skills>> GetAllSkills(){
			var x = new ObservableCollection<Skills>(await MobileService.GetTable<Skills>().ToCollectionAsync<Skills>());
			return x;
		}

		public async Task<Module> GetModule(string moduleId) {
			var x = new Module ();
			x = await MobileService.GetTable<Module> ().LookupAsync (moduleId).ConfigureAwait(false);
			return x;
		}

		public async Task<ObservableCollection<Comment>> GetModuleComments(string moduleId){
			var x = new ObservableCollection<Comment>(await MobileService.GetTable<Comment> ().Where(y => y.moduleId == moduleId).ToCollectionAsync<Comment>().ConfigureAwait(false));
			return x;
		}

		public int InsertOrUpdateQA(QA qa){
			var lookup = MobileService.GetTable<QA> ().LookupAsync (qa.id);
			if (lookup == null || qa.id == null) {
				MobileService.GetTable<QA> ().InsertAsync (qa);
			} else {
				MobileService.GetTable<QA> ().UpdateAsync (qa);
			}
			return 1;
		}

		public int InsertOrUpdateModules(Module module){
			var lookup = MobileService.GetTable<Module> ().LookupAsync (module.id);
			if (lookup == null || module.id == null) {
				MobileService.GetTable<Module> ().InsertAsync (module);
			} else {
				MobileService.GetTable<Module> ().UpdateAsync (module);
			}
			return 1;
		}

		public int InsertOrUpdateComments(Comment comment){
			var lookup = MobileService.GetTable<Comment> ().LookupAsync (comment.id);
			if (lookup == null || comment.id == null) {
				MobileService.GetTable<Comment> ().InsertAsync (comment);
			} else {
				MobileService.GetTable<Comment> ().UpdateAsync (comment);
			}
			return 1;
		}

		public int InsertOrUpdateSkills(Skills skill){
			var lookup = MobileService.GetTable<Skills> ().LookupAsync (skill.id);
			if (lookup == null || skill.id == null) {
				MobileService.GetTable<Skills> ().InsertAsync (skill);
			} else {
				MobileService.GetTable<Skills> ().UpdateAsync (skill);
			}
			return 1;
		}
	}
}

