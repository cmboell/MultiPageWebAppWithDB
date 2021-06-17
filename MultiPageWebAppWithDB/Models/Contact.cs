using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
//page that updates data and applies business rules, validates data
namespace MultiPageWebAppWithDB.Models
{
    public class Contact
    {
        //attributes
        //EF Core will configure the database to generate this value
        public int ContactId { get; set; } //Id in name makes this a primary key for table
        //makes class required with an error message to be displayed if not entered
        [Required(ErrorMessage = "Please enter a name.")]
        public string Name { get; set; }
        //makes class required with an error message to be displayed if not entered
        [Required(ErrorMessage = "Please enter a phone number.")]
        [Phone(ErrorMessage ="Please enter a valid phone number.")]
        public string PhoneNumber { get; set; }
        //makes class required with an error message to be displayed if not entered
        [Required(ErrorMessage = "Please enter an address.")]
        public string Address { get; set; }
        //makes class required with an error message to be displayed if not entered
        [Required(ErrorMessage = "Please enter a note.")]
        public string Note { get; set; }
        //makes class required with an error message to be displayed if not entered
        [Required(ErrorMessage = "Please enter a relationship.")]
        public string RelationshipId { get; set;}  //adds foriegn key property when adding relationship property              
        public Relationship Relationship { get; set; }   //adds Relationship to contact class

        //read only property creates the slug for URL
        public string Slug => Name?.Replace(' ', '-').ToLower() + '-' + PhoneNumber?.ToString();
    }
}
