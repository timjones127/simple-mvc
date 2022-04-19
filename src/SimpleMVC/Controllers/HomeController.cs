using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SimpleMVC.Models;
using SimpleMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using SimpleMVC.Data;
using Microsoft.EntityFrameworkCore;

namespace SimpleMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDBContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, AppDBContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var vm = new SubmitIncidentViewModel();
            //Build our select list for categories
            await InitializeCategories(vm);
            return View(vm);
        }

        public IActionResult Success(string ticketId)
        {
            if (TempData.ContainsKey("Ticketid"))
            {
                ViewBag.TicketId = TempData["Ticketid"].ToString();
                return View();
            }
            //If we dont have a ticketId we go back to the Index Action
            return RedirectToAction("Index");
            
        }

        [HttpPost]
        public async Task<IActionResult> Index(SubmitIncidentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var newIncident = new Incident()
                {
                    Title = model.Title,
                    Description = model.Description,
                    Status = Status.Active,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Phone = model.Phone,
                    Email = model.Email,
                    ClassificationId = model.ClassificationId
                };
                _context.Add(newIncident);
                await _context.SaveChangesAsync();
                TempData["Ticketid"] = newIncident.Id;
                return RedirectToAction("Success");
            }
            await InitializeCategories(model);
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        private async Task<int> InitializeCategories(SubmitIncidentViewModel vm)
        {
            var categories = await _context.Classifications.OrderBy(x=>x.Name)
                    .Select(x=> new SelectListItem(x.Name,x.ClassificationId.ToString())).ToListAsync();
            vm.Categories.AddRange(categories);
            return vm.Categories.Count;
        }
    }
}
