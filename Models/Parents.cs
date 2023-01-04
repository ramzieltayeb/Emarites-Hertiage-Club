using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PschoolAPI.Models
{
    public class Parents
    {

        public int ParentID { get; set; }
        public string ParentName { get; set; }

        public int PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }
    }
}
