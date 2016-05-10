using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniversityMS.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Course Code is Mandatory Field")]
        [Display(Name="Code")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Course Code Must be 5 characters long")]
        [Remote("IsUniqueCode", "Course", ErrorMessage = "Code already exists!")]
        public string CourseCode { get; set; }

        [Required(ErrorMessage = "Course Name is Mandatory Field")]
        [Display(Name = "Name")]
        [Remote("IsUniqueName", "Course", ErrorMessage = "Code already exists!")]
        public string CourseName { get; set; }

        [Required]
        [Display(Name = "Credit")]
        [Range(0.5, 5.0, ErrorMessage = "Credit must be within 0.5 to 5.0")]
        public double CourseCredit { get; set; }

        [Required]
        [Display(Name = "Description")]
        [DataType(DataType.MultilineText)]
        public string CourseDescription { get; set; }

      //  [NotMapped]
        public string CourseAssignTo { get; set; }

       // [NotMapped]
        public bool CourseStatus { get; set; }

        [Display(Name = "Department")]
        public int DepartmentId { get; set; }

        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }

        [Display(Name = "Semester")]
        public int SemesterId { get; set; }

        [ForeignKey("SemesterId")]
        public virtual Semester Semester { get; set; }


    }
}