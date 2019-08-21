using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShop.Models
{
    public class SystemCodeRepository : ISystemCodeRepository
    {
        private readonly AppDbContext _appDbContext;
        public SystemCodeRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<SystemCode> GetAllSystemCodes()
        {
            return _appDbContext.SystemCodes;
        }

        public SystemCode GetSystemCodeById(Guid systemCodeId)
        {
            return _appDbContext.SystemCodes.Where(p => p.SystemCodeId == systemCodeId).FirstOrDefault();
        }
    }
}
