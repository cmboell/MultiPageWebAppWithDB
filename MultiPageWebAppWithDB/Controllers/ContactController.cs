using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MultiPageWebAppWithDB.Models;
//in charge of flow of data between view and model
namespace MultiPageWebAppWithDB.Controllers
{
    public class ContactController : Controller
    {
        //attribute
        private ContactContext context { get; set; } //can easily access the ContactContext

        public ContactController(ContactContext ctx)
        {
            context = ctx;
        }

        [HttpGet] //get request for add
        public IActionResult Add() //add method to add contacts (displays edit view)
        {
            ViewBag.Action = "Add";
            ViewBag.Relationships = context.Relationships.OrderBy(r => r.Type).ToList(); //uses order by and to list method
            return View("Edit", new Contact()); //returns view
        }
        [HttpGet]//get request for edit
        public IActionResult Edit(int id)         //edit method to edit contacts displays edit view
        {
            ViewBag.Action = "Edit";
            ViewBag.Relationships = context.Relationships.OrderBy(r => r.Type).ToList(); //uses order by and to list method
            var contact = context.Contacts.Find(id); //calls find method
            return View(contact); //returns view
        }

        [HttpPost] //post request for add/edit //processes data
        public IActionResult Edit(Contact contact)
        {
            if (ModelState.IsValid) //checks to see if input is valid
            {
                if (contact.ContactId == 0) //checks to see if contact id isnt zero
                    context.Contacts.Add(contact); //if contact id equals zero calls add method
                else
                    context.Contacts.Update(contact); //if contact id isnt zero calls update method
                context.SaveChanges(); //saves changes to database
                return RedirectToAction("Index", "Home"); //returns to index view
            }
            else
            {
                ViewBag.Action = (contact.ContactId == 0) ? "Add" : "Edit";
                ViewBag.Relationships = context.Relationships.OrderBy(r => r.Type).ToList(); //uses order by and to list method
                return View(contact); //returns view
            }
        }
        [HttpGet] //get request for delete
        public IActionResult Delete(int id)    //delete method to delete contacts, displays delete view
        {
            var contact = context.Contacts.Find(id); //calls find method
            return View(contact); //returns view
        }
        [HttpPost] //post request for delete //processes data
        public IActionResult Delete(Contact contact)
        {
            context.Contacts.Remove(contact);  //calls remove method
            context.SaveChanges(); //saves changes to database
            return RedirectToAction("Index", "Home");//returns to index view
        }
    }
}