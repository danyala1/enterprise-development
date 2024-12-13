using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UniversityData.Api.Dto
{
    public class DepartmentPostDto : Controller
    {
        // GET: DepartmentPostDto
        public ActionResult Index()
        {
            return View();
        }

        // GET: DepartmentPostDto/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DepartmentPostDto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DepartmentPostDto/Create
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

        // GET: DepartmentPostDto/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DepartmentPostDto/Edit/5
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

        // GET: DepartmentPostDto/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DepartmentPostDto/Delete/5
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
