using GalaSoft.MvvmLight;
using System.Collections.Generic;
using System;
using System.Windows.Input;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using QUTBraingear.Data.Models;

namespace QUTBraingear.Data.ViewModel
{
	/// <summary>
	/// This class contains properties that the main View can data bind to.
	/// <para>
	/// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
	/// </para>
	/// <para>
	/// You can also use Blend to data bind with the tool's support.
	/// </para>
	/// <para>
	/// See http://www.galasoft.ch/mvvm
	/// </para>
	/// </summary>
	public class SearchPageViewModel : ViewModelBase
	{
		private IMyNavigationService navigationService;
        private ObservableCollection<SearchResult> _searchResultList;
		private ObservableCollection<Module> moduleList;
        private string _searchText = string.Empty;
        private bool ready = false;

        public ObservableCollection<SearchResult> SearchResults
        {
            get { return _searchResultList; }
            set
            {
                if (_searchResultList != value) {
                    _searchResultList = value;
				}
			}
		}
			
		public async void GetData () {
			this.moduleList = await QUTBrainGearDB.GetAllModules();
            ready = true;
		}

        
        private Xamarin.Forms.Command _searchCommand;
        public System.Windows.Input.ICommand SearchCommand
        {
            get
            {
                _searchCommand = _searchCommand ?? new Xamarin.Forms.Command(DoSearchCommand, CanExecuteSearchCommand);
                return _searchCommand;
            }
        }
        private void DoSearchCommand()
        {
            _searchResultList.Clear();
            foreach (var item in this.moduleList) {
                if (
					item.moduleTitle.Contains(this.SearchText)
					|| item.moduleDesc.Contains(this.SearchText)
				) { 
                    var result=new SearchResult();
					result.id=item.id;
                    result.Title=item.moduleTitle;
                    _searchResultList.Add(result);
                }
            }
			
            RaisePropertyChanged(() => SearchResults);
        }

        private bool CanExecuteSearchCommand()
        {
            return ready;
        }

        public string SearchText
        {
            get { return _searchText; }
            set
            {
                if (_searchText != value)
                {
                    _searchText = value;
                    RaisePropertyChanged(() => SearchText);

                    // Perform the search
                    if (SearchCommand.CanExecute(null))
                    {
                        SearchCommand.Execute(null);
                    }
                }
            }
        }

		public void ClearSearch () {
			_searchText = null;
			_searchResultList.Clear();
			moduleList.Clear();
			GetData ();
		}
		
		/// <summary>
		/// Initializes a new instance of the MainViewModel class.
		/// </summary>
        public SearchPageViewModel(IMyNavigationService navigationService)
		{
			this.navigationService = navigationService;
			GetData ();
            _searchResultList = new ObservableCollection<SearchResult>();
		}

	}
}