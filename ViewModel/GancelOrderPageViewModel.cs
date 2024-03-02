using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.EntityFrameworkCore;
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
    public class GancelOrderPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly TrendyolDbContext _context;
        private ObservableCollection<Order> _order;
        private readonly CurrentUserService _currentUserService;
        private Order _selectedOrder;

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

        public GancelOrderPageViewModel(INavigationService navigationService, TrendyolDbContext context, CurrentUserService currentUserService)
        {
            _navigationService = navigationService;
            _currentUserService = currentUserService;
            _context = context;
            Order = new ObservableCollection<Order>(_context.Orders.Where(o => o.UserId == _currentUserService.UserId));
        }

        public RelayCommand Back
        {
            get => new(
                () =>
                {
                    _navigationService.NavigateTo<HomePageViewModel>();
                });
        }

        public RelayCommand Gancel
        {
            get => new(
                () =>
                {
                    try
                    {
                        if (SelectedOrder == null)
                        {
                            MessageBox.Show("Выберите заказ");
                        }
                        else
                        {
                            Order order = _context.Orders.FirstOrDefault(o => o.Product == _selectedOrder.Product);
                            if (order != null)
                            {
                                if (_selectedOrder.Status == "Заказ сделан")
                                {
                                    _context.Orders.Remove(order);
                                    _context.SaveChanges();
                                    Order.Remove(order);
                                    MessageBox.Show("Успешно удалено");
                                    SelectedOrder = null;
                                }
                                else
                                {
                                    MessageBox.Show("Невозможно отменить заказ, т.к он уже выехал и напрявляется к службе доставки", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                                    return;
                                }
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
