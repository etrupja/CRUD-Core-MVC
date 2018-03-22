using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrudCoreMVC.Models
{
    public class School
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Hey, please provide a name!")]
        [StringLength(20, ErrorMessage = "The name is too long.")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Hey, please provide an address!")]
        public string Address { get; set; }
        [Display(Name = "Founding year")]
        public DateTime FoundingYear { get; set; }
        [Display(Name = "Number of students")]
        public int NumberOfStudents { get; set; }

        //Relations
        public List<Teacher> Teachers { get; set; }

    }
}
