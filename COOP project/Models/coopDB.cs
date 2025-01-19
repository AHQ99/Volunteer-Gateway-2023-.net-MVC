using Microsoft.EntityFrameworkCore;


namespace COOP_project.Models
{
    public class coopDB : DbContext
    {
       

            public coopDB(DbContextOptions<coopDB> options)
                : base(options)
            {
            }


            public virtual DbSet<User> Users { get; set; }
            public virtual DbSet<volunteerWork> VolunteerWorks { get; set; }
            public virtual DbSet<Order> Orders  { get; set; }
            public virtual DbSet<Role> Roles { get; set; }
            public virtual DbSet<Student> Students { get; set; }
            public virtual DbSet<Major> Majors { get; set; }
            public virtual DbSet<Building> Buildings { get; set; } 
    }
}
