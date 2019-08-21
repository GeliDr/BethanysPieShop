using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShop.Models
{
    public interface ISiteRepository
    {
        IEnumerable<Site> GetAllSites();

        Site GetSiteById(Guid siteId);

        void Update(Site site);

        void Add(Site site);

    }
}
