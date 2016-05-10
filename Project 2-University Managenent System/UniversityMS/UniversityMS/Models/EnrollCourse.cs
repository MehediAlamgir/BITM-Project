using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityMS.Models
{
    //Need to Check
    public class EnrollCourse
    {
        public int Id { get; set; }

        [Required (ErrorMessage = "Please Select a Student")]
        [Display(Name="Student Reg. No.")]
        public string RegistrationNo { get; set; } // Need To Check
        public virtual Student Student { get; set; }

        [Required(ErrorMessage = "Please Select a Course")]
        [Display(Name="Select Course")]

        public int CourseId { get; set; }
        public virtual Course Course { get; set; }

        [Required(ErrorMessage = "Provide a Date Please !")]
        [Display(Name = "Date")]
        public DateTime EnrollDate { get; set; }

        public string CourseGrade { get; set; }

    }
}