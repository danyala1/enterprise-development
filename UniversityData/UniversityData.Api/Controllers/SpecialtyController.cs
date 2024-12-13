using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UniversityData.Api.Controllers
{
    public class SpecialtyController : Controller
    {
        // GET: SpecialtyController
        public ActionResult Index()
        {
            return View();
        }

        // GET: SpecialtyController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SpecialtyController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SpecialtyController/Create
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

        // GET: SpecialtyController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SpecialtyController/Edit/5
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

        // GET: SpecialtyController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SpecialtyController/Delete/5
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
