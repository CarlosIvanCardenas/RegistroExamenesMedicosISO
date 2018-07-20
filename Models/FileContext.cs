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
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=DBExamenesMedicos;Integrated Security=True;Pooling=False;Connect Timeout=30");
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
    }

    public class MedicalExam
    {
        public int Id { get; set; }
        public string ExamName { get; set; }
    }
}
