using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace People.Api.Models
{
    public class Person
    {
        public int id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public int age { get; set; }

        public Photo image { get; set; }
    }
}