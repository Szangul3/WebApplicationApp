using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplicationApp.Shared
{
    public class Employee
    {
        [Key]
        public Guid employeeId { get; set; }

        [Required]
        [MaxLength(70)]
        public string employeeFirstName { get; set; }

        public string employeeLastName { get; set; }

        public string employeeUsername { get; set; }


        [DataType(DataType.Password)]
        public string employeePassword { get; set; }

        public virtual List<Project> Projects { get; set; }
        public virtual List<Ticket> Tickets { get; set; }
    }
}
