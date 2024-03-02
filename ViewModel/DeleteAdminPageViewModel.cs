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
    public class DeleteAdminPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public DeleteAdminPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public RelayCommand Back
        {
            get => new(
                () =>
                {
                    _navigationService.NavigateTo<SuperAdminViewModel>();
                });
        }
    }
}
