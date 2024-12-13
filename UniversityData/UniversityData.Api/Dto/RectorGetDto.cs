using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UniversityData.Api.Dto
{
    public class RectorGetDto : Controller
    {
        // GET: RectorGetDto
        public ActionResult Index()
        {
            return View();
        }

        // GET: RectorGetDto/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RectorGetDto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RectorGetDto/Create
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

        // GET: RectorGetDto/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RectorGetDto/Edit/5
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

        // GET: RectorGetDto/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RectorGetDto/Delete/5
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
