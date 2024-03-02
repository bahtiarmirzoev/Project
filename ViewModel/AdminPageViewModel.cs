using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Project.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Trendyol.Models;
using Trendyol.Services.Classes;

namespace Project.ViewModel
{
    public class AdminPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly TrendyolDbContext _context;
        private readonly CurrentUserService _currentUserService;
        private ObservableCollection<Order> _order;
        private Order _selectedOrder;
        private RadioButtons _radioButtons;

        public ObservableCollection<Order> Order
        {
            get => _order;
            set => Set(ref _order, value);
        }

        public Order SelectedOrder
        {
            get => _selectedOrder;
            set => Set(ref _selectedOrder, value);
        }

        public RadioButtons RadioButton
        {
            get => _radioButtons;
            set => Set(ref _radioButtons, value);
        }

        public AdminPageViewModel(INavigationService navigationService, TrendyolDbContext context, CurrentUserService currentUserService)
        {
            _navigationService = navigationService;
            _context = context;
            _currentUserService = currentUserService;
            RadioButton = new RadioButtons();
            Order = new ObservableCollection<Order>(_context.Orders.ToList());
        }

        public RelayCommand Exit
        {
            get => new(
                () =>
                {
                    _navigationService.NavigateTo<LoginPageViewModel>();
                });
        }
        public RelayCommand Add
        {
            get => new(
                () =>
                {
                    _navigationService.NavigateTo<AddOrderPageViewModel>();
                });
        }

        public RelayCommand Radio
        {
            get => new(
                () =>
                {
                    try
                    {

                        if (RadioButton.OrderPlaced)
                        {
                            if (SelectedOrder.Status == "Заказ сделан")
                            {
                                SelectedOrder.Status = "Заказ сделан";
                            }
                            else
                            {
                                MessageBox.Show("Невозможно перенести заказ на этот этап");
                                return;
                            }
                        }
                        else if (RadioButton.ArrivedAtTheWarehouse)
                        {
                            if (SelectedOrder.Status == "Заказ сделан" || SelectedOrder.Status == "Поступил на склад")
                            {
                                SelectedOrder.Status = "Поступил на склад";
                            }
                            else
                            {
                                MessageBox.Show("Невозможно перенести заказ на этот этап");
                                return;
                            }
                        }
                        else if (RadioButton.Sent)
                        {
                            if (SelectedOrder.Status == "Поступил на склад" || SelectedOrder.Status == "Отправлен")
                            {
                                SelectedOrder.Status = "Отправлен";
                            }
                            else
                            {
                                MessageBox.Show("Невозможно перенести заказ на этот этап");
                                return;
                            }
                        }
                        else if (RadioButton.SmartCustomsCheck)
                        {
                            if (SelectedOrder.Status == "Отправлен" || SelectedOrder.Status == "На таможенной проверке")
                            {

                                SelectedOrder.Status = "На таможенной проверке";
                            }
                            else
                            {
                                MessageBox.Show("Невозможно перенести заказ на этот этап");
                                return;
                            }
                        }
                        else if (RadioButton.InFilial)
                        {
                            if (SelectedOrder.Status == "На таможенной проверке" || SelectedOrder.Status == "На почте")
                            {
                                SelectedOrder.Status = "На почте";
                            }
                            else
                            {
                                MessageBox.Show("Невозможно перенести заказ на этот этап");
                                return;
                            }
                        }
                        _context.SaveChanges();


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                });
        }

    }
}
