using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExamenesMedicos.Models
{
    public class SearchModel
    {
        public List<SelectListItem> ItemsType { get; set; }
        public int IdType { get; set; }
        public DateTime Fecha { get; set; }
        public string FichaEmpleado { get; set; }
        public string NombreEmpleado { get; set; }
        public string Empresa { get; set; }
        public List<File> Files { get; set; }
    }
}