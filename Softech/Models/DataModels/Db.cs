using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Data.Entity;

namespace Softech.Models.DataModels
{
    public class Db : DbContext     
    {
        public DbSet<AccountDTO> Account { get; set; }
        public DbSet<RolesDTO> Role { get; set; }
        public DbSet<UserRolesDTO> UserRoles { get; set; }
    }
}