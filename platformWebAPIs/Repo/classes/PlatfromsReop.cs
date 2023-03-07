using Entites;
using Microsoft.EntityFrameworkCore;
using Models;
using Repo.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo.classes
{
    public class PlatfromsReop:IPlatfromsReop
    {
        private readonly DBContext dc;
        public PlatfromsReop(DBContext dc)
        {
            this.dc = dc;
        }

        public void CreatePlatform(Platfrom plat)
        {
            if (plat == null)
            {
                throw new ArgumentNullException(nameof(plat));
            }

            dc.platfroms.Add(plat);
        }

        public IEnumerable<Platfrom> GetAllPlatforms()
        {
            return dc.platfroms.ToList();
        }

        public Platfrom GetPlatformById(int id)
        {
            return dc.platfroms.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (dc.SaveChanges() >= 0);
        }
    }
}
