using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;    //allows us to markup properties with specified data types
using System.ComponentModel.DataAnnotations.Schema; //allows us to enter more things specific to the database vut not necessarily visual studio.. note line 16

namespace WSU.Models
{
    public class Student
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters", MinimumLength = 1)]
        [Display(Name = "First Name")]
        [Column("FirstName")]
        public string FirstMidName { get; set; }
            
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Enrollment Date")]
        public DateTime EnrollmentDate { get; set; }
        [Display(Name = "Full Name")]
        public string FullName {
            get
            { return LastName + ", " + FirstMidName; }
        }
        public virtual ICollection<Enrollment>  Enrollments { get; set; }
    }
}