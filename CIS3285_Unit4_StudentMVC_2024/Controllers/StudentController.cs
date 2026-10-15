using CIS3285_Unit4_StudentMVC_2024.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CIS3285_Unit4_StudentMVC_2024.Controllers
{
    public class StudentController : Controller
    {
        // Depend on the CRUD interface instead of the concrete repository type.
        private readonly IStudentCRUDInterface studentRepo;

        public StudentController()
        {
            studentRepo = new StudentRepository();
        }

        // GET: StudentController
        public ActionResult Index()
        {
            return View("Index", studentRepo.getAllStudent());
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            return View("Details", studentRepo.getStudentById(id));
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                IStudentInterface newStudent = new StudentModel
                {
                    Id = Int32.Parse(collection["Id"]),
                    Name = collection["Name"].ToString(),
                    Credits = Int32.Parse(collection["Credits"])
                };

                studentRepo.AddStudent(newStudent);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            return View("Edit", studentRepo.getStudentById(id));
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                IStudentInterface updatedStudent = new StudentModel
                {
                    Id = id,
                    Name = collection["Name"].ToString(),
                    Credits = Int32.Parse(collection["Credits"])
                };

                studentRepo.UpdateStudent(id, updatedStudent);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {
            studentRepo.DeleteStudent(id);
            return RedirectToAction(nameof(Index));
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            studentRepo.DeleteStudent(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
