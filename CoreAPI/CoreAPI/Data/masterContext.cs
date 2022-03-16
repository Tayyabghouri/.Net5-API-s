using System;
using CoreAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace CoreAPI.Data
{
    public partial class masterContext : DbContext
    {
        public masterContext()
        {
        }

        public masterContext(DbContextOptions<masterContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Module> Modules { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<StudentCourse> StudentCourses { get; set; }
        public virtual DbSet<WorkItem> WorkItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-IH7OORT\\SQLEXPRESS;Database=master; Trusted_Connection=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(e => e.CId)
                    .HasName("PK__Course__A9FDEC32CD615CC5");

                entity.ToTable("Course");

                entity.Property(e => e.CId).HasColumnName("C_Id");

                entity.Property(e => e.CName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("C_Name");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.DeptId)
                    .HasName("PK__Departme__72A8C6A4DB2D3079");

                entity.ToTable("Department");

                entity.Property(e => e.DeptId).HasColumnName("Dept_id");

                entity.Property(e => e.DeptDescription)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("Dept_description");

                entity.Property(e => e.DeptName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("Dept_name");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EId)
                    .HasName("PK__Employee__D7E94DAC57F9C98F");

                entity.ToTable("Employee");

                entity.Property(e => e.EId).HasColumnName("E_id");

                entity.Property(e => e.DepartmentId).HasColumnName("Department_id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("Full_Name");

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK__Employee__Depart__15702A09");
            });

            modelBuilder.Entity<Module>(entity =>
            {
                entity.HasKey(e => e.MId)
                    .HasName("PK__Module__18B1A317C14EFD32");

                entity.ToTable("Module");

                entity.Property(e => e.MId).HasColumnName("M_ID");

                entity.Property(e => e.MDescription)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("M_Description");

                entity.Property(e => e.MName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("M_Name");

                entity.Property(e => e.WId).HasColumnName("W_id");

                entity.HasOne(d => d.WIdNavigation)
                    .WithMany(p => p.Modules)
                    .HasForeignKey(d => d.WId)
                    .HasConstraintName("FK__Module__W_id__2882FE7D");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.HasKey(e => e.PId)
                    .HasName("PK__Project__A3420A57BED4A167");

                entity.ToTable("Project");

                entity.Property(e => e.PId).HasColumnName("P_Id");

                entity.Property(e => e.MId).HasColumnName("M_id");

                entity.Property(e => e.PDescription)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("P_Description");

                entity.Property(e => e.PName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("P_Name");

                entity.HasOne(d => d.MIdNavigation)
                    .WithMany(p => p.Projects)
                    .HasForeignKey(d => d.MId)
                    .HasConstraintName("FK__Project__M_id__2B5F6B28");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.SId)
                    .HasName("PK__Student__A3DFF08D9101228F");

                entity.ToTable("Student");

                entity.Property(e => e.SId).HasColumnName("S_Id");

                entity.Property(e => e.SName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("S_Name");
            });

            modelBuilder.Entity<StudentCourse>(entity =>
            {
                entity.HasKey(e => e.ScId)
                    .HasName("PK__Student___C402E57EFF84240A");

                entity.ToTable("Student_Course");

                entity.Property(e => e.ScId).HasColumnName("SC_Id");

                entity.Property(e => e.CId).HasColumnName("C_id");

                entity.Property(e => e.SId).HasColumnName("S_id");

                entity.HasOne(d => d.CIdNavigation)
                    .WithMany(p => p.StudentCourses)
                    .HasForeignKey(d => d.CId)
                    .HasConstraintName("FK__Student_Co__C_id__33008CF0");

                entity.HasOne(d => d.SIdNavigation)
                    .WithMany(p => p.StudentCourses)
                    .HasForeignKey(d => d.SId)
                    .HasConstraintName("FK__Student_Co__S_id__320C68B7");
            });

            modelBuilder.Entity<WorkItem>(entity =>
            {
                entity.HasKey(e => e.WId)
                    .HasName("PK__WorkItem__8175B513EF0BADE5");

                entity.ToTable("WorkItem");

                entity.Property(e => e.WId).HasColumnName("W_Id");

                entity.Property(e => e.EId).HasColumnName("E_id");

                entity.Property(e => e.WDescription)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("W_description");

                entity.Property(e => e.WName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("W_Name");

                entity.HasOne(d => d.EIdNavigation)
                    .WithMany(p => p.WorkItems)
                    .HasForeignKey(d => d.EId)
                    .HasConstraintName("FK__WorkItem__E_id__25A691D2");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
