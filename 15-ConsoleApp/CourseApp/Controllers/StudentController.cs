using CourseApp.Helpers;
using DomainLayer.Entities;
using RepositoryLayer.Exceptions;
using ServiceLayer.Services.Implementations;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseApp.Controllers
{
    public class StudentController
    {
        static StudentService _studentService = new StudentService();
        public void CreateStudent()
        {
            try
            {
                Helper.PrintConsole(ConsoleColor.Magenta, "Enter Student Name:");
                string name = Console.ReadLine();

                Helper.PrintConsole(ConsoleColor.Magenta, "Enter Student Surname:");
                string surname = Console.ReadLine();

                int age;
                while (true)
                {
                    Helper.PrintConsole(ConsoleColor.Magenta, "Enter Student Age:");
                    string ageInput = Console.ReadLine();

                    if (int.TryParse(ageInput, out age))
                    {
                        break;
                    }
                    else
                    {
                        Helper.PrintConsole(ConsoleColor.Red, "Age must be a number!");
                    }
                }

                Helper.PrintConsole(ConsoleColor.Magenta, "Enter Group ID:");
                if (!int.TryParse(Console.ReadLine(), out int groupId))
                    throw new InvalidFormatException("Group ID must be a number!");

                Student student = new Student
                {
                    Name = name,
                    Surname = surname,
                    Age = age
                };

                _studentService.Create(student, groupId);
                Helper.PrintConsole(ConsoleColor.Green, "Student successfully created!");
            }
            catch (Exception ex)
            {
                Helper.PrintConsole(ConsoleColor.Red, ex.Message);
            }
        }
        public void UpdateStudent()
        {
            try
            {
                Helper.PrintConsole(ConsoleColor.Magenta, "Enter Student ID to update:");
                if (!int.TryParse(Console.ReadLine(), out int id))
                    throw new InvalidFormatException("ID must be a number!");

                Helper.PrintConsole(ConsoleColor.Magenta, "Enter New Name:");
                string name = Console.ReadLine();

                Helper.PrintConsole(ConsoleColor.Magenta, "Enter New Surname:");
                string surname = Console.ReadLine();

                Helper.PrintConsole(ConsoleColor.Magenta, "Enter New Age:");
                if (!int.TryParse(Console.ReadLine(), out int age))
                    throw new InvalidFormatException("Age must be a number!");

                Student updatedData = new Student { Name = name, Surname = surname, Age = age };
                _studentService.Update(id, updatedData);

                Helper.PrintConsole(ConsoleColor.Green, "Student updated successfully!");
            }
            catch (Exception ex)
            {
                Helper.PrintConsole(ConsoleColor.Red, ex.Message);
            }
        }
        public void DeleteStudent()
        {
            try
            {
                Helper.PrintConsole(ConsoleColor.Magenta, "Enter Student ID to delete:");
                if (!int.TryParse(Console.ReadLine(), out int id))
                    throw new InvalidFormatException("ID must be a number!");

                _studentService.Delete(id);
                Helper.PrintConsole(ConsoleColor.Green, "Student deleted successfully!");
            }
            catch (Exception ex)
            {
                Helper.PrintConsole(ConsoleColor.Red, ex.Message);
            }
        }
        public void GetStudentById()
        {
            try
            {
                Helper.PrintConsole(ConsoleColor.Magenta, "Enter Student ID:");
                if (!int.TryParse(Console.ReadLine(), out int id))
                    throw new InvalidFormatException("ID must be a number!");

                var s = _studentService.GetById(id);
                Console.WriteLine($"ID: {s.Id} - Name: {s.Name} {s.Surname} - Age: {s.Age} - Group: {s.Group.Name}");
            }
            catch (Exception ex)
            {
                Helper.PrintConsole(ConsoleColor.Red, ex.Message);
            }
        }
        public void GetStudentsByAge()
        {
            try
            {
                Helper.PrintConsole(ConsoleColor.Magenta, "Enter Age to filter:");
                if (!int.TryParse(Console.ReadLine(), out int age))
                    throw new InvalidFormatException("Age must be a number!");

                var students = _studentService.GetAllByAge(age);
                Helper.PrintConsole(ConsoleColor.Cyan, $"Students with age {age}:");
                foreach (var s in students)
                {
                    Console.WriteLine($"{s.Name} {s.Surname}");
                }
            }
            catch (Exception ex)
            {
                Helper.PrintConsole(ConsoleColor.Red, ex.Message);
            }
        }
        public void GetStudentsByGroupId()
        {
            try
            {
                Helper.PrintConsole(ConsoleColor.Magenta, "Enter Group ID:");
                if (!int.TryParse(Console.ReadLine(), out int gId))
                    throw new InvalidFormatException("Group ID must be a number!");

                var students = _studentService.GetAllByGroupId(gId);
                Helper.PrintConsole(ConsoleColor.Cyan, "Group Members:");
                foreach (var s in students)
                {
                    Console.WriteLine($"{s.Id}. {s.Name} {s.Surname}");
                }
            }
            catch (Exception ex)
            {
                Helper.PrintConsole(ConsoleColor.Red, ex.Message);
            }
        }
        public void SearchStudentNameOrSurname()
        {
            try
            {
                Helper.PrintConsole(ConsoleColor.Magenta, "Enter search text (Name/Surname):");
                string text = Console.ReadLine();
                var results = _studentService.SearchByNameOrSurname(text);

                foreach (var s in results)
                {
                    Console.WriteLine($"ID: {s.Id} - {s.Name} {s.Surname} - Group: {s.Group.Name}");
                }
            }
            catch (Exception ex)
            {
                Helper.PrintConsole(ConsoleColor.Red, ex.Message);
            }
        }
    }
    
}
