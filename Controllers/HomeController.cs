using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using ExamenesMedicos.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExamenesMedicos.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upload()
        {
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Upload(UploadModel model)
        {
            if (model.File == null || model.File.Length == 0)
                return Content("file not selected");
            var date = DateTime.Today.ToString("dd-MM-yyyy");
            var path = Path.Combine(
                Directory.GetCurrentDirectory(), $"wwwroot/docs/{model.Tipo}");
            var ficha = model.FichaEmpleado == null ? "" : $"_{model.FichaEmpleado}";
            var fileName = $"{model.Tipo}_{date}{ficha}{Path.GetExtension(model.File.FileName)}";

            Directory.CreateDirectory(path);

            using (var stream = new FileStream(Path.Combine(path,fileName), FileMode.Create))
            {
                await model.File.CopyToAsync(stream);
            }

            return RedirectToAction("Upload");
        }


        public IActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Search(SearchModel model)
        {
            return View(model);
        }
        
        [HttpPost]
        public async Task<IActionResult> Download(SearchModel model)
        {
            var ficha = model.FichaEmpleado == null ? "" : $"_{model.FichaEmpleado}";
            var fileName = $"{model.Tipo}_{model.Fecha:dd-MM-yyyy}{ficha}";

            var path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/docs/{model.Tipo}", fileName);
            
            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, "APPLICATION/octet-stream", path);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}