using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UniversityData.Api.Controllers
{
    public class SpecialtyTableNodeController : Controller
    {
        // GET: SpecialtyTableNodeController
        public ActionResult Index()
        {
            return View();
        }

        // GET: SpecialtyTableNodeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SpecialtyTableNodeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SpecialtyTableNodeController/Create
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

        // GET: SpecialtyTableNodeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SpecialtyTableNodeController/Edit/5
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

        // GET: SpecialtyTableNodeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SpecialtyTableNodeController/Delete/5
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
