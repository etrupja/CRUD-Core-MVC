using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudCoreMVC.Models;

namespace CrudCoreMVC.ViewModels
{
    public class TeacherViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public List<Student> Students { get; set; }
        public object TeacherName { get; internal set; }
    }
}
