using DomainLayer.Entities;
using RepositoryLayer.Data;
using RepositoryLayer.Exceptions;
using RepositoryLayer.Repositories.Implementations;
using RepositoryLayer.Repositories.Interfaces;
using ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Services.Implementations
{
    public class StudentService : IStudentService
    {
        private int _count = 1;
        private StudentRepository _studentRepository;
        public Student Create(Student student, int groupId)
        {
            student.Id = _count;
            _count++;
            return student;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Student> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Student> GetAllByAge(int age)
        {
            throw new NotImplementedException();
        }

        public List<Student> GetAllByGroupId(int groupId)
        {
            throw new NotImplementedException();
        }

        public Student GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Student> SearchByNameOrSurname(string text)
        {
            throw new NotImplementedException();
        }

        public Student Update(int id, Student student)
        {
            throw new NotImplementedException();
        }
    }
}
