using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShop.Models
{
    public class SystemCode
    {
        public Guid SystemCodeId { get; set; }
        public String Code { get; set; }
        public String Value { get; set; }

        public Int32 SystemTableId { get; set; }

        public Guid ApplicationId { get; set; }
        //public List<Site> Sites { get; set; }
    }
}
