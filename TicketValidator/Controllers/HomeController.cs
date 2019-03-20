using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TicketValidator.Domain;
using TicketValidator.Logic;
using TicketValidator.Models;

namespace TicketValidator.Controllers
{
    public class HomeController : Controller
    {
        private readonly TicketService ticketService;

        public HomeController(TicketService ticketService)
        {
            this.ticketService = ticketService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        // GET api/values/5
        [HttpGet("{eventnaam}/{code}")]
        public IActionResult Check(string eventnaam, string code)
        {
            TicketValid valid = ticketService.ValidateTicket(new Ticket() {EventNaam = eventnaam, TicketId = code});

            return View(valid);
        }

        [HttpGet("create/{eventnaam}/{amount}")]
        public ActionResult<string> Create(string eventnaam, int amount)
        {
            ticketService.CreateTickets(amount, eventnaam);
            return "OK";
        }
    }
}
