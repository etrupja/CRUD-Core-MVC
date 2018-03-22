using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudCoreMVC.Models;

namespace CrudCoreMVC.ViewModels
{
    public class SchoolViewModel
    {
        public int Id { get; set; }
        public string SchoolName { get; set; }
        public List<Teacher> Teachers { get; set; }
    }
}
