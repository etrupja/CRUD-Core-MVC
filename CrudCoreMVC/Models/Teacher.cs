using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrudCoreMVC.Models
{
    public class Teacher
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter your name.")]
        [DataType(DataType.Text)]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        [Range(25,70, ErrorMessage = "Please provide an age between 25 and 70.")]
        public int Age { get; set; }
        [Required]
        [Display(Name = "Years of experience")]
        public double YearsOfExperience { get; set; }

        [DataType(DataType.PhoneNumber, ErrorMessage = "Please provide a valid phone number")]
        [Phone(ErrorMessage ="Not a valid phone number")]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }
        public string Subject { get; set; }


        // Relations
        public virtual School School { get; set; }
        [Display(Name = "School Name")]
        public int SchoolId { get; set; }

        public List<Student> Students { get; set; }

    }
}


