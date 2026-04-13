using CourseApp.Helpers;
using DomainLayer.Entities;
using RepositoryLayer.Exceptions;
using ServiceLayer.Exceptions;
using ServiceLayer.Services.Implementations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CourseApp.Controllers
{
    public class GroupController
    {

        static GroupService _groupService = new GroupService();
        public void CreateGroup()
        {
        Name: Helper.PrintConsole(ConsoleColor.Magenta, "Add Group Name:");
            string groupName = Console.ReadLine();
            if (string.IsNullOrEmpty(groupName))
            {
                Helper.PrintConsole(ConsoleColor.Red, "Group name is empty");
                goto Name;
            }

        Teacher: Helper.PrintConsole(ConsoleColor.Magenta, "Add Group Teacher:");
            string groupTeacher = Console.ReadLine();
            if (string.IsNullOrEmpty(groupTeacher))
            {
                Helper.PrintConsole(ConsoleColor.Red, "Teacher name is empty");
                goto Teacher;
            }


            bool isAdded = false;
            while (!isAdded)
            {
                Helper.PrintConsole(ConsoleColor.Magenta, "Add Group Room:");
                string roomInput = Console.ReadLine();

                if (int.TryParse(roomInput, out int groupRoomNum))
                {
                    try
                    {
                        CourseGroup group = new CourseGroup
                        {
                            Name = groupName,
                            Room = groupRoomNum,
                            Teacher = groupTeacher
                        };

                        _groupService.Create(group);

                        Helper.PrintConsole(ConsoleColor.Green, "Successfully Added!");
                        isAdded = true;
                    }
                    catch (IsFullException ex)
                    {

                        Helper.PrintConsole(ConsoleColor.Red, ex.Message);
                        Helper.PrintConsole(ConsoleColor.Yellow, "Please enter a different room number.");
                    }
                }
                else
                {
                    Helper.PrintConsole(ConsoleColor.Red, "Room must be a number! Try again.");
                }
            }
        }
        public void UpdateGroup()
        {
            Helper.PrintConsole(ConsoleColor.Magenta, "Enter Group Id to update:");
            string idInput = Console.ReadLine();
            

            if (int.TryParse(idInput, out int updateId))
            {
                try
                {
                    var existGroup = _groupService.GetById(updateId);

                NewName: Helper.PrintConsole(ConsoleColor.Magenta, "New Name:");
                    string newName = Console.ReadLine();
                    if (string.IsNullOrEmpty(newName))
                    {
                        Helper.PrintConsole(ConsoleColor.Red, "Group name is empty");
                        goto NewName;
                    }

                NewTeacher: Helper.PrintConsole(ConsoleColor.Magenta, "New Teacher:");
                    string newTeacher = Console.ReadLine();
                    if (string.IsNullOrEmpty(newTeacher))
                    {
                        Helper.PrintConsole(ConsoleColor.Red, "Teacher name is empty");
                        goto NewTeacher;
                    }

                    int newRoomNum;
                    while (true)
                    {
                        Helper.PrintConsole(ConsoleColor.Magenta, "New Room Number:");
                        string roomInput = Console.ReadLine();

                        if (int.TryParse(roomInput, out newRoomNum))
                        {
                            break;
                        }
                        else
                        {
                            Helper.PrintConsole(ConsoleColor.Red, "Room must be a number! Please try again.");
                        }
                    }

                    CourseGroup updatedGroup = new CourseGroup
                    {
                        Name = newName,
                        Teacher = newTeacher,
                        Room = newRoomNum
                    };

                    _groupService.Update(updateId, updatedGroup);
                    Helper.PrintConsole(ConsoleColor.Green, "Group successfully updated!");
                }
                catch (NotFoundException ex)
                {
                    Helper.PrintConsole(ConsoleColor.Red, ex.Message);
                }
                catch (Exception ex)
                {
                    Helper.PrintConsole(ConsoleColor.Red, "An error occurred: " + ex.Message);
                }
            }
            else
            {
                Helper.PrintConsole(ConsoleColor.Red, "Invalid Id format!");
            }
        }
        public void DeleteGroup()
        {
            Helper.PrintConsole(ConsoleColor.Red, "Enter Id to delete:");
            if (int.TryParse(Console.ReadLine(), out int delId))
            {
                _groupService.Delete(delId);
                Helper.PrintConsole(ConsoleColor.Green, "Deleted!");
            }
        }
        public void GetGroupById()
        {
            Helper.PrintConsole(ConsoleColor.Magenta, "Enter Id:");
            if (int.TryParse(Console.ReadLine(), out int gId))
            {
                var g = _groupService.GetById(gId);
                Console.WriteLine($"{g.Id} - {g.Name} - {g.Teacher}");
            }
        }
        public void GetGroupByTeacher()
        {
            Helper.PrintConsole(ConsoleColor.Magenta, "Enter Teacher Name:");
            string teacherName = Console.ReadLine();

            var groupsByTeacher = _groupService.GetAllByTeacher(teacherName);

            if (groupsByTeacher.Count > 0)
            {
                Helper.PrintConsole(ConsoleColor.Green, $"Groups taught by {teacherName}:");
                foreach (var item in groupsByTeacher)
                {
                    Console.WriteLine($"ID: {item.Id} | Name: {item.Name} | Room: {item.Room}");
                }
            }
            else
            {
                Helper.PrintConsole(ConsoleColor.Red, "No groups found for this teacher.");
            }
        }
        public void GetGroupByRoom()
        {
            Helper.PrintConsole(ConsoleColor.Magenta, "Enter Room Number:");
            string roomInput = Console.ReadLine();

            if (int.TryParse(roomInput, out int roomNum))
            {
                var groupsByRoom = _groupService.GetAllByRoom(roomNum);

                if (groupsByRoom.Count > 0)
                {
                    Helper.PrintConsole(ConsoleColor.Green, $"Groups in Room {roomNum}:");
                    foreach (var item in groupsByRoom)
                    {
                        Console.WriteLine($"ID: {item.Id} Name: {item.Name} Teacher: {item.Teacher}");
                    }
                }
                else
                {
                    Helper.PrintConsole(ConsoleColor.Red, "No groups found in this room.");
                }
            }
            else
            {
                Helper.PrintConsole(ConsoleColor.Red, "Invalid input! Room must be a number.");
            }
        }
        public void GetAllGroups()
        {
            var groups = _groupService.GetAll();
            foreach (var item in groups)
            {
                Console.WriteLine($"Id: {item.Id} - Name: {item.Name} - Room: {item.Room} - Teacher: {item.Teacher}");
            }
        }
        public void SearchGroupByName()
        {
            Helper.PrintConsole(ConsoleColor.Magenta, "Search name:");
            string searchName = Console.ReadLine();

            try
            {
                var sResults = _groupService.SearchByName(searchName);

                Helper.PrintConsole(ConsoleColor.Green, "Groups found:");
                foreach (var item in sResults)
                {
                    Console.WriteLine(item.Name);
                }
            }
            catch (NotFoundException ex)
            {
                Helper.PrintConsole(ConsoleColor.Red, ex.Message);
            }
        }
    }
}
