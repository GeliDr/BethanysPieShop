using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShop.Models
{
    public interface ISystemCodeRepository
    {
        IEnumerable<SystemCode> GetAllSystemCodes();

        SystemCode GetSystemCodeById(Guid systemCodeId);
    }
}
