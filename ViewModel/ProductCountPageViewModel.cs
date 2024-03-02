using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Project.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Trendyol.Models;
using Trendyol.Services.Classes;

namespace Project.ViewModel
{
    public class ProductCountPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly TrendyolDbContext _context;
        private readonly CurrentUserService _currentUserService;
        private Products _selectedProduct;
        private int _count;
        private string _product;

        public int Count
        {
            get => _count;
            set => Set(ref _count, value);
        }

        public string Product
        {
            get => _product;
            set => Set(ref _product, value);
        }

        public Products SelectedProduct
        {
            get => _selectedProduct;
            set => Set(ref _selectedProduct, value);
        }


        public ProductCountPageViewModel(INavigationService navigationService, TrendyolDbContext context, CurrentUserService currentUserService)
        {
            _navigationService = navigationService;
            _context = context;
            _currentUserService = currentUserService;
            _selectedProduct = new Products();
            Messenger.Default.Register<string>(this, "SelectedProductName", SetSelectedProductName);
            Messenger.Default.Register<int>(this, "SelectedProductCount", SetSelectedProductCount);
            Messenger.Default.Register<Products>(this, "SelectedProductForOrder", SetSelectedProduct);
        }

        private void SetSelectedProductCount(int count)
        {
            Count = count;
        }

        private void SetSelectedProductName(string productName)
        {
            Product = productName;
        }

        private void SetSelectedProduct(Products selectedProduct)
        {
            SelectedProduct = selectedProduct;
            _selectedProduct = selectedProduct;
        }

        public RelayCommand Back
        {
            get => new(
                () =>
                {
                    _navigationService.NavigateTo<AddOrderUserPageViewModel>();
                });
        }

        public RelayCommand AddOrder
        {
            get => new(
                () =>
                {
                    try
                    {
                        if (_selectedProduct != null)
                        {
                            var wareHouseProduct = _context.WareHouse.FirstOrDefault(p => p.ProductId == _selectedProduct.Id);
                            if (wareHouseProduct != null)
                            {
                                if (wareHouseProduct.ProductCount < Count)
                                {
                                    MessageBox.Show("На складе отсутствует столько количество этого товара.");
                                    Count = 0;
                                    _navigationService.NavigateTo<AddOrderUserPageViewModel>();
                                    return;
                                }

                                else if (Count == 0)
                                {
                                    MessageBox.Show("Напишите количество товара", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                                    Count = 0;
                                    return;
                                }
                            }
                            Order order = new Order
                            {
                                UserId = _currentUserService.UserId,
                                Product = _selectedProduct.Name,
                                ProductsCount = Count,
                                ProductId = _selectedProduct.Id,
                                Status = "Заказ сделан",
                                Created = DateTime.Now,
                            };
                            _context.Orders.Add(order);
                            _context.SaveChanges();

                            wareHouseProduct.ProductCount -= Count;
                            _context.SaveChanges();

                            _selectedProduct.Count -= Count;
                            _context.SaveChanges();

                            MessageBox.Show("Товар успешно куплен. Вы можете следить за статусом во вкладке \"История заказов\"");
                            Count = 0;
                            _navigationService.NavigateTo<HomePageViewModel>();

                        }
                        else
                        {
                            MessageBox.Show("Ошибка при покупке товара");
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                });
        }



    }
}
