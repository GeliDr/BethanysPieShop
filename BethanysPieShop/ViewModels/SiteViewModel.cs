using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BethanysPieShop.Models;

namespace BethanysPieShop.ViewModels
{
    public class SiteViewModel
    {
        public List<SystemCode> SystemCodes { get; set; }
        public List<Site> Sites { get; set; }

        public String SelectedPropertyTypeValue { get; set; }
        public Guid SelectedPropertyTypeId { get; set; }
    }
}
