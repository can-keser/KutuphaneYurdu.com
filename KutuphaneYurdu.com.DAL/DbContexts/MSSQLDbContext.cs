using Microsoft.EntityFrameworkCore;
using KutuphaneYurdu.com.DAL.Entities;
using System;


namespace KutuphaneYurdu.com.DAL.DbContexts
{
    public class MSSQLDbContext:DbContext
    {

        public MSSQLDbContext(DbContextOptions<MSSQLDbContext> opt) : base(opt) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>().HasData(new Admin
            {
                ID = 1,
                LastDate = DateTime.Now,
                LastIPNO = "",
                Name = "Can",
                Surname = "Keser",
                UserName = "can",
                Password = "202cb962ac59075b964b07152d234b70"

            });
            modelBuilder.Entity<Book>().HasOne(ho => ho.Category).WithMany(wm => wm.Books).OnDelete(DeleteBehavior.SetNull);
            
        }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Book> Book { get; set; }
        public DbSet<Writer> Writer { get; set; }
        public DbSet<Blog> Blog { get; set; }
        

    }
}
