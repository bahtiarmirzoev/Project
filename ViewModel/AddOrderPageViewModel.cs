using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
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
    public class AddOrderPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly TrendyolDbContext _context;
        private readonly CurrentUserService _currentUserService;
        private readonly AddOrderService _addOrderService;
        private readonly Products _product;
        private string _name;
        private string _description;
        private double _price;
        private int _count;

        public string Name
        {
            get => _name;
            set => Set(ref _name, value);
        }

        public string Description
        {
            get => _description;
            set => Set(ref _description, value);
        }


        public int Count
        {
            get => _count;
            set => Set(ref _count, value);
        }

        public AddOrderPageViewModel(INavigationService navigationService, TrendyolDbContext context, CurrentUserService currentUserService)
        {
            _navigationService = navigationService;
            _context = context;
            _currentUserService = currentUserService;
            _addOrderService = new AddOrderService(_context);
            _product = new Products();
        }

        public RelayCommand Back
        {
            get => new(
                () =>
                {
                    _navigationService.NavigateTo<AdminPageViewModel>();
                });
        }

        public RelayCommand Add
        {
            get => new(
                () =>
                {
                    try
                    {
                        var product = _addOrderService.AddProductOrder(Name, Description, Count);
                        if (product != null)
                        {
                            _context.Products.Add(product);
                            _context.SaveChanges();
                            WareHouse ware = new WareHouse()
                            {
                                ProductId = product.Id,
                                ProductCount = product.Count,
                                Name = product.Name,
                            };
                            _context.WareHouse.Add(ware);
                            _context.SaveChanges();
                            Name = "";
                            Description = "";
                            Count = 0;
                            MessageBox.Show("Успешно");
                            _navigationService.NavigateTo<AdminPageViewModel>();
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
