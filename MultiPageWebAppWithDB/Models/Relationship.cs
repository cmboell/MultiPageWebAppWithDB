using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//Relationship class
//page that updates data and applies business rules, validates data
namespace MultiPageWebAppWithDB.Models
{
    public class Relationship
    {
        //attributes
        public string RelationshipId { get; set; }
        public string Type{ get; set; }
    }
}
