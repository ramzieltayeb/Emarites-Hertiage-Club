using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PschoolAPI.Models
{
    public class Students
    {

        public int StudentID { get; set; }
        public string  Student_first_name { get; set; }

        public string Student_last_name { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public int PhoneNumber { get; set; }

        public int ClassLevel { get; set; }

        public int Parent { get; set; }

        public int  Gender { get; set; }
    }
}
