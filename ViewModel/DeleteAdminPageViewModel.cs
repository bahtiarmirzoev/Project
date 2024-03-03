using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Project.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Trendyol.Models;
using Trendyol.Services.Classes;

namespace Project.ViewModel
{
    public class DeleteAdminPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private TrendyolDbContext _context;
        private ObservableCollection<Admin> _admin;
        private Admin _selectedAdmin;

        public ObservableCollection<Admin> Admin
        {
            get => _admin;
            set => Set(ref _admin, value);
        }

        public Admin SelectedAdmin
        {
            get => _selectedAdmin;
            set => Set(ref _selectedAdmin, value);
        }

        public DeleteAdminPageViewModel(INavigationService navigationService, TrendyolDbContext context)
        {
            _navigationService = navigationService;
            _context = context;
            Admin = new ObservableCollection<Admin>(_context.Admin);

        }

        public RelayCommand Back
        {
            get => new(
                () =>
                {
                    _navigationService.NavigateTo<SuperAdminViewModel>();
                });
        }

        public RelayCommand Delete
        {
            get => new(() =>
            {
                try
                {
                    if (SelectedAdmin == null)
                    {
                        MessageBox.Show("You don't select administrator");
                        return;
                    }
                    else
                    {
                        var admin = _context.Admin.FirstOrDefault(a => a.Name == _selectedAdmin.Name);
                        if (admin != null)
                        {
                            _context.Admin.Remove(admin);
                            _context.SaveChanges();
                            Admin.Remove(admin);
                            MessageBox.Show("Deleted succesfuly");
                            _navigationService.NavigateTo<SuperAdminViewModel>();
                        }
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