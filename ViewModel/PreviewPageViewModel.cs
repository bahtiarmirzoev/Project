using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Project.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ViewModel
{
    public class PreviewPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public PreviewPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public RelayCommand Login
        {
            get => new(
                () =>
                {
                    _navigationService.NavigateTo<LoginPageViewModel>();
                });
        }

        public RelayCommand Register
        {
            get => new(
                () =>
                {
                    _navigationService.NavigateTo<RegistrationPageViewModel>();
                });
        }
    }
}
