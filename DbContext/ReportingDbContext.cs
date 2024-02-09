using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RMM.Common;
using RMM.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RMM.DbContext
{
    public class ReportingDbContext: IdentityDbContext<ApplicationUser>
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public ReportingDbContext(DbContextOptions<ReportingDbContext> options) : base(options)
        {
           
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Attachement> Attachements { get; set; }
        public DbSet<Departement> Departements { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Reporting> Reportings { get; set; }
        public DbSet<TypeProduct> Types { get; set; }
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            var UserName = this.httpContextAccessor?.HttpContext.User.Identity.Name ?? "Mansouri";
            foreach (var item in ChangeTracker.Entries<EntityBase>())
            {
                switch (item.State)
                {
                    case EntityState.Added:
                        item.Entity.CreatedDate = DateTime.Now;
                        item.Entity.CreatedBy = UserName;
                        break;

                    case EntityState.Modified:
                        item.Entity.LastModifiedDate = DateTime.Now;
                        item.Entity.CreatedBy = UserName;
                        break;
                }

            }
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(System.Reflection.Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

    }
}
