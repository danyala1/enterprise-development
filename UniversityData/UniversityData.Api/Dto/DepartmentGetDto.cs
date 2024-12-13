using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UniversityData.Api.Dto
{
    public class DepartmentGetDto : Controller
    {
        // GET: DepartmentGetDto
        public ActionResult Index()
        {
            return View();
        }

        // GET: DepartmentGetDto/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DepartmentGetDto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DepartmentGetDto/Create
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

        // GET: DepartmentGetDto/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DepartmentGetDto/Edit/5
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

        // GET: DepartmentGetDto/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DepartmentGetDto/Delete/5
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
