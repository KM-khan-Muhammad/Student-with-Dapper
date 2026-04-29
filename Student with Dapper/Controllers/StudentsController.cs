using Microsoft.AspNetCore.Mvc;
using Student_with_Dapper.Models;
using Student_with_Dapper.RPO;

namespace Student_with_Dapper.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudent _std;

        public StudentsController(IStudent std)
        {
            _std = std;
        }
        [HttpGet] public async Task<IActionResult> Index() => View(await _std.GetAllStudents());
        [HttpGet] public IActionResult Create() => View();
        [HttpPost]
        public async Task<IActionResult> Create(Student student)
        {
            if (ModelState.IsValid)
            {
               await _std.Create(student);
                return RedirectToAction(nameof(Index));
            }
            return View(student);

        }
        [HttpGet] public async Task<IActionResult> Edit(int id) => View(await _std.GetStudentById(id));
        [HttpPost]
        public async Task<IActionResult> Edit(Student student)
        {
            if (ModelState.IsValid)
            {
               await _std.Update(student);
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }
        [HttpGet] public async Task<IActionResult> Delete(int id) => View(await _std.GetStudentById(id));
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
           await _std.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            var student =await _std.GetStudentById(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }
    }
}
