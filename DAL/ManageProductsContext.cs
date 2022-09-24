using BOL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
//using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public partial class ManageProductsContext : DbContext
    {
        public ManageProductsContext()
        {
        }

        public ManageProductsContext(DbContextOptions<ManageProductsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-APDRFF2;Database=ManageProducts;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.CategoryId).ValueGeneratedNever();

                entity.Property(e => e.CategoryName).HasMaxLength(50);

                entity.Property(e => e.Subcategory).HasMaxLength(100);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Categories)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_Categories_Products");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ProductId).ValueGeneratedNever();

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ProductNumberCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.ProductCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Products_Users");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.ProductModifiedByNavigations)
                    .HasForeignKey(d => d.ModifiedBy)
                    .HasConstraintName("FK_Products_Users1");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.RoleId).ValueGeneratedNever();

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UserName).IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Users_Roles");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }

    //public class ApplicationDbContext :DbContext
    //{
    //    public ApplicationDbContext()
    //    {

    //    }

    //    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    //        : base(options)
    //    {

    //    }

    //    public DbSet<Category> Categories { get; set; }
    //    public DbSet<Product> Products { get; set; }
    //    public DbSet<User> Users { get; set; }
    //    public DbSet<Role> Roles { get; set; }



    //    protected override void OnModelCreating(ModelBuilder builder)
    //    {
    //        base.OnModelCreating(builder);

    //    }
    //}
}
