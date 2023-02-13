using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace codefirst_9_2.Models
{
    public class StudentCource
    {
        public int Id { get; set; }
        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public string note { get; set; }
        [ForeignKey("Student")]

        public int StudentId { get; set; }
        public Student Student { get; set; }
        public Course Course { get; set; }
    }
}