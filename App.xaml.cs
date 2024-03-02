using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using System.Windows.Navigation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SimpleInjector;
using Project.ViewModel;
using Project.View;
using Project.Services.Interfaces;
using MaterialDesignThemes.Wpf;
using Trendyol.Services.Classes;
namespace Project
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static SimpleInjector.Container Container { get; set; }
        void Register()
        {
            Container = new SimpleInjector.Container();

            Container.RegisterSingleton<IMessenger, Messenger>();
            Container.RegisterSingleton<INavigationService, Trendyol.Services.Classes.NavigationService>();
            Container.RegisterSingleton<CurrentUserService>();
            Container.RegisterSingleton<UserService>();
            Container.RegisterSingleton<TrendyolDbContext>();
            Container.RegisterSingleton<AccountInfoPageViewModel>();
            Container.RegisterSingleton<AddAdminPageViewModel>();
            Container.RegisterSingleton<AddOrderPageViewModel>();
            Container.RegisterSingleton<DeleteAdminPageViewModel>();
            Container.RegisterSingleton<HomePageViewModel>();
            Container.RegisterSingleton<LoginPageViewModel>();
            Container.RegisterSingleton<MainViewModel>();
            Container.RegisterSingleton<PreviewPageViewModel>();
            Container.RegisterSingleton<ProductCountPageViewModel>();
            Container.RegisterSingleton<RegistrationPageViewModel>();

            Container.Register<AddOrderUserPageViewModel>();
            Container.Register<GancelOrderPageViewModel>();
            Container.Register<MyOrdersViewModel>();
            Container.Register<AdminPageViewModel>();
            Container.Register<SuperAdminViewModel>();
            Container.Verify();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            Register();
            var window = new MainView();
            window.DataContext = Container.GetInstance<MainViewModel>();
            window.Show();
        }
    }
}
