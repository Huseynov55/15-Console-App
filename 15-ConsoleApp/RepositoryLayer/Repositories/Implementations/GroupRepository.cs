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
            throw new NotImplementedException();
        }

        public List<CourseGroup> GetAll(Predicate<CourseGroup> predicate)
        {
            throw new NotImplementedException();
        }

        public List<CourseGroup> GetAllByRoom(string room)
        {
            throw new NotImplementedException();
        }

        public List<CourseGroup> GetAllByTeacher(string teacher)
        {
            throw new NotImplementedException();
        }

        public CourseGroup GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<CourseGroup> SearchByName(string name)
        {
            throw new NotImplementedException();
        }

        public void Update(CourseGroup data)
        {
            throw new NotImplementedException();
        }
    }
}
