using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudCoreMVC.ViewModels
{
    public class StudentViewModel
    {
        public int Id { get; set; }
        public string StudentFullName { get; set; }
        public object StudentName { get; internal set; }
    }
}
