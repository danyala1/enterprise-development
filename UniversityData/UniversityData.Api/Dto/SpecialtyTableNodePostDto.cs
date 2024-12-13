using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UniversityData.Api.Dto
{
    public class SpecialtyTableNodePostDto : Controller
    {
        // GET: SpecialtyTableNodePostDto
        public ActionResult Index()
        {
            return View();
        }

        // GET: SpecialtyTableNodePostDto/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SpecialtyTableNodePostDto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SpecialtyTableNodePostDto/Create
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

        // GET: SpecialtyTableNodePostDto/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SpecialtyTableNodePostDto/Edit/5
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

        // GET: SpecialtyTableNodePostDto/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SpecialtyTableNodePostDto/Delete/5
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
