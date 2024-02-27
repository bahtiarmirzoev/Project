using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Project.ViewModel
{
    public class LoginPageViewModel:ViewModelBase
    {
        private string _username;
        private string _password;

        public string Username
        {
            get { return _username; }
            set => Set(ref _username, value);
        }

        public string Password
        {
            get { return _password; }
            set => Set(ref _password, value);
        }

        public ICommand SignInCommand { get; }

        public ICommand NavigateToRegistrationCommand { get; }

        public LoginPageViewModel()
        {
            SignInCommand = new RelayCommand(SignIn, CanSignIn);
            NavigateToRegistrationCommand = new RelayCommand(NavigateToRegistration);
        }

        private bool CanSignIn(object parameter)
        {
            return !string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password);
        }

        private void SignIn(object parameter)
        {
            MessageBox.Show("Signing in...");
        }

        private void NavigateToRegistration(object parameter)
        {
            MessageBox.Show("Navigating to registration page...");
        }
    }


}
