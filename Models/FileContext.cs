using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenesMedicos.Models
{
    public class FileContext : DbContext
    {
        public DbSet<File> Files { get; set; }
        public DbSet<MedicalExam> MedicalExams { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DCSERVER3;Initial Catalog=DBExamenMedico;Persist Security Info=True;User ID=sa;pwd=RBA550716*;Pooling=False;MultipleActiveResultSets=False;Connect Timeout=60;Encrypt=False;TrustServerCertificate=True");
        }
    }

    public class File
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public string FileName { get; set; }
        public MedicalExam Exam { get; set; }
        public DateTime Date { get; set; }
        public string Ficha { get; set; }
        public string EmployeeName { get; set; }
        public string Company { get; set; }
    }

    public class MedicalExam
    {
        public int Id { get; set; }
        public string ExamName { get; set; }
    }
}
