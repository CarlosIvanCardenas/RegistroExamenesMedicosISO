using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ExamenesMedicos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using File = ExamenesMedicos.Models.File;

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
            var db = new FileContext();
            var getTypes = db.MedicalExams
                .Select(x => new SelectListItem()
                {
                    Value = x.Id.ToString(),
                    Text = x.ExamName
                }).ToList();
            var model = new UploadModel
            {
                ItemsType = getTypes
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Upload(UploadModel model)
        {
            if (model.File == null || model.File.Length == 0)
                return Content("file not selected");

            var db = new FileContext();

            var exam = db.MedicalExams.FirstOrDefault(x => x.Id == model.IdType);
            var examName = exam.ExamName;
            var date = DateTime.Today.ToString("dd-MM-yyyy");
            var ficha = model.FichaEmpleado == null ? "" : $"_{model.FichaEmpleado}";
            var path = $"\\\\192.168.6.5\\ExamenMedicos\\{examName}";
            var fileName = $"{examName}_{date}{ficha}{Path.GetExtension(model.File.FileName)}";

            var file = new File
            {
                Path = Path.Combine(path, fileName),
                FileName = fileName,
                Date = DateTime.Today,
                Exam = exam,
                Ficha = model.FichaEmpleado
            };
            db.Files.Add(file);
            db.SaveChanges();

            Directory.CreateDirectory(path);

            using (var stream = new FileStream(Path.Combine(path,fileName), FileMode.Create))
            {
                await model.File.CopyToAsync(stream);
            }

            return RedirectToAction("Upload");
        }


        public IActionResult Search()
        {
            var db = new FileContext();
            var getTypes = db.MedicalExams
                .Select(x => new SelectListItem()
                {
                    Value = x.Id.ToString(),
                    Text = x.ExamName
                }).ToList();
            var model = new SearchModel
            {
                ItemsType = getTypes
            };
            return View(model);
        }
        
        [HttpPost]
        public IActionResult Search(SearchModel model)
        {
            var db = new FileContext();

            var exam = db.MedicalExams.FirstOrDefault(x => x.Id == model.IdType);
            var date = model.Fecha;
            var files = db.Files
                .Where(x => x.Exam == exam && x.Date == date && x.Ficha == model.FichaEmpleado).ToList();

            var getTypes = db.MedicalExams
                .Select(x => new SelectListItem()
                {
                    Value = x.Id.ToString(),
                    Text = x.ExamName
                }).ToList();

            model.Files = files;
            model.ItemsType = getTypes;

            return View(model);
        }

        public IActionResult _SearchResults(List<File> files)
        {
            return PartialView(files);
        }

        public async Task<IActionResult> Download(string path, string name)
        {
            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, "APPLICATION/octet-stream", name);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}