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
        private GroupRepository _groupRepository;

        public StudentService()
        {
            _studentRepository = new StudentRepository();
        }
        public Student Create(Student student, int groupId)
        {
            var group = _groupRepository.GetById(groupId);
            if (group == null) throw new Exception("Qrup tapilmadi!");
            student.Id = _count;
            student.Group = group;
            _studentRepository.Create(student);
            _count++;
            return student;
        }

        public bool Delete(Student data)
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
