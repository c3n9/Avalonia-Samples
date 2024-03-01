using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ChitChat.Models;

public partial class ChitChatContext : DbContext
{
    public ChitChatContext()
    {
    }

    public ChitChatContext(DbContextOptions<ChitChatContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ChatMessage> ChatMessages { get; set; }

    public virtual DbSet<Chatroom> Chatrooms { get; set; }

    public virtual DbSet<ChatroomEmployee> ChatroomEmployees { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=127.0.0.1;Username=postgres;Password=1;Database=ChitChat");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ChatMessage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("ChatMessage_pkey");

            entity.ToTable("ChatMessage");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Message).HasMaxLength(500);

            entity.HasOne(d => d.Sender).WithMany(p => p.ChatMessages)
                .HasForeignKey(d => d.SenderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_employee");
        });

        modelBuilder.Entity<Chatroom>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Chatroom_pkey");

            entity.ToTable("Chatroom");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.Topic).HasMaxLength(100);
        });

        modelBuilder.Entity<ChatroomEmployee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("ChatroomEmployee_pkey");

            entity.ToTable("ChatroomEmployee");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();

            entity.HasOne(d => d.Chatroom).WithMany(p => p.ChatroomEmployees)
                .HasForeignKey(d => d.ChatroomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Chatroom");

            entity.HasOne(d => d.Employee).WithMany(p => p.ChatroomEmployees)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_employee");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Department_pkey");

            entity.ToTable("Department");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Employee_pkey");

            entity.ToTable("Employee");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(100);
            entity.Property(e => e.UserName).HasMaxLength(100);

            entity.HasOne(d => d.Department).WithMany(p => p.Employees)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK_department");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
