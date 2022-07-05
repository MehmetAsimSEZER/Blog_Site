using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.DTOs
{
    public class CreateAuthorDTO
    {
        [Required(ErrorMessage = "Must type first name")]
        [MinLength(3, ErrorMessage = "Minimum lenght is 3")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Must type last name")]
        [MinLength(3, ErrorMessage = "Minimum lenght is 3")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Must type resume")]
        public string Resume { get; set; }

        [Required(ErrorMessage = "Must type Phone")]
        [Phone(ErrorMessage = "Must type phone")]
        [MinLength(11, ErrorMessage = "Minimum lenght 11")]
        [MaxLength(11, ErrorMessage = "Maximum lenght 11")]
        public string Phone { get; set; }
        public DateTime CreateDate => DateTime.Now;
        public Status Status => Status.Active;
    }
}
