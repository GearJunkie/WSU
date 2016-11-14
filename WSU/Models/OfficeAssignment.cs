using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WSU.Models
{
    public class OfficeAssignment
    {
        [Key]
        [ForeignKey("Instructor")]  //how to allow a table to have a foreign key as a primary key, looks for instructorID in "Instructor" table
        public int InstructorID { get; set; }
        [StringLength(50)]
        [Display(Name = "Office Location")]
        public string Location { get; set; }
        public virtual Instructor Instructor { get; set; }
    }
}