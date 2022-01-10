using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplicationApp.Shared
{
    public class Project
    {
        [Key]
        public Guid projectId { get; set; }

        [Required]
        public string projectName { get; set; }

        public string projectDescription { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public Guid employeeId { get; set; }

        public virtual List<Employee> Employees { get; set; }
        public virtual List<Ticket> Tickets { get; set; }
    }
}