using System;
using System.Collections.Generic;
using System.Text;
using DomainLayer.Entities;
namespace RepositoryLayer.Repositories.Interfaces
{
    public interface IGroupRepository : IRepository<CourseGroup>
    {
        List<CourseGroup> GetAll(Predicate<CourseGroup> predicate);
        List<CourseGroup> GetAllByTeacher(string teacher);
        List<CourseGroup> GetAllByRoom(int room);
        List<CourseGroup> SearchByName(string name);

       
    }
}
