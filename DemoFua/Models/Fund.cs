using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DemoFua.Models
{
    public class Fund
    {

        public int id { get; set; }

        [Display(Name = "Requested Date")]
        public DateTime requestDate { get; set; }

        [Display(Name = "Industry")]
        public string industry { get; set; }

        [Display(Name = "Status")]
        public string status { get; set; }

        [Display(Name = "Is Granted")]
        public bool isGranted { get; set; }

        public int CompanyId { get; set; }
        public virtual Company company { get; set; }
    }
}