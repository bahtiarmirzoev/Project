using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trendyol.Models;

namespace Trendyol.Services.Classes
{
    public class SuperAdminService
    {
        private readonly TrendyolDbContext _context;

        public SuperAdminService(TrendyolDbContext context)
        {
            _context = context;
        }

        public bool SuperAdminLogin(string name, string password)
        {
            SuperAdmin superAdmin = _context.SuperAdmin.FirstOrDefault(a => a.Name == name);
            if (superAdmin != null)
            {
                return password == superAdmin.Password;
            }
            return false;
        }
    }
}
