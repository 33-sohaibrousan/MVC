using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace codefirst_9_2.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public ICollection<StudentCource> StudentCource { get; set; }
    }
}