using CourseApp.Controllers;
using CourseApp.Helpers;
using DomainLayer.Entities;
using ServiceLayer.Exceptions;
using ServiceLayer.Services.Implementations;

namespace CourseApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Helper.PrintConsole(ConsoleColor.Magenta, "--- MAIN MENU ---");
            Helper.PrintConsole(ConsoleColor.Magenta, "Select one option:");
            Helper.PrintConsole(ConsoleColor.Blue, "1-Group \n2-Student");

            while (true)
            {
                string selectOption = Console.ReadLine();

                int selectNumber;
                bool isSelectOption = int.TryParse(selectOption, out selectNumber);

                if (isSelectOption)
                {
                    switch (selectNumber)
                    {
                        case 1:
                            GroupMenu();
                            break;
                        case 2:
                            StudentMenu();
                            break;
                        default:
                            Helper.PrintConsole(ConsoleColor.Red, "Wrong Selection!!!");
                            break;
                    }
                }
            }
        }
        static void GroupMenu()
        {
            GroupController _groupController = new GroupController();
            Helper.PrintConsole(ConsoleColor.Cyan, "\nGroup Operations:");
            Helper.PrintConsole(ConsoleColor.Yellow, "1-Create Group \n2-Update Group \n3-Delete Group \n4-Get Group by Id" +
                " \n5-Get Groups by Teacher \n6-Get Groups by Room \n7-Get all Groups \n8-Search Group by Name");



            string selectOption = Console.ReadLine();


            switch (selectOption)
            {
                case "1":
                    _groupController.CreateGroup();
                    break;
                case "2":
                    _groupController.UpdateGroup();
                    break;
                case "3":
                    _groupController.DeleteGroup();
                    break;
                case "4":
                    _groupController.GetGroupById();
                    break;
                case "5":
                    _groupController.GetGroupByTeacher();
                    break;
                case "6":
                    _groupController.GetGroupByRoom();
                    break;
                case "7":
                    _groupController.GetAllGroups();
                    break;
                case "8":
                    _groupController.SearchGroupByName();    
                    break;
            }

        }


        static void StudentMenu()
        {
            StudentController _studentController = new StudentController();

            Helper.PrintConsole(ConsoleColor.Cyan, "\nStudent Operations:");
            Helper.PrintConsole(ConsoleColor.Yellow, "1-Create Student \n2-Update Student \n3-Delete Student" +
                " \n4-Get Student by Id \n5-Get Students by Age \n6-Get Students by Group Id " +
                "\n7-Search Student by Name or Surname");

            string selectOption = Console.ReadLine();


            switch (selectOption) 
            { 
                case "1":
                    _studentController.CreateStudent();
                    break;
                case "2":
                    _studentController.UpdateStudent();
                    break;
                case "3":
                    _studentController.DeleteStudent();
                    break;
                case "4":
                    _studentController.GetStudentById();
                    break;
                case "5":
                    _studentController.GetStudentsByAge();
                    break;
                case "6":
                    _studentController.GetStudentsByGroupId();
                    break;
                case "7":
                    _studentController.SearchStudentNameOrSurname();
                    break;

            }
        }
    }
}
