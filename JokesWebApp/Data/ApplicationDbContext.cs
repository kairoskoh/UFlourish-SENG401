using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using JokesWebApp.Models;

namespace JokesWebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<JokesWebApp.Models.Joke> Joke { get; set; }

        public DbSet<JokesWebApp.Models.Request_Mental_Health> Request_Mental_Health { get; set; }
    

        public DbSet<JokesWebApp.Models.UserBasicInfo> UserBasicInfoes { get; set; }
        public DbSet<JokesWebApp.Models.UserInsurance> UserInsurance { get; set; }
        public DbSet<JokesWebApp.Models.UserPayment> UserPayment { get; set; }

    }
}
