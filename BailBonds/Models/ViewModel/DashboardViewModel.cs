using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BailBonds.Models.ViewModel
{
    public class DashboardViewModel
    {
        public List<BondsUser> Users { get; set; }
        public List<Client> Clients { get; set; }
        public string CurrentImage { get; set; }
        
    }
}
