using BI.web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BI.web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private BIContext BIContext;

        public HomeController(ILogger<HomeController> logger, BIContext _BIContext)
        {
            _logger = logger;
            BIContext = _BIContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }   
        
        public IActionResult Search(string name)
        {
            ViewBag.Pesquisa = name;
            return View( BIContext.BIs.Where(x => x.BiNumber.Contains(name)).ToList());
        }

        [HttpGet]
        public IActionResult create()
        {

            return View(new BI.web.Models.BI());
        }

        [HttpGet]
        public IActionResult Details(int id)
        {

            var result = BIContext.BIs.Find(id);
            return View(result);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var result = BIContext.BIs.Find(id);
            return View(result);
        } 
        
        [HttpPost]
        public IActionResult DeleteBI(int id)
        {
            var result = BIContext.BIs.Find(id);

            BIContext.BIs.Remove(result);
            BIContext.SaveChanges();

            return RedirectToAction("BIIndex");
        }

        public IActionResult BIIndex()
        {
            List<BI.web.Models.BI> ListBi = BIContext.BIs.ToList();
            return View(ListBi);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var result = BIContext.BIs.Find(id);
            return View(result);
        }

        [HttpPost]
        public IActionResult Edit(BI.web.Models.BI model)
        {
            var result = BIContext.BIs.Find(model.Id);

            result.Name = model.Name;
            result.BirhDate = model.BirhDate;
            result.BiNumber = model.BiNumber;
            result.Address = model.Address;

            BIContext.SaveChanges();

            return RedirectToAction("BIIndex");
        }

        [HttpPost]
        public IActionResult create(BI.web.Models.BI model)
        {
            BIContext.BIs.Add(model);
            BIContext.SaveChanges();

            return RedirectToAction("BIIndex");
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



    }
}
