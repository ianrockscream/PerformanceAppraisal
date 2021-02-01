using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PerformanceAppraisal.Entities.model
{
    public partial class perfappraisalContext : DbContext
    {
        public perfappraisalContext()
        {
        }

        public perfappraisalContext(DbContextOptions<perfappraisalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<Adminlog> Adminlog { get; set; }
        public virtual DbSet<Businessobjective> Businessobjective { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Developmentplan> Developmentplan { get; set; }
        public virtual DbSet<Documenthistory> Documenthistory { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Globalbehavior> Globalbehavior { get; set; }
        public virtual DbSet<Mobilitycode> Mobilitycode { get; set; }
        public virtual DbSet<Performanceappraisal> Performanceappraisal { get; set; }
        public virtual DbSet<Position> Position { get; set; }
        public virtual DbSet<Statuscode> Statuscode { get; set; }
        public virtual DbSet<Subdepartment> Subdepartment { get; set; }
        public virtual DbSet<Userlog> Userlog { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=localhost;database=perfappraisal;user id=root;password=Kcm12345.", x => x.ServerVersion("8.0.22-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.ToTable("admin");

                entity.Property(e => e.Createdate)
                    .HasColumnName("createdate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Loginname)
                    .HasColumnName("loginname")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasColumnType("varchar(500)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Updatedate)
                    .HasColumnName("updatedate")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Adminlog>(entity =>
            {
                entity.ToTable("adminlog");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Createdate)
                    .HasColumnName("createdate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("varchar(500)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Businessobjective>(entity =>
            {
                entity.ToTable("businessobjective");

                entity.HasIndex(e => e.Performanceappraisalid)
                    .HasName("perfappbo_idx");

                entity.HasIndex(e => new { e.Id, e.Createdate })
                    .HasName("bo_idx");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Createdate)
                    .HasColumnName("createdate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Employeescore).HasColumnName("employeescore");

                entity.Property(e => e.Goalachievement)
                    .HasColumnName("goalachievement")
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Managerscore).HasColumnName("managerscore");

                entity.Property(e => e.Performanceappraisalid).HasColumnName("performanceappraisalid");

                entity.Property(e => e.Weight).HasColumnName("weight");

                entity.HasOne(d => d.Performanceappraisal)
                    .WithMany(p => p.Businessobjective)
                    .HasForeignKey(d => d.Performanceappraisalid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("perfappbo");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("department");

                entity.HasIndex(e => new { e.Id, e.Name, e.Description })
                    .HasName("departmentindex");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Createdate)
                    .HasColumnName("createdate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Updatedate)
                    .HasColumnName("updatedate")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Developmentplan>(entity =>
            {
                entity.ToTable("developmentplan");

                entity.HasIndex(e => e.Performanceappraisalid)
                    .HasName("perfappdevplan_idx");

                entity.HasIndex(e => new { e.Id, e.Createdate })
                    .HasName("devplan_idx");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Createdate)
                    .HasColumnName("createdate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Developmentarea)
                    .HasColumnName("developmentarea")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Methods)
                    .HasColumnName("methods")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Performanceappraisalid).HasColumnName("performanceappraisalid");

                entity.Property(e => e.Plan)
                    .HasColumnName("plan")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Strengtharea)
                    .HasColumnName("strengtharea")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Updatedate)
                    .HasColumnName("updatedate")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Performanceappraisal)
                    .WithMany(p => p.Developmentplan)
                    .HasForeignKey(d => d.Performanceappraisalid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("perfappdevplan");
            });

            modelBuilder.Entity<Documenthistory>(entity =>
            {
                entity.ToTable("documenthistory");

                entity.HasIndex(e => e.Employeeid)
                    .HasName("employeedochistory_idx");

                entity.HasIndex(e => e.Performanceappraisalid)
                    .HasName("perfappdochistory_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Changelog)
                    .HasColumnName("changelog")
                    .HasColumnType("varchar(500)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Createdate)
                    .HasColumnName("createdate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Employeeid).HasColumnName("employeeid");

                entity.Property(e => e.Performanceappraisalid).HasColumnName("performanceappraisalid");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Documenthistory)
                    .HasForeignKey(d => d.Employeeid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("employeedochistory");

                entity.HasOne(d => d.Performanceappraisal)
                    .WithMany(p => p.Documenthistory)
                    .HasForeignKey(d => d.Performanceappraisalid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("perfappdochistory");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("employee");

                entity.HasIndex(e => e.DepartmentId)
                    .HasName("departmentemployee_idx");

                entity.HasIndex(e => e.PositionId)
                    .HasName("positionemployee_idx");

                entity.HasIndex(e => e.SubdepartmentId)
                    .HasName("subdepartemployee_idx");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Createdate)
                    .HasColumnName("createdate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DepartmentId).HasColumnName("departmentId");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Nik)
                    .IsRequired()
                    .HasColumnName("nik")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.PositionId).HasColumnName("positionId");

                entity.Property(e => e.SubdepartmentId).HasColumnName("subdepartmentId");

                entity.Property(e => e.Updatedate)
                    .HasColumnName("updatedate")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("departmentemployee");

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.PositionId)
                    .HasConstraintName("positionemployee");

                entity.HasOne(d => d.Subdepartment)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.SubdepartmentId)
                    .HasConstraintName("subdepartemployee");
            });

            modelBuilder.Entity<Globalbehavior>(entity =>
            {
                entity.ToTable("globalbehavior");

                entity.HasIndex(e => e.Performanceappraisalid)
                    .HasName("perfappgb_idx");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Createdate)
                    .HasColumnName("createdate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Demonstratedbehavior)
                    .HasColumnName("demonstratedbehavior")
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Employeescore).HasColumnName("employeescore");

                entity.Property(e => e.Expectedbehavior)
                    .IsRequired()
                    .HasColumnName("expectedbehavior")
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Managerscore).HasColumnName("managerscore");

                entity.Property(e => e.Performanceappraisalid).HasColumnName("performanceappraisalid");

                entity.HasOne(d => d.Performanceappraisal)
                    .WithMany(p => p.Globalbehavior)
                    .HasForeignKey(d => d.Performanceappraisalid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("perfappgb");
            });

            modelBuilder.Entity<Mobilitycode>(entity =>
            {
                entity.ToTable("mobilitycode");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasColumnName("code")
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Createdate)
                    .HasColumnName("createdate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Updatedate)
                    .HasColumnName("updatedate")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Performanceappraisal>(entity =>
            {
                entity.ToTable("performanceappraisal");

                entity.HasIndex(e => e.Employeeid)
                    .HasName("perfappemployee_idx");

                entity.HasIndex(e => e.MobilityId)
                    .HasName("perfappmobility_idx");

                entity.HasIndex(e => e.Statusid)
                    .HasName("perfappstatus_idx");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Bodescriptivescore)
                    .HasColumnName("bodescriptivescore")
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Bonumericscore)
                    .HasColumnName("bonumericscore")
                    .HasColumnType("varchar(10)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Careeraspirationcomment)
                    .HasColumnName("careeraspirationcomment")
                    .HasColumnType("varchar(500)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Createdate)
                    .HasColumnName("createdate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Employeecomment)
                    .HasColumnName("employeecomment")
                    .HasColumnType("varchar(500)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Employeeid).HasColumnName("employeeid");

                entity.Property(e => e.Gbdescriptivescore)
                    .HasColumnName("gbdescriptivescore")
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Gbnumericscore)
                    .HasColumnName("gbnumericscore")
                    .HasColumnType("varchar(10)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Managercomment)
                    .HasColumnName("managercomment")
                    .HasColumnType("varchar(500)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.MobilityId).HasColumnName("mobilityId");

                entity.Property(e => e.Mobilitydesc)
                    .HasColumnName("mobilitydesc")
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Overalldescriptivescore)
                    .HasColumnName("overalldescriptivescore")
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Overallnumericscore)
                    .HasColumnName("overallnumericscore")
                    .HasColumnType("varchar(10)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Statusid).HasColumnName("statusid");

                entity.Property(e => e.Updatedate)
                    .HasColumnName("updatedate")
                    .HasColumnType("datetime");

                entity.Property(e => e._2ndlvlmanagercomment)
                    .HasColumnName("2ndlvlmanagercomment")
                    .HasColumnType("varchar(500)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Performanceappraisal)
                    .HasForeignKey(d => d.Employeeid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("perfappemployee");

                entity.HasOne(d => d.Mobility)
                    .WithMany(p => p.Performanceappraisal)
                    .HasForeignKey(d => d.MobilityId)
                    .HasConstraintName("perfappmobility");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Performanceappraisal)
                    .HasForeignKey(d => d.Statusid)
                    .HasConstraintName("perfappstatus");
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.ToTable("position");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Createdate)
                    .HasColumnName("createdate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Level).HasColumnName("level");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Updatedate)
                    .HasColumnName("updatedate")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Statuscode>(entity =>
            {
                entity.ToTable("statuscode");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Createdate)
                    .HasColumnName("createdate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Updatedate)
                    .HasColumnName("updatedate")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Subdepartment>(entity =>
            {
                entity.ToTable("subdepartment");

                entity.HasIndex(e => e.Departmentid)
                    .HasName("departmentsub_idx");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Createdate)
                    .HasColumnName("createdate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Departmentid).HasColumnName("departmentid");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Updatedate)
                    .HasColumnName("updatedate")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Subdepartment)
                    .HasForeignKey(d => d.Departmentid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("departmentsub");
            });

            modelBuilder.Entity<Userlog>(entity =>
            {
                entity.ToTable("userlog");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Createdate)
                    .HasColumnName("createdate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("varchar(500)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
