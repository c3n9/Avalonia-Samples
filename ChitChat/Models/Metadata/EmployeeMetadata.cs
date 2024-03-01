using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChitChat.Models.Metadata
{
    public class EmployeeMetadata
    {
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        [MaxLength(100)]

        public string UserName { get; set; } = null!;

        [Required]
        [MaxLength(100)]
        public string Password { get; set; } = null!;
        [Required]
        public virtual Department Department { get; set; } = null!;
    }
}
