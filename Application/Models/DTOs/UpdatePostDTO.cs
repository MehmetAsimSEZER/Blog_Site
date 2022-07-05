using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.DTOs
{
    public class UpdatePostDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Must type Title")]
        [MaxLength(250, ErrorMessage = "Maximum lenght is 250 character")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Must type Content")]
        public string Content { get; set; }
        public DateTime UpdateDate => DateTime.Now;
        public Status Status => Status.Modified;
    }
}
