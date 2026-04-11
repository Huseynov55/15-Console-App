using DomainLayer.Entities;
using RepositoryLayer.Repositories.Implementations;
using RepositoryLayer.Repositories.Interfaces;
using ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ServiceLayer.Services.Implementations
{
    public class GroupService : IGroupService
    {

        private int _count = 1;
        private GroupRepository _groupRepository;

        public GroupService()
        {
            _groupRepository = new GroupRepository();
        }
        public CourseGroup Create(CourseGroup group)
        {
            group.Id = _count;
            _groupRepository.Create(group);
            _count++;
            return group;
        }

        public bool Delete(CourseGroup group)
        {
            throw new NotImplementedException();
        }

        public List<CourseGroup> GetAll()
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

        public CourseGroup Update(int id, CourseGroup group)
        {
            throw new NotImplementedException();
        }
    }
}
