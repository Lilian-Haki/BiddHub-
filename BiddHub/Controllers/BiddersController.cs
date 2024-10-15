using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BiddHub.Controllers
{
    public class BiddersController : Controller
    {
        // GET: BiddersController
        public ActionResult Index()
        {
            return View();
        }

        // GET: BiddersController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BiddersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BiddersController/Create
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

        // GET: BiddersController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BiddersController/Edit/5
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

        // GET: BiddersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BiddersController/Delete/5
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
