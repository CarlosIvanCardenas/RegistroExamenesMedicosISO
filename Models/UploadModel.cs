using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace ExamenesMedicos.Models
{
    public class UploadModel
    {
        public List<SelectListItem> ItemsType { get; set; }
        public int IdType { get; set; }
        public string Empresa { get; set; }
        public string FichaEmpleado { get; set; }
        public string NombreEmpleado { get; set; }
        public IFormFile File { get; set; }
    }
}