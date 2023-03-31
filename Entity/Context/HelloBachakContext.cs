
namespace Entity.Context;
using Entity.Models;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore;

public class HelloBachakContext : DbContext
{
    public HelloBachakContext(DbContextOptions options) : base(options)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior" , true);
        
    }

    public virtual DbSet<Sex> Sexes { get; set; }
    public virtual DbSet<Role>Roles { get; set; }
    public virtual DbSet<Grade> Grades { get; set; }
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Lesson> Lessons{ get; set; }
    public virtual DbSet<Entity.Models.Duty> Duties { get; set; }
    public virtual DbSet<DutyReply> DutyReplies { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder){
        modelBuilder.Entity<Sex>(entity => {
            entity.ToTable("Sex");

            entity.HasKey(a=> a.Id);
            entity.HasMany(a=> a.Users).WithOne(a=> a.Sex).HasForeignKey(a=> a.SexId).IsRequired();
            entity.Property(a=> a.Title).IsRequired().HasMaxLength(50);
        });
        modelBuilder.Entity<Grade>(entity=>{
            entity.ToTable("Grade");

            entity.HasKey(a=>a.Id);
            entity.HasMany(a=>a.Users).WithOne(a=>a.Grade).HasForeignKey(a=> a.GradeId).IsRequired();
            entity.Property(a=> a.Title).IsRequired().HasMaxLength(50);
        });
        modelBuilder.Entity<Lesson>(entity=>{
            entity.ToTable("Lesson");
            entity.HasKey(a=>a.Id);
            entity.HasMany(a=>a.Duties).WithOne(a=>a.Lesson).HasForeignKey(a=> a.LessonId).IsRequired();
            entity.Property(a=> a.Title).IsRequired().HasMaxLength(50);
        });
        modelBuilder.Entity<Role>(entity => {
            entity.ToTable("Role");
            entity.HasKey(a=> a.Id);
            entity.HasMany(a=> a.Users).WithOne(a=> a.Role).HasForeignKey(a=> a.RoleId).IsRequired();
            entity.Property(a=> a.Title).IsRequired().HasMaxLength(50);
        });
        modelBuilder.Entity<User>(entity=> {
            entity.ToTable("User");
            entity.HasKey(a=> a.Id);
            entity.HasOne(a=> a.Grade).WithMany(a=> a.Users).HasForeignKey(a=> a.GradeId).IsRequired();
            entity.HasOne(a=> a.Sex).WithMany(a=> a.Users).HasForeignKey(a=> a.SexId).IsRequired();
            entity.Property(a=> a.Email).IsRequired().HasMaxLength(320);
            entity.Property(a=> a.Password).IsRequired().HasMaxLength(100);
            entity.Property(a=> a.Username).IsRequired().HasMaxLength(50);
            entity.Property(a=> a.PhoneNumber).IsRequired().HasMaxLength(50);
            entity.Property(a=> a.Description).IsRequired(false);
            entity.Property(a => a.RefreshToken).IsRequired(false);
        });
        modelBuilder.Entity<Entity.Models.Duty>(entity=> {
            entity.ToTable("Duty");

            entity.HasKey(a=> a.Id);
            entity.Property(a=> a.Title).IsRequired().HasMaxLength(200);
            entity.HasOne(a=> a.Lesson).WithMany(a=>a.Duties).HasForeignKey(a=> a.LessonId).IsRequired();
            entity.HasOne(a=> a.OlderDuty).WithOne(a=> a.NewDuty).HasForeignKey<Entity.Models.Duty>(a=> a.OlderDutyId).IsRequired(false);
            entity.HasOne(a=> a.DutyReply).WithOne(a=> a.Duty).HasForeignKey<DutyReply>(a=> a.DutyId).IsRequired(false);
        });
        modelBuilder.Entity<DutyReply>(entity => {
            entity.ToTable("DutyReply");

            entity.HasKey(a=> a.DutyId);

        });
    }
}
