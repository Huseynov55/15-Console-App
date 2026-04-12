using DomainLayer.Entities;
using RepositoryLayer.Data;
using RepositoryLayer.Exceptions;
using RepositoryLayer.Repositories.Implementations;
using RepositoryLayer.Repositories.Interfaces;
using ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ServiceLayer.Services.Implementations
{
    public class StudentService : IStudentService
    {
        private int _count = 1;
        private StudentRepository _studentRepository;
        private GroupRepository _groupRepository;

        public StudentService()
        {
            _studentRepository = new StudentRepository();
            _groupRepository = new GroupRepository();
        }
        public Student Create(Student student, int groupId)
        {
            var group = _groupRepository.GetById(groupId);
            if (group == null)
                throw new NotFoundException("Group not found! A valid group is required to add a student.");

            
            if (student.Age < 18)
                throw new InvalidFormatException("Age must be 18 or older to register!");

            student.Id = _count++;
            student.Group = group;
            _studentRepository.Create(student);
            return student;
        }

        public bool Delete(int id)
        {
            var student = GetById(id);
            _studentRepository.Delete(student);
            return true;
        }

        public List<Student> GetAll()
        {
            var students = _studentRepository.GetAll(null, 0);
            if (students == null || students.Count == 0)
            {
                throw new NotFoundException("Student not found!");
            }

            return students;
        }

        public List<Student> GetAllByAge(int age)
        {
            var students = _studentRepository.GetAllByAge(age);

            if (students == null || students.Count == 0)
            {
                throw new NotFoundException($"No student found at {age} years old.");
            }

            return students;
        } 

        public List<Student> GetAllByGroupId(int groupId) => _studentRepository.GetAllByGroupId(groupId);


        public Student GetById(int id)
        {
            var student = _studentRepository.GetById(id);
            if (student == null) throw new NotFoundException("Student not found!");
            return student;
        }

        public List<Student> SearchByNameOrSurname(string text)
        {
            var results = _studentRepository.SearchByNameOrSurname(text);
            if (results.Count == 0) throw new NotFoundException("No student matching the search was found.");
            return results;
        }

        public Student Update(int id, Student student)
        {
            var existStudent = GetById(id);
            var group = _groupRepository.GetById(id);
            if (group == null) throw new NotFoundException("New group not found!");

            student.Id = id;
            student.Group = group;
            _studentRepository.Update(student);
            return student;
        }
    }
}
