using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
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
    public class AddOrderUserPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly TrendyolDbContext _context;
        private ObservableCollection<Products> _products;
        private Products _selectedProducts;

        public ObservableCollection<Products> Product
        {
            get => _products;
            set => Set(ref _products, value);
        }

        public Products SelectedProduct
        {
            get => _selectedProducts;
            set
            {
                if (Set(ref _selectedProducts, value))
                {
                    Messenger.Default.Send(value.Name, "SelectedProductName");
                }
            }
        }

        public AddOrderUserPageViewModel(INavigationService navigationService, TrendyolDbContext context)
        {
            _navigationService = navigationService;
            _context = context;
            Product = new ObservableCollection<Products>(_context.Products);
            MessengerInstance.Register<Products>(this, "SelectedProductName", SetSelectedProductName);
        }

        private void SetSelectedProductName(Products selectedProduct)
        {
            SelectedProduct = selectedProduct;
        }

        public RelayCommand Back
        {
            get => new(
                () =>
                {
                    _navigationService.NavigateTo<HomePageViewModel>();
                });
        }

        public RelayCommand Add
        {
            get => new(
                () =>
                {
                    try
                    {
                        if (SelectedProduct != null)
                        {
                            Messenger.Default.Send(SelectedProduct, "SelectedProductForOrder");
                            _navigationService.NavigateTo<ProductCountPageViewModel>();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                });
        }
    }
}
