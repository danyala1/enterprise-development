using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UniversityData.Api.Dto
{
    public class UniversityPropertyPostDto : Controller
    {
        // GET: UniversityPropertyPostDto
        public ActionResult Index()
        {
            return View();
        }

        // GET: UniversityPropertyPostDto/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UniversityPropertyPostDto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UniversityPropertyPostDto/Create
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

        // GET: UniversityPropertyPostDto/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UniversityPropertyPostDto/Edit/5
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

        // GET: UniversityPropertyPostDto/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UniversityPropertyPostDto/Delete/5
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
