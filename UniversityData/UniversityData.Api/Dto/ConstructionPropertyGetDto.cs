using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UniversityData.Api.Dto
{
    public class ConstructionPropertyGetDto : Controller
    {
        // GET: ConstructionPropertyGetDto
        public ActionResult Index()
        {
            return View();
        }

        // GET: ConstructionPropertyGetDto/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ConstructionPropertyGetDto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ConstructionPropertyGetDto/Create
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

        // GET: ConstructionPropertyGetDto/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ConstructionPropertyGetDto/Edit/5
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

        // GET: ConstructionPropertyGetDto/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ConstructionPropertyGetDto/Delete/5
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
