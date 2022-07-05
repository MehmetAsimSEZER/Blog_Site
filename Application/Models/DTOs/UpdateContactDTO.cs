using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.DTOs
{
    public class UpdateContactDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Must type Name")]
        [MaxLength(25, ErrorMessage = "Maximum lenght is 25")]
        public string Name { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Must type EmailAddress")]
        public string Email { get; set; }

        [Required]
        [Phone(ErrorMessage = "Must type PhoneNumber")]
        [MinLength(11, ErrorMessage = "Minimum lenght 11")]
        [MaxLength(11, ErrorMessage = "Maximum lenght 11")]
        public string Phone { get; set; }

        [Required]
        [MaxLength(500, ErrorMessage = "Maximum lenght 500 character")]
        public string Message { get; set; }
        public DateTime UpdateDate => DateTime.Now;
        public Status Status => Status.Modified;
    }
}
