using System;
using System.Collections.Generic;
using System.Text;
using DomainLayer.Entities;

namespace ServiceLayer.Services.Interfaces
{
    public interface IGroupService
    {
        CourseGroup Create(CourseGroup group);
        CourseGroup Update(int id, CourseGroup group);
        bool Delete(CourseGroup group);
        CourseGroup GetById(int id);
        List<CourseGroup> GetAll();
        List<CourseGroup> GetAllByTeacher(string teacher);
        List<CourseGroup> GetAllByRoom(string room);
        List<CourseGroup> SearchByName(string name);
    }
}
