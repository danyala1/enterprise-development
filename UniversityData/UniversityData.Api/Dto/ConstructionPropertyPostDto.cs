using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UniversityData.Api.Dto
{
    public class ConstructionPropertyPostDto : Controller
    {
        // GET: ConstructionPropertyPostDto
        public ActionResult Index()
        {
            return View();
        }

        // GET: ConstructionPropertyPostDto/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ConstructionPropertyPostDto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ConstructionPropertyPostDto/Create
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

        // GET: ConstructionPropertyPostDto/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ConstructionPropertyPostDto/Edit/5
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

        // GET: ConstructionPropertyPostDto/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ConstructionPropertyPostDto/Delete/5
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
