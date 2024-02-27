using System.Windows.Input;

namespace Project.ViewModel
{
    internal class RelayCommand : ICommand
    {
        private Action<object> navigateToRegistration;

        public RelayCommand(Action register)
        {
            Register = register;
        }

        public RelayCommand(Action<object> navigateToRegistration)
        {
            this.navigateToRegistration = navigateToRegistration;
        }

        public RelayCommand(Action<object> signIn, Func<object, bool> canSignIn)
        {
            SignIn = signIn;
            CanSignIn = canSignIn;
        }

        public Action Register { get; }
        public Action<object> SignIn { get; }
        public Func<object, bool> CanSignIn { get; }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            throw new NotImplementedException();
        }

        public void Execute(object? parameter)
        {
            throw new NotImplementedException();
        }
    }
}