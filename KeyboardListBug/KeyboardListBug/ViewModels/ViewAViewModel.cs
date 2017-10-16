using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

namespace KeyboardListBug.ViewModels
{
    public class ViewAViewModel : BindableBase
    {
        public DelegateCommand BackCommand { get; set; }
        private INavigationService _navigationService;

        public ViewAViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            BackCommand = new DelegateCommand(BackExecute);
        }

        private void BackExecute()
        {
            _navigationService.GoBackAsync();
        }
    }
}
