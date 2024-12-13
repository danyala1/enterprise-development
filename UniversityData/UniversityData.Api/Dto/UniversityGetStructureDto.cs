using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UniversityData.Api.Dto
{
    public class UniversityGetStructureDto : Controller
    {
        // GET: UniversityGetStructureDto
        public ActionResult Index()
        {
            return View();
        }

        // GET: UniversityGetStructureDto/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UniversityGetStructureDto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UniversityGetStructureDto/Create
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

        // GET: UniversityGetStructureDto/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UniversityGetStructureDto/Edit/5
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

        // GET: UniversityGetStructureDto/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UniversityGetStructureDto/Delete/5
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
