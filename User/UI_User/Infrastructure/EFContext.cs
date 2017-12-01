using Domain_User.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace UI_User.Infrastructure {
    public class EFContext : DbContext {
        public EFContext() : base("User") { }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}