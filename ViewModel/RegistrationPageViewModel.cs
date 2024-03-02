using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Project.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using Trendyol.Models;
using Trendyol.Services.Classes;

namespace Project.ViewModel
{
    public class RegistrationPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private string _name;
        private string _surname;
        private string _login;
        private string _email;
        private string _password;
        private string _trypassword;

        public string Firstname
        {
            get => _name;
            set
            {
                if (Regex.IsMatch(value, "^[A-Z][a-z]+$") || string.IsNullOrEmpty(value))
                {
                    Set(ref _name, value);
                }
                else
                {
                    MessageBox.Show("Неправильный формат имени (попробуйте ввести имя с первой заглавной буквой и без дополнительных знаков или чисел)", "Error", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    return;
                }
            }
        }

        public string Surname
        {
            get => _surname;
            set
            {
                if (Regex.IsMatch(value, "^[A-Z][a-z]+$") || string.IsNullOrEmpty(value))
                {
                    Set(ref _surname, value);
                }
                else
                {
                    MessageBox.Show("Неправильный формат фамилии (попробуйте ввести фамилию с первой заглавной буквой и без дополнительных знаков или чисел)", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
            }
        }

        public string Username
        {
            get => _login;
            set
            {
                if (Regex.IsMatch(value, "^[a-zA-Z0-9_-]{3,16}$") || string.IsNullOrEmpty(value))
                {
                    Set(ref _login, value);
                }
                else
                {
                    MessageBox.Show("Неправильный формат логина (попробуйте ввести логин с использованием букв без дополнительных знаков)", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                if (Regex.IsMatch(value, "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$") || string.IsNullOrEmpty(value))
                {
                    Set(ref _email, value);
                }
                else
                {
                    MessageBox.Show("Неправильный формат e-mail (попробуйте ввести e-mail с использованием букв,цифр и с препиской например @gmail.com)", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                if (Regex.IsMatch(value, @"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[!@#$%^&*()-_+=])[A-Za-z\d!@#$%^&*()-_+=]{8,}$") || string.IsNullOrEmpty(value))
                {
                    Set(ref _password, value);
                }
                else
                {
                    MessageBox.Show("Неправильный формат пароля (попробуйте ввести пароль с использованием заглавной и прописной буквы и цифры(минимальный размер 8))", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
            }
        }

        public string TryPassword
        {
            get => _trypassword;
            set => Set(ref _trypassword, value);
        }

        public RegistrationPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public RelayCommand Back
        {
            get => new(
                () =>
                {
                    _navigationService.NavigateTo<PreviewPageViewModel>();
                });
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
                    try
                    {
                        using (TrendyolDbContext context = new TrendyolDbContext())
                        {
                            if (context.Users.Any(u => u.Login == Username || u.Email == Email))
                            {
                                MessageBox.Show("Пользователь с такими данными уже существует в базе данных", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                                return;
                            }
                            else if (TryPassword != Password)
                            {
                                MessageBox.Show("Пароли не совпадают", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                                return;
                            }
                            else
                            {
                                User user = new User
                                {
                                    Name = Firstname,
                                    Surname = Surname,
                                    Login = Username,
                                    Email = Email,
                                    Password = BCrypt.Net.BCrypt.HashPassword(Password),
                                };
                                context.Users.Add(user);
                                context.SaveChanges();
                                MessageBox.Show("Регистрация пройдена успешно");
                                Firstname = "";
                                Surname = "";
                                Username = "";
                                Email = "";
                                Password = "";
                                TryPassword = "";
                                _navigationService.NavigateTo<LoginPageViewModel>();
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
