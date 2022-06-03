using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DataAnnotationInMVC.Common;

namespace Lab04.Models
{
    public class Student
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Cannot empty")]
        [StringLength(50, ErrorMessage = "Maximum character is 50")]
        [RegularExpression(@"^\s*(\S+\s+|\S+$){0,10}$", ErrorMessage = "Maximum word is 10")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Cannot empty")]
        [StringLength(50, ErrorMessage = "Maximum character is 50")]
        [RegularExpression(@"^\s*(\S+\s+|\S+$){0,10}$", ErrorMessage = "Maximum word is 10")]
        public string FirstMidName { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DateRange("1/1/2010", ErrorMessage = "Date is out of Range")]
        public DateTime EnrollmentDate { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }

}