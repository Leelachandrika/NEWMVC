using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace CargoManagement
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model11")
        {
        }

        public virtual DbSet<bookingCargo> bookingCargos { get; set; }
        //public virtual DbSet<cargoOrder> cargoOrders { get; set; }
        public virtual DbSet<city> cities { get; set; }
        public virtual DbSet<customer> customers { get; set; }
        public virtual DbSet<employee> employees { get; set; }
        public virtual DbSet<gatePass> gatePasses { get; set; }
        public virtual DbSet<Login> Logins { get; set; }
        public virtual DbSet<product> products { get; set; }
        public virtual DbSet<RoleMaster> RoleMasters { get; set; }
        public virtual DbSet<UserRolesMapping> UserRolesMappings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<bookingCargo>()
                .Property(e => e.quantity)
                .IsUnicode(false);
           /* modelBuilder.Entity<cargoOrder>()
               .Property(e => e.quantity)
               .IsUnicode(false);*/

            modelBuilder.Entity<city>()
                .Property(e => e.state)
                .IsUnicode(false);

            modelBuilder.Entity<city>()
                .Property(e => e.country)
                .IsUnicode(false);

            modelBuilder.Entity<city>()
                .Property(e => e.pincode)
                .IsUnicode(false);

            modelBuilder.Entity<city>()
                .Property(e => e.city_name)
                .IsUnicode(false);

            modelBuilder.Entity<customer>()
                .Property(e => e.customer_name)
                .IsUnicode(false);

            modelBuilder.Entity<customer>()
                .Property(e => e.customer_address)
                .IsUnicode(false);

            modelBuilder.Entity<customer>()
                .Property(e => e.customer_mobile)
                .IsUnicode(false);

            modelBuilder.Entity<customer>()
                .Property(e => e.customer_email)
                .IsUnicode(false);

            modelBuilder.Entity<customer>()
                .Property(e => e.activestatus)
                .IsUnicode(false);

            modelBuilder.Entity<employee>()
                .Property(e => e.emp_name)
                .IsUnicode(false);

            modelBuilder.Entity<employee>()
                .Property(e => e.emp_department)
                .IsUnicode(false);

            modelBuilder.Entity<employee>()
                .Property(e => e.emp_mobile)
                .IsUnicode(false);

            modelBuilder.Entity<employee>()
                .Property(e => e.activestatus)
                .IsUnicode(false);

            modelBuilder.Entity<Login>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<Login>()
                .Property(e => e.UserPassword)
                .IsUnicode(false);

            modelBuilder.Entity<Login>()
                .HasMany(e => e.UserRolesMappings)
                .WithRequired(e => e.Login)
                .HasForeignKey(e => e.UserID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<product>()
                .Property(e => e.product_name)
                .IsUnicode(false);

            modelBuilder.Entity<product>()
                .Property(e => e.product_type)
                .IsUnicode(false);

            modelBuilder.Entity<RoleMaster>()
                .Property(e => e.RollName)
                .IsUnicode(false);

            modelBuilder.Entity<RoleMaster>()
                .HasMany(e => e.UserRolesMappings)
                .WithRequired(e => e.RoleMaster)
                .HasForeignKey(e => e.RoleID)
                .WillCascadeOnDelete(false);
        }
    }
}
