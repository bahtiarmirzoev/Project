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
    public class AddAdminPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly TrendyolDbContext _context;
        private readonly AdminService _adminservice;

        private string _login;
        private string _password;
        private string _trypassword;

        public string Login
        {
            get => _login;
            set => Set(ref _login, value);
        }

        public string Password
        {
            get => _password;
            set => Set(ref _password, value);
        }

        public string TryPassword
        {
            get => _trypassword;
            set => Set(ref _trypassword, value);
        }

        public AddAdminPageViewModel(INavigationService navigationService, TrendyolDbContext context)
        {
            _navigationService = navigationService;
            _context = context;
            _adminservice = new AdminService(_context);
        }

        public RelayCommand Back
        {
            get => new(
                () =>
                {
                    _navigationService.NavigateTo<SuperAdminViewModel>();
                });
        }

        public RelayCommand Add
        {
            get => new(
                () =>
                {
                    try
                    {
                        using (TrendyolDbContext context = new TrendyolDbContext())
                        {
                            if (_context.Admin.Any(a => a.Name == Login))
                            {
                                MessageBox.Show("Админ с такими данными уже существует в базе данных", "Ошибка");
                                return;
                            }
                            else if (TryPassword != Password)
                            {
                                MessageBox.Show("Вы неправильно ввели повторный пароль", "Ошибка");
                                return;
                            }
                            else
                            {
                                var newadmin = _adminservice.AdminRegister(Login, Password);
                                _context.Admin.Add(newadmin);
                                _context.SaveChanges();
                                MessageBox.Show("Успешно создан", "Admin");
                                Password = "";
                                TryPassword = "";
                                _navigationService.NavigateTo<SuperAdminViewModel>();
                            }
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
