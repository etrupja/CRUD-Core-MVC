using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudCoreMVC.Data;
using CrudCoreMVC.Models;
using CrudCoreMVC.ViewModels;

namespace CrudCoreMVC.Services
{
    public class SchoolService : ISchoolService
    {
        private AppDbContext _context;
        public SchoolService(AppDbContext context)
        {
            _context = context;
        }
        public void AddSchool(School school)
        {
            _context.Schools.Add(school);
            _context.SaveChanges();
        }

        public void DeleteSchool(int id)
        {
            School schoolToBeDeleted = GetSingleSchoolById(id);
            _context.Schools.Remove(schoolToBeDeleted);
            _context.SaveChanges();
        }

        public List<School> GetAllSchools()
        {
           return _context.Schools.ToList();
        }

        public School GetSingleSchoolById(int id) => _context.Schools.Where(n => n.Id == id).FirstOrDefault();

        public List<Teacher> GetTeachersBySchoolId(int schoolId) => _context.Teachers.Where(n => n.SchoolId == schoolId).ToList();
        

        public void UpdateSchool(School newSchool)
        {
            School oldSchool = GetSingleSchoolById(newSchool.Id);
            oldSchool.Address = newSchool.Address;
            oldSchool.FoundingYear = newSchool.FoundingYear;
            oldSchool.Name = newSchool.Name;
            oldSchool.NumberOfStudents = newSchool.NumberOfStudents;
            _context.SaveChanges();
        }

        public SchoolViewModel SchoolDeletionConfirmation(int id)
        {

            School school = GetSingleSchoolById(id);
            SchoolViewModel schoolVM = new SchoolViewModel()
            {
                Id = school.Id,
                SchoolName = school.Name
            };

            return schoolVM;

        }

        public SchoolViewModel SchoolDetails(int id)
        {
            School school = GetSingleSchoolById(id);
            SchoolViewModel schoolVM = new SchoolViewModel()
            {
                SchoolName = school.Name,
                Teachers = GetTeachersBySchoolId(id)
            };
            return schoolVM;

        }
    }
}
