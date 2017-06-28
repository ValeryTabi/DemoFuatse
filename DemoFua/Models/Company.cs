using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DemoFua.Models
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string name { get; set; }
        public string country { get; set; }
        public string city { get; set; }
        public string latestCA { get; set; }
        public int staffStrenth { get; set; }
        public string ranking { get; set; }
        public string risk { get; set; }
        public DateTime Doc { get; set; }

        [DataType(DataType.Currency)]
        public decimal balaance { get; set; } //holds the balance in the company's account
        
        public string otherNotes { get; set; }  //dummy property


        public virtual  ICollection<Project> Projects  { get; set; }
        public virtual ICollection<Fund> fundRequests { get; set; }


    }
}