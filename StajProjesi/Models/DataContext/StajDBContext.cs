using StajProjesi.Models.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StajProjesi.Models.DataContext
{
    public class StajDBContext:DbContext
    {
        public StajDBContext():base("StajDB")
        { 
        } 
        public DbSet<Users> Users { get; set; }
        public DbSet<Unvan> Unvan { get; set; }
        public DbSet<Proje> Proje { get; set; }

      
    }
}