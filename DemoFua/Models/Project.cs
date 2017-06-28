using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DemoFua.Models
{
    public class Project
    {

        public int Id { get; set; }
        public string projectName { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }

        [DataType(DataType.Currency)]
        public decimal budget { get; set; }



        public int CompanyId { get; set; }
        public virtual Company company { get; set; }

    }
}