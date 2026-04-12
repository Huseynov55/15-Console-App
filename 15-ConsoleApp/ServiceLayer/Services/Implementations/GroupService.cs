using DomainLayer.Entities;
using RepositoryLayer.Exceptions;
using RepositoryLayer.Repositories.Implementations;
using RepositoryLayer.Repositories.Interfaces;
using ServiceLayer.Exceptions;
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
            var allGroups = _groupRepository.GetAll(x => true);

            bool isRoomBusy = allGroups.Any(g => g.Room == group.Room);

            if (isRoomBusy)
            {
                throw new IsFullException($"Room {group.Room} is already full!");
            }


            group.Id = _count;
            _groupRepository.Create(group);
            _count++;
            return group;
        }

        public bool Delete(int id)
        {
            CourseGroup existGroup = _groupRepository.GetById(id);
            if (existGroup == null) throw new NotFoundException("Group not found!");
            _groupRepository.Delete(existGroup);
            return true;
        }

        public List<CourseGroup> GetAll()
        {
            return _groupRepository.GetAll(x => true);
        }

        public List<CourseGroup> GetAllByRoom(int room)
        {
            return _groupRepository.GetAllByRoom(room);
        }

        public List<CourseGroup> GetAllByTeacher(string teacher)
        {
            return _groupRepository.GetAllByTeacher(teacher);
        }

        public CourseGroup GetById(int id)
        {
            var group = _groupRepository.GetById(id);
            if (group == null) throw new NotFoundException("Group not found!");
            return group;
        }

        public List<CourseGroup> SearchByName(string name)
        {
            var results = _groupRepository.SearchByName(name);
            if (results.Count == 0) throw new NotFoundException($"No group found with name '{name}'");
            return results;
        }

        public CourseGroup Update(int id, CourseGroup group)
        {
            CourseGroup existGroup = _groupRepository.GetById(id);
            if (existGroup == null) throw new NotFoundException("Group not found!");

            group.Id = id;
            _groupRepository.Update(group);
            return group;
        }
    }
}
