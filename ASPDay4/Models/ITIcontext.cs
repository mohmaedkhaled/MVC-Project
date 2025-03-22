using System;
using System.Data.Entity;
using System.Linq;

namespace ASPDay4.Models
{
    public class ITIcontext : DbContext
    {
        // Your context has been configured to use a 'ITIcontext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'ASPDay4.Models.ITIcontext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'ITIcontext' 
        // connection string in the application configuration file.
        public ITIcontext()
            : base("name=iticon")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

         public virtual DbSet<news> News { get; set; }
         public virtual DbSet<user> Users { get; set; }
        public virtual DbSet<catalog> Catalogs { get; set; }
        public virtual DbSet<department> Departments { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    //modelBuilder.
        //}
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}