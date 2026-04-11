using DomainLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Services.Interfaces
{
    public interface IStudentService
    {
        Student Create(Student student, int groupId);
        Student Update(int id, Student student);
        bool Delete(Student data);
        Student GetById(int id);
        List<Student> GetAll(); 
        List<Student> GetAllByAge(int age);
        List<Student> GetAllByGroupId(int groupId);
        List<Student> SearchByNameOrSurname(string text);
    }
}
