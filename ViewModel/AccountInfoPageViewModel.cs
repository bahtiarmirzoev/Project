using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Project.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trendyol.Models;
using Trendyol.Services.Classes;

namespace Project.ViewModel
{
    public class AccountInfoPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly TrendyolDbContext _context;
        private readonly CurrentUserService _currentUserService;
        private readonly User user = new User();

        private string _name;
        private string _surname;
        private string _email;
        private string _login;

        public string Name
        {
            get => _name;
            set => Set(ref _name, value);
        }

        public string Surname
        {
            get => _surname;
            set => Set(ref _surname, value);
        }

        public string Email
        {
            get => _email;
            set => Set(ref _email, value);
        }

        public string Login
        {
            get => _login;
            set => Set(ref _login, value);
        }


        public AccountInfoPageViewModel(INavigationService navigationService, TrendyolDbContext context, CurrentUserService currentUserService)
        {
            _navigationService = navigationService;
            _context = context;
            _currentUserService = currentUserService;
            _currentUserService.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == nameof(CurrentUserService.Name))
                {
                    Name = _currentUserService.Name;
                }
                else if (args.PropertyName == nameof(CurrentUserService.Surname))
                {
                    Surname = _currentUserService.Surname;
                }
                else if (args.PropertyName == nameof(CurrentUserService.Email))
                {
                    Email = _currentUserService.Email;
                }
                else if (args.PropertyName == nameof(CurrentUserService.Login))
                {
                    Login = _currentUserService.Login;
                }

            };
            _currentUserService.UpdateUserData(user);

        }

        public RelayCommand Back
        {
            get => new(
                () =>
                {
                    _navigationService.NavigateTo<HomePageViewModel>();
                });
        }
    }
}
