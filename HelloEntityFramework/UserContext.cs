using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace HelloEntityFramework
{
    class UserContext : DbContext
    {
        public UserContext() 
            : base("DbConnection")
        {}

        public DbSet<User> Users { get; set; }
    }
}
