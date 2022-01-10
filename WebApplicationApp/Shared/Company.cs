using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace WebApplicationApp.Shared
{
    public class Company
    {
        [Key]

        public Guid companyId { get; set; }

        [Required]
        public string companyName { get; set; }

        public string companyEmail { get; set; }

        public string companyPhone { get; set; }

        public string companyAddress { get; set; }

        public virtual List<Project> Projects { get; set; }


    }
}
