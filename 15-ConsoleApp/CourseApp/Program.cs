using CourseApp.Helpers;
using DomainLayer.Entities;
using ServiceLayer.Services.Implementations;

namespace CourseApp
{
    public class Program
    {
        static GroupService _groupService = new GroupService();
        static StudentService _studentService = new StudentService();
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
            Helper.PrintConsole(ConsoleColor.Cyan, "\nGroup Operations:");
            Helper.PrintConsole(ConsoleColor.Yellow, "1-Create Group \n2-Update Group \n3-Delete Group \n4-Get Group by Id \n5-Get Groups by Teacher \n6-Get Groups by Room \n7-Get all Groups \n8-Search Group by Name");



            string selectOption = Console.ReadLine();


            switch (selectOption)
            {
                case "1":
                    Helper.PrintConsole(ConsoleColor.Magenta, "Add Group Name:");
                    string groupName = Console.ReadLine();

                    Helper.PrintConsole(ConsoleColor.Magenta, "Add Group Teacher:");
                    string groupTeacher = Console.ReadLine();

                    Helper.PrintConsole(ConsoleColor.Magenta, "Add Group Room:");


                    if (int.TryParse(Console.ReadLine(), out int groupRoomNum))
                    {
                        CourseGroup group = new CourseGroup { Name = groupName, Room = groupRoomNum, Teacher = groupTeacher };
                        _groupService.Create(group);
                        Helper.PrintConsole(ConsoleColor.Green, "Successfully Added!");
                    }
                    else
                    {
                        Helper.PrintConsole(ConsoleColor.Red, "Room must be a number!");
                    }
                    break;
                case "2":



                    break;
            }

        }


        static void StudentMenu()
        {
            Helper.PrintConsole(ConsoleColor.Cyan, "\nStudent Operations:");
            Helper.PrintConsole(ConsoleColor.Yellow, "1-Create Student \n2-Update Student \n3-Delete Student \n4-Get Student by Id \n5-Get Students by Age \n6-Get Students by Group Id \n7-Search Student by Name or Surname");
        }
    }
}
