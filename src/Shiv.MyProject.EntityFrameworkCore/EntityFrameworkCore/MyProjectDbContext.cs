using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Shiv.MyProject.Authorization.Roles;
using Shiv.MyProject.Authorization.Users;
using Shiv.MyProject.MultiTenancy;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Shiv.MyProject.EntityFrameworkCore
{
    public class MyProjectDbContext : AbpZeroDbContext<Tenant, Role, User, MyProjectDbContext>
    {
        /* Define a DbSet for each entity of the application */

        public MyProjectDbContext(DbContextOptions<MyProjectDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Countries>();
            modelBuilder.Entity<States>();
        }

        public virtual DbSet<States> Mystates { get; set; }
        public virtual DbSet<Countries> Mycountries { get; set; }


    }


    public class Countries
    {
        [Column("id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption
.Identity)]
        [Required]
        public int id { get; set; }
        [Column("country")]
        public string country { get; set; }
        public virtual List<States> cid { get; set; }
    }
    public class States
    {
        [Column("id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption
    .Identity)]
        [Required]
        public int id { get; set; }       
        public int Countriesid { get; set; }       
        [Required]
        [Column("state")]
        public string state { get; set; }
    }
}
