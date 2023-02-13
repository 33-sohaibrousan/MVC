using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace codefirst_9_2.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public ICollection<StudentCource> StudentCource { get; set; }
    }
}