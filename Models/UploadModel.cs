using Microsoft.AspNetCore.Http;

namespace ExamenesMedicos.Models
{
    public class UploadModel
    {
        public string Tipo { get; set; }
        public string FichaEmpleado { get; set; }
        public IFormFile File { get; set; }
    }
}