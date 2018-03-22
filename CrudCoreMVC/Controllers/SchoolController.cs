using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudCoreMVC.Data;
using CrudCoreMVC.Models;
using CrudCoreMVC.Services;
using CrudCoreMVC.ViewModels;


namespace CrudCoreMVC.Controllers
{
    [Authorize]
    public class SchoolController : Controller
    {

        private ISchoolService _schoolService;
        public SchoolController(ISchoolService schoolService)
        {
            _schoolService = schoolService;
        }
        [AllowAnonymous]
        public IActionResult All()
        {
            return View(_schoolService.GetAllSchools());
        }
        public IActionResult CreateSchool() => View();
        public IActionResult SchoolCreated(School school)
        {

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Something went wrong!");
                return View("CreateSchool");
            }
            _schoolService.AddSchool(school);
            return View();
        }


        public IActionResult EditSchool(int id) => View(_schoolService.GetSingleSchoolById(id));


        public IActionResult SchoolEdited(School newSchool)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Something went wrong!");
                return View("EditSchool", newSchool);
            }
            _schoolService.UpdateSchool(newSchool);

            return View();

        }

        public IActionResult DeleteSchool(int id) => View(_schoolService.SchoolDeletionConfirmation(id));


        public IActionResult SchoolDeleted(int id)
        {
            _schoolService.DeleteSchool(id);
            return View();
        }

        public IActionResult SchoolDetails(int id)
        {

            return View(_schoolService.SchoolDetails(id));
        }

        [Route("/search/{name}")]
        public IActionResult Search(string name)
        {
            string searchName = name;
            return View();
        }
    }
}
