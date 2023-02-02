//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace mvc_task2_2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Employee
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Please enter name"),Range(1,12,ErrorMessage ="the name is long")]
        public string Firsrt_Name { get; set; }
        [Required(ErrorMessage = "Please enter name"), MaxLength(12)]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string E_mail { get; set; }
        [Required]
        [RegularExpression(@"^(0)?[7]{1}[8|9|7]{1}[0-9]{7}$", ErrorMessage = "Invalid Mobile")]
        public Nullable<int> Phone { get; set; }
        [Required]
        [Range(18, 50, ErrorMessage = "Age from 18 to 50 only")]
        public Nullable<int> Age { get; set; }
        [Required]       
        [MaxLength(10)]
        public string Job_Title { get; set; }
        [Required]
        public string Gender { get; set; }
    }
}
