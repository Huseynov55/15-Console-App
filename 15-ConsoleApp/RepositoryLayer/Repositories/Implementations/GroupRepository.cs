using DomainLayer.Entities;
using RepositoryLayer.Data;
using RepositoryLayer.Exceptions;
using RepositoryLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace RepositoryLayer.Repositories.Implementations
{
    public class GroupRepository : IGroupRepository
    {
        public void Create(CourseGroup data)
        {
            try
            {
                if (data is null) throw new NotFoundException("Data not found!!!");

                AppDbContext<CourseGroup>.datas.Add(data);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        public void Delete(CourseGroup data)
        {
            AppDbContext<CourseGroup>.datas.Remove(data);
        }

        public List<CourseGroup> GetAll(Predicate<CourseGroup> predicate)
        {
            return AppDbContext<CourseGroup>.datas;
        }

        public List<CourseGroup> GetAllByRoom(int room)
        {
            return AppDbContext<CourseGroup>.datas.FindAll(m => m.Room == room);
        }

        public List<CourseGroup> GetAllByTeacher(string teacher)
        {
            return AppDbContext<CourseGroup>.datas.FindAll(m => m.Teacher.ToLower().Contains(teacher.ToLower()));
        }


        public CourseGroup GetById(int id)
        {
            return AppDbContext<CourseGroup>.datas.Find(m => m.Id == id);
        }

        public List<CourseGroup> SearchByName(string name)
        {
            return AppDbContext<CourseGroup>.datas.FindAll(m => m.Name.ToLower().Contains(name.ToLower()));
        }

        public void Update(CourseGroup data)
        {
            CourseGroup existGroup = GetById(data.Id);
            existGroup.Name = data.Name;
            existGroup.Room = data.Room;
            existGroup.Teacher = data.Teacher;
        }
    }
}
