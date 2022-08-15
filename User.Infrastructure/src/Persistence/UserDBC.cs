using User.Core.src.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace User.Infrastructure.src.Persistence
{
    public class UserDBC : DbContext
    {
        public UserDBC(DbContextOptions<UserDBC> options) : base(options)
        {
        }
        
        public DbSet<UserEntity> Users { get; set; }
        
    }
}