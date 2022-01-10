using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplicationApp.Shared
{
    public class Report
    {
        [Key]
        public Guid reportId { get; set; }

        [Required]
        public string reportDescription { get; set; }

        public string reportName { get; set; }

    }
}
