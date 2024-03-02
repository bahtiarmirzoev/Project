using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Project.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Trendyol.Services.Classes;

namespace Project.ViewModel
{
    public class LoginPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly UserService _usersService;
        private readonly AdminService _adminService;
        private readonly SuperAdminService _superAdminService;
        private readonly TrendyolDbContext _context;
        private readonly CurrentUserService _currentUserService;

        private string _username;
        private string _password;

        public string Username
        {
            get => _username;
            set => Set(ref _username, value);
        }

        public string Password
        {
            get => _password;
            set => Set(ref _password, value);
        }

        public LoginPageViewModel(INavigationService navigationService, CurrentUserService currentUserService)
        {
            _context = new TrendyolDbContext();
            _usersService = new UserService(_context);
            _adminService = new AdminService(_context);
            _superAdminService = new SuperAdminService(_context);
            _navigationService = navigationService;
            _currentUserService = currentUserService;

        }

        public RelayCommand Back
        {
            get => new(
                () =>
                {
                    _navigationService.NavigateTo<PreviewPageViewModel>();
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

        public RelayCommand Login
        {
            get => new(
                () =>
                {
                    try
                    {
                        if (_superAdminService.SuperAdminLogin(Username, Password))
                        {
                            _navigationService.NavigateTo<SuperAdminViewModel>();
                            Username = null;
                            Password = null;
                        }
                        else if (_adminService.AdminLogin(Username, Password))
                        {
                            _navigationService.NavigateTo<AdminPageViewModel>();
                            Username = null;
                            Password = null;
                        }
                        else if (_usersService.UserLogin(Username, Password))
                        {
                            var user = _usersService.GetUser(Username);
                            _currentUserService.UpdateUserData(user);
                            Username = null;
                            Password = null;
                            _navigationService.NavigateTo<HomePageViewModel>();
                        }
                        else
                        {
                            MessageBox.Show("Неправильный e-mail или пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                            Password = "";
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                });
        }
    }
}
