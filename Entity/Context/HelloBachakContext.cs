
namespace Entity.Context;
using Entity.Models;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore;

public class HelloBachakContext : DbContext
{
    public HelloBachakContext(DbContextOptions options) : base(options)
    {
    }

    public virtual DbSet<Sex> Sexes { get; set; }
    public virtual DbSet<Grade> Grades { get; set; }
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Lesson> Lessons{ get; set; }
    public virtual DbSet<Task> Tasks { get; set; }
    public virtual DbSet<TaskReply> TaskReplies { get; set; }

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
            entity.HasMany(a=>a.Tasks).WithOne(a=>a.Lesson).HasForeignKey(a=> a.LessonId).IsRequired();
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
        });
        modelBuilder.Entity<Task>(entity=> {
            entity.ToTable("Task");

            entity.HasKey(a=> a.Id);
            entity.Property(a=> a.Title).IsRequired().HasMaxLength(200);
            entity.HasOne(a=> a.Lesson).WithMany(a=>a.Tasks).HasForeignKey(a=> a.LessonId).IsRequired();
            entity.HasOne(a=> a.OlderTask).WithOne(a=> a.NewTask).HasForeignKey<Task>(a=> a.OlderTaskId).IsRequired(false);
            entity.HasOne(a=> a.TaskReply).WithOne(a=> a.Task).HasForeignKey<TaskReply>(a=> a.TaskId).IsRequired(false);
        });
        modelBuilder.Entity<TaskReply>(entity => {
            entity.ToTable("TaskReply");

            entity.HasKey(a=> a.TaskId);

        });
    }
}
