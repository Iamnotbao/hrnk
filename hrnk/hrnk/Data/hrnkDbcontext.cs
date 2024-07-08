using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using hrnk.Models;

namespace hrnk.Data
{
    public class hrnkDbcontext : DbContext
    {
        public hrnkDbcontext (DbContextOptions<hrnkDbcontext> options)
            : base(options)
        {
        }
        public DbSet<hrnk.Models.Role> Roles { get; set; } = default!;
        public DbSet<hrnk.Models.User> User { get; set; } = default!;
    }

}
