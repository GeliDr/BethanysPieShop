using BethanysPieShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShop.ViewModels
{
    public class AddSiteViewModel
    {
        public List<SystemCode> SystemCodes { get; set; }
        public Site Site { get; set; }
    }
}
