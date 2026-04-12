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
            AppDbContext<Student>.datas.Remove(data);
        }

        public List<Student> GetAll(Predicate<Student> predicate, int id)
        {
            return predicate == null
           ? AppDbContext<Student>.datas
           : AppDbContext<Student>.datas.FindAll(predicate);
        }


        public List<Student> GetAllByAge(int age)
        {
            return AppDbContext<Student>.datas.Where(m => m.Age == age).ToList();
        }

        public List<Student> GetAllByGroupId(int groupId)
        {
            return AppDbContext<Student>.datas.Where(m => m.Group.Id == groupId).ToList();
        }

        public Student GetById(int id)
        {
            return AppDbContext<Student>.datas.FirstOrDefault(m => m.Id == id);
        }

        public List<Student> SearchByNameOrSurname(string text)
        {
            return AppDbContext<Student>.datas
                .Where(m => m.Name.ToLower().Contains(text.ToLower()) ||
                            m.Surname.ToLower().Contains(text.ToLower())).ToList();
        }

        public void Update(Student data)
        {
            Student existStudent = GetById(data.Id);
            if (existStudent != null)
            {
                existStudent.Name = data.Name;
                existStudent.Surname = data.Surname;
                existStudent.Age = data.Age;
                existStudent.Group = data.Group;
            }
        }
    }
}
