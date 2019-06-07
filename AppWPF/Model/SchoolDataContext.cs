using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace AppWPF.Model
{
    public class SchoolDataContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<OnlineCourse> OnlineCourses { get; set; }
        public DbSet<OnsiteCourse> OnsiteCourses { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<OfficeAssignment> OfficeAssignments {get; set;}
        public DbSet<StudentGrade> StudentGrades { get; set; }
        public DbSet<CourseInstructor> CourseInstructors { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Department>()
                .ToTable("Department")
                .HasKey(d => new { d.DepartmentID })
                .Property(d => d.Name)
                .IsRequired()
                .HasMaxLength(128);
            modelBuilder.Entity<Department>()
                .ToTable("Department")
                .Property(d => d.StartDate)
                .IsRequired();
            modelBuilder.Entity<Course>()
                .ToTable("Course")
                .HasKey(c => new { c.CourseID })
                .Property(c => c.Title)
                .IsRequired();
            modelBuilder.Entity<Course>()
                .HasRequired(c => c.OnlineCourse)
                .WithRequiredPrincipal(c => c.Course);
            modelBuilder.Entity<Course>()
                .HasRequired(c => c.OnsiteCourse)
                .WithRequiredPrincipal(c => c.Course);


            modelBuilder.Entity<OnlineCourse >()
                .ToTable("OnlineCourse")
                .HasKey(o => new { o.CourseID })
                .Property(o => o.URL)
                .IsRequired();
            modelBuilder.Entity<OnsiteCourse>()
                .ToTable("OnsiteCourse")
                .HasKey(o => new { o.CourseID })
                .Property(o => o.Location)
                .IsRequired();
            modelBuilder.Entity<Person>()
               .ToTable("Person")
               .HasKey(p => new { p.PersonID });
            modelBuilder.Entity<Person>()
                .HasRequired(p => p.OfficeAssignment)
                .WithRequiredPrincipal(p => p.Person);

            modelBuilder.Entity<StudentGrade>()
              .ToTable("StudentGrade")
              .HasKey(s => new { s.EnrollmentID });
            modelBuilder.Entity<StudentGrade>()// en este trozo hago referencia y le indico a intity framework que PersonID y StudentID tienen referencia(llave foranea) aunque no se llame igual
                .ToTable("StudentGrade")       //esto se realiza en caso de que las dos llaves que relaciona las dos tablas no se llamen igual y por convencion se llamaran igual pero habra unos casos de que no
                .HasRequired<Person>(p => p.Person)
                .WithMany(p => p.StudentGrades)
                .HasForeignKey<int>(s => s.StudentID);


            /*.Property(p => p.LastName) estas linesa si se quiere se coloca si no no xq son para requerir un campo igual puede ser para las anteriores y posteriores
            .IsRequired(); */
            /* modelBuilder.Entity<OfficeAssignment>()
                .ToTable("OfficeAssignment")
                .HasKey(o => new { o.InstructorID });

              COnfigurar 
             // si me doy cuenta aqui ya no coloque los de property y Isrequired, no hay problema
             modelBuilder.Entity<OfficeAssignment>()
               .ToTable("OfficeAssignment")
               .HasRequired(p => p.Person)
               .WithOptional(p => p.OfficeAssignment)
               .Map(o => o.MapKey("InstructorID")); */
            modelBuilder.Entity<OfficeAssignment>()
                .ToTable("OfficeAssignment")
                .HasKey(o => o.InstructorID);

           
            modelBuilder.Entity<CourseInstructor>()
               .ToTable("CourseInstructor")
               .HasKey(c => new { c.CourseID, c.PersonID }); // creacion de una llave primaria compuesta



        }
    }
}
