using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UniversityData.Api.Dto
{
    public class FacultyPostDto : Controller
    {
        // GET: FacultyPostDto
        public ActionResult Index()
        {
            return View();
        }

        // GET: FacultyPostDto/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FacultyPostDto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FacultyPostDto/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FacultyPostDto/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FacultyPostDto/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FacultyPostDto/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FacultyPostDto/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
