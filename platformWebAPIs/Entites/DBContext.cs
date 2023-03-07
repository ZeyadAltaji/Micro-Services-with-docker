using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites
{
    public class DBContext :DbContext
    {
        public DBContext(DbContextOptions<DBContext> option) :base (option)
        {
        }
        public DbSet<Platfrom> platfroms { get; set; }
    }
}
