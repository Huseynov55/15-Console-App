using DomainLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Repositories.Interfaces
{
    public interface IStudentRepository : IRepository<Student>
    {
        List<Student> GetAll(Predicate<Student> predicate, int id);
        List<Student> GetAllByAge(int age);
        List<Student> GetAllByGroupId(int groupId);
        List<Student> SearchByNameOrSurname(string text);
    }
}
