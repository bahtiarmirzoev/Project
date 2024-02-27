using GalaSoft.MvvmLight;
using Project.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Messages
{
    public class NavigationMessage
    {
        public ViewModelBase ViewModelType { get; set; }
    }
}
