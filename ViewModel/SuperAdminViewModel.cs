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
    public class SuperAdminViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public SuperAdminViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public RelayCommand Back
        {
            get => new(
                () =>
                {
                    _navigationService.NavigateTo<LoginPageViewModel>();
                });
        }

        public RelayCommand AddAdmin
        {
            get => new(
                () =>
                {
                    _navigationService.NavigateTo<AddAdminPageViewModel>();
                });
        }

        public RelayCommand DeleteAdmin
        {
            get => new(
                () =>
                {
                    _navigationService.NavigateTo<DeleteAdminPageViewModel>();
                });
        }
    }
}
