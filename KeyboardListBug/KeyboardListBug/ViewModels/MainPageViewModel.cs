using MvvmHelpers;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;

namespace KeyboardListBug.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigatingAware
    {
        public ObservableRangeCollection<string> Items { get; } = new ObservableRangeCollection<string>();

        public DelegateCommand NextCommand { get; set; }

        private bool _isRefreshing = true;
        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set { SetProperty(ref _isRefreshing, value); }
        }

        private INavigationService _navigationService;

        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            NextCommand = new DelegateCommand(NextExecute);
        }

        private void NextExecute()
        {
            _navigationService.NavigateAsync("ViewA");
        }

        public async void OnNavigatingTo(NavigationParameters parameters)
        {
            IsRefreshing = true;

            await Task.Delay(1000);

            Items.ReplaceRange(new List<string> { "Mercury", "Venus", "Earth", "Mars", "Jupiter", "Saturn", "Uranus", "Neptune" });

            IsRefreshing = false;
        }
    }
}
