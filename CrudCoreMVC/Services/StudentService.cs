using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudCoreMVC.Data;
using CrudCoreMVC.Models;
using CrudCoreMVC.ViewModels;

namespace CrudCoreMVC.Services
{
    public class StudentService : IStudentService
    {
        private AppDbContext _context;
        public StudentService(AppDbContext context)
        {
            _context = context;
        }
        public void AddStudent(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
        }

        public void DeleteStudent(int id)
        {
            Student studentToBeDeleted = GetSingleStudentById(id);
            _context.Students.Remove(studentToBeDeleted);
            _context.SaveChanges();
        }

        public List<Student> GetAllStudents()
        {
            List<Student> students = _context.Students.Include(n => n.Teacher).ToList();
            return students;
        }

        public Student GetSingleStudentById(int id) => _context.Students.Where(n => n.Id == id).FirstOrDefault();

        

        public void UpdateStudent(Student newStudent)
        {
            Student oldStudent = GetSingleStudentById(newStudent.Id);
            oldStudent.FullName = newStudent.FullName;
            oldStudent.MiddleName = newStudent.MiddleName;
            oldStudent.EmailAddress = newStudent.EmailAddress;
            oldStudent.Age = newStudent.Age;
            oldStudent.Birthday = newStudent.Birthday;
            oldStudent.GPA = newStudent.GPA;
            oldStudent.TeacherId = newStudent.TeacherId;
            _context.SaveChanges();
        }

        public StudentViewModel StudentDeletionConfirmation(int id)
        {

            Student student = GetSingleStudentById(id);
            StudentViewModel studentVM = new StudentViewModel()
            {
                Id = student.Id,
                StudentName = student.FullName
            };

            return studentVM;

        }
    }
}
