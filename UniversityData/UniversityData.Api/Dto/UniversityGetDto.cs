using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UniversityData.Api.Dto
{
    public class UniversityGetDto : Controller
    {
        // GET: UniversityGetDto
        public ActionResult Index()
        {
            return View();
        }

        // GET: UniversityGetDto/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UniversityGetDto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UniversityGetDto/Create
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

        // GET: UniversityGetDto/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UniversityGetDto/Edit/5
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

        // GET: UniversityGetDto/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UniversityGetDto/Delete/5
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
