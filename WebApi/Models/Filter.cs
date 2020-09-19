using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class Filter
    {
        public string Phone { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string VIN { get; set; }
        public int ModelId { get; set; }
        public int MakeId { get; set; }
        public string Name { get; set; }
    }
}