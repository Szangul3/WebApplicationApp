using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplicationApp.Shared
{
    public class Ticket
    {
        [Key]
        public Guid ticketId { get; set; }
        public Guid employeeId { get; set; }

        [Required]
        public string ticketDescription { get; set; }

        public virtual List<Employee> Employees { get; set; }
        public DateTime start { get; set; }
        public DateTime dueDate { get; set; }

        public Guid projectId { get; set; }    //works like a foreign key
        public virtual List<Project> Projects { get; set; }    //i will use entity framework. Therfore, need this
    }
}
