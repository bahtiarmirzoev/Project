using GalaSoft.MvvmLight.Messaging;
using Project.Services.Classes;
using Project.Services.Interfaces;
using Project.View;
using Project.ViewModel;
using SimpleInjector;
using System.Configuration;
using System.Data;
using System.Windows;

namespace Project
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Container Container { get; set; }

        public void Register()
        {
            Container = new();

            Container.RegisterSingleton<IMessenger, Messenger>();
            Container.RegisterSingleton<INavigationService, NavigationService>();

            Container.RegisterSingleton<MainViewModel>();
            Container.RegisterSingleton<RegistrationPageViewModel>();

            Container.Verify();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            Register();

            var window = new MainView()
            {
                DataContext = Container.GetInstance<MainViewModel>()
            };
            window.ShowDialog();
        }
    }
}
