using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BiddHub.Controllers
{
    public class AuctioneersController : Controller
    {
        // GET: AuctioneersController
        public ActionResult Index()
        {
            return View();
        }

        // GET: AuctioneersController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AuctioneersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AuctioneersController/Create
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

        // GET: AuctioneersController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AuctioneersController/Edit/5
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

        // GET: AuctioneersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AuctioneersController/Delete/5
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
