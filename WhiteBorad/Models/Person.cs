using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WhiteBorad.Models
{
    public class Person
    {
        public string Name { get; set; }
        public ushort Age { get; set; }
        public string Sex { get; set; }
        public string Hometown { get; set; }
        public string Hobby { get; set; }
    }
}