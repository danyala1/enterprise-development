using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UniversityData.Api
{
    public class MappingProfile : Controller
    {
        // GET: MappingProfile
        public ActionResult Index()
        {
            return View();
        }

        // GET: MappingProfile/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MappingProfile/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MappingProfile/Create
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

        // GET: MappingProfile/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MappingProfile/Edit/5
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

        // GET: MappingProfile/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MappingProfile/Delete/5
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
