using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudCoreMVC.Models;
using CrudCoreMVC.ViewModels;

namespace CrudCoreMVC.Services
{
    public interface ITeacherService
    {
        List<Teacher> GetAllTeachers();
        void AddTeacher(Teacher teacher);
        Teacher GetSingleTeacherById(int id);
        void UpdateTeacher(Teacher newTeacher);
        void DeleteTeacher(int id);
        List<Student> GetStudentsByTeacherId(int teacherId);
        TeacherViewModel TeacherDeletionConfirmation(int id);
        TeacherViewModel TeacherDetails(int id);
        
    }
}
