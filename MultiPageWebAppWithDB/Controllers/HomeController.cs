using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;      //using directives that import (also on other pages)
using Microsoft.AspNetCore.Mvc;                      
using MultiPageWebAppWithDB.Models;
using Microsoft.EntityFrameworkCore;
//in charge of flow of data between view and model
namespace MultiPageWebAppWithDB.Controllers
{
    public class HomeController : Controller
    {
        private ContactContext context { get; set; }

        public HomeController(ContactContext ctx)
        {
            context = ctx;
        }
        public IActionResult Index()
        {
            var contacts = context.Contacts.Include(c => c.Relationship).OrderBy(c => c.Name).ToList(); //selects info from database
            return View(contacts); //returns view                            //uses order by and to list method
        }

    }
}
