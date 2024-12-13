using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UniversityData.Api.Controllers
{
    public class UniversityPropertyController : Controller
    {
        // GET: UniversityPropertyController
        public ActionResult Index()
        {
            return View();
        }

        // GET: UniversityPropertyController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UniversityPropertyController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UniversityPropertyController/Create
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

        // GET: UniversityPropertyController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UniversityPropertyController/Edit/5
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

        // GET: UniversityPropertyController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UniversityPropertyController/Delete/5
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
