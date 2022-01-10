using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplicationApp.Shared
{
    public class ProjectManager
    {
        [Key]
        public Guid managerId { get; set; }

        [Required]
        public string managerFirstName { get; set; }

        public string managerLastName { get; set; }

        public string managerUserName { get; set; }

        [DataType(DataType.Password)]
        public string managerPassword { get; set; }

    }
}

