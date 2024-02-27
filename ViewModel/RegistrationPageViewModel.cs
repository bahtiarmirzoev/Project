using GalaSoft.MvvmLight;
using Project.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Project.ViewModel
{
    public class RegistrationPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private string _username;
        private string _name;
        private string _surname;
        private string _fin;
        private string _phone;
        private string _email;
        private string _password;

        public string Username
        {
            get { return _username; }
            set
            {
                if (Regex.IsMatch(value, "^[a-zA-Z0-9_-]{3,16}$") || string.IsNullOrEmpty(value))
                {
                    Set(ref _username, value);
                }
                else
                {
                    MessageBox.Show("Wrong username");
                    return;
                }
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (Regex.IsMatch(value, "^[A-Z][a-z]+$") || string.IsNullOrEmpty(value))
                {
                    Set(ref _name, value);
                }
                else
                {
                    MessageBox.Show("Wrong name");
                    return;
                }
            }
        }

        public string Surname
        {
            get { return _surname; }
            set
            {
                if (Regex.IsMatch(value, "^[A-Za-z]+([-']?[A-Za-z]+)?$") || string.IsNullOrEmpty(value))
                {
                    Set(ref _surname, value);
                }
                else
                {
                    MessageBox.Show("Wrong surname");
                    return;
                }
            }
        }

        public string Fin
        {
            get { return _fin; }
            set
            {
                if (Regex.IsMatch(value, @"^\d{2}[A-Za-z]{2}\d{2}[A-Za-z]{1}$") || string.IsNullOrEmpty(value))
                {
                    Set(ref _fin, value);
                }
                else
                {
                    MessageBox.Show("Wrong FIN");
                    return;
                }
            }
        }

        public string Phone
        {
            get { return _phone; }
            set
            {
                if (Regex.IsMatch(value, @"^\+\d{3}\d{9}$") || string.IsNullOrEmpty(value))
                {
                    Set(ref _phone, value);
                }
                else
                {
                    MessageBox.Show("Wrong Phone number");
                    return;
                }
            }
        }

        private void Set(ref string phone, string value)
        {
            throw new NotImplementedException();
        }

        public string Email
        {
            get { return _email; }
            set
            {
                if (Regex.IsMatch(value, "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+/.[a-zA-Z]{2,}$") || string.IsNullOrEmpty(value))
                {
                    Set(ref _email, value);
                }
                else
                {
                    MessageBox.Show("Wrong Email");
                    return;
                }
            }
        }

        private void OnPropertyChanged(string v)
        {
            throw new NotImplementedException();
        }

        public string Password
        {
            get { return _password; }
            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged(nameof(Password));
                }
            }
        }

        public ICommand RegisterCommand { get; set; }

        public RegistrationPageViewModel()
        {
            RegisterCommand = new RelayCommand(Register);
        }

        private void Register()
        {
            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password) ||
                string.IsNullOrEmpty(Phone) || string.IsNullOrEmpty(Fin) || string.IsNullOrEmpty(Email))
            {
                Console.WriteLine("Please enter all required fields.");
                return;
            }

            

            Console.WriteLine($"User registered with: {Username}, {Name}, {Surname}, {Fin}, {Phone}, {Email}, {Password}");
        }

       

    }
}