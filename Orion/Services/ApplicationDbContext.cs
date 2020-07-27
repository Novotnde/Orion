using Microsoft.AspNet.Identity.EntityFramework;
using Orion.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Orion.Services
{
    
        public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
        {
            public DbSet<Customer> Customers { get; set; }
            public DbSet<Book> Book { get; set; }
            public DbSet<MembershipType> MembershipTypes { get; set; }
            public DbSet<Genre> Genre { get; set; }

            public DbSet<Rental> Rental { get; set; }
            public ApplicationDbContext()
                : base("DefaultConnection", throwIfV1Schema: false)
            {
            }

            public static ApplicationDbContext Create()
            {
                return new ApplicationDbContext();
            }
        }
   
}