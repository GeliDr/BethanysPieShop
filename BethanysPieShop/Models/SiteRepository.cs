using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShop.Models
{
    public class SiteRepository : ISiteRepository
    {
        private readonly AppDbContext _appDbContext;

        public SiteRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Site> GetAllSites()
        {
            return _appDbContext.Sites;
        }

        public Site GetSiteById(Guid siteId)
        {
            return _appDbContext.Sites.FirstOrDefault(p => p.SiteId == siteId);
        }

        public void Update(Site site)
        {
            _appDbContext.Update(site);
            _appDbContext.SaveChanges(); 
        }

        public void Add(Site site)
        {
            _appDbContext.Add(site);
            _appDbContext.SaveChanges();
        }
    }
}
