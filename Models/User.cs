using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace demoMVC.Model
{
  public class MyDbContext : DbContext
  {
    public DbSet<Users> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseMySQL("server=127.0.0.1;uid=root;pwd=24112111h;database=DemoMVc");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<Users>(entity =>
      {
        entity.HasKey(e => e.Id);
        entity.Property(e => e.Username);
        entity.Property(e => e.UserPwd);
      });

      // modelBuilder.Entity<Users>().;
    }

  }

  public class Users
  {
    public Users(int id, string username, string userPwd)
    {
      Id = id;
      Username = username;
      UserPwd = userPwd;
    }

    public int Id { set; get; }
    public string Username { set; get; }
    public string UserPwd { set; get; }
  }

}