using DomainLayer.Entities;
using RepositoryLayer.Data;
using RepositoryLayer.Exceptions;
using RepositoryLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Repositories.Implementations
{
    public class StudentRepository : IStudentRepository
    {
        public void Create(Student data)
        {
            try
            {
                if (data is null) throw new NotFoundException("Data not found!!!");

                AppDbContext<Student>.datas.Add(data);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        public void Delete(Student data)
        {
            throw new NotImplementedException();
        }

        public List<Student> GetAll(Predicate<Student> predicate, int id)
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

        public void Update(Student data)
        {
            throw new NotImplementedException();
        }
    }
}
