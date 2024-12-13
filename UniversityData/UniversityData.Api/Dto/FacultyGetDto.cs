using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UniversityData.Api.Dto
{
    public class FacultyGetDto : Controller
    {
        // GET: FacultyGetDto
        public ActionResult Index()
        {
            return View();
        }

        // GET: FacultyGetDto/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FacultyGetDto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FacultyGetDto/Create
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

        // GET: FacultyGetDto/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FacultyGetDto/Edit/5
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

        // GET: FacultyGetDto/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FacultyGetDto/Delete/5
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
