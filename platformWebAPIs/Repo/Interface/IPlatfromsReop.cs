using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo.Interface
{
    public interface IPlatfromsReop
    {
        bool SaveChanges();

        IEnumerable<Platfrom> GetAllPlatforms();
        Platfrom GetPlatformById(int id);
        void CreatePlatform(Platfrom plat);
    }
}
