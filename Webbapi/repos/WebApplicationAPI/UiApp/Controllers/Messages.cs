using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UiApp.Models;

namespace UiApp.Controllers
{
    public class Messages : Controller
    {
        // GET: Messages

        public ActionResult Index()
        {
            IEnumerable<MessagesModel> messages = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5076/api/");
                //HTTP GET
                var responseTask = client.GetAsync("messages");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<MessagesModel>>();
                    readTask.Wait();

                    messages = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    messages = Enumerable.Empty<MessagesModel>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(messages);
        }

        // GET: Messages/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Messages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Messages/Create
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

        // GET: Messages/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Messages/Edit/5
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

        // GET: Messages/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Messages/Delete/5
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
