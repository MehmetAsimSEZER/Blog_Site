using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.VMs
{
    public class PostVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

    }
}
