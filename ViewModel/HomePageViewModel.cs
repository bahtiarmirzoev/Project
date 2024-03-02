
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
    public class HomePageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public HomePageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public RelayCommand Info
        {
            get => new(
                () =>
                {
                    _navigationService.NavigateTo<AccountInfoPageViewModel>();
                });
        }

        public RelayCommand BuyOrder
        {
            get => new(
                () =>
                {
                    _navigationService.NavigateTo<AddOrderUserPageViewModel>();
                });
        }

        public RelayCommand History
        {
            get => new(
                () =>
                {
                    _navigationService.NavigateTo<MyOrdersViewModel>();
                });
        }

        public RelayCommand Cancel
        {
            get => new(
                () =>
                {
                    _navigationService.NavigateTo<GancelOrderPageViewModel>();
                });
        }

        public RelayCommand Exit
        {
            get => new(
                () =>
                {
                    _navigationService.NavigateTo<LoginPageViewModel>();
                });
        }

       
    }
}
