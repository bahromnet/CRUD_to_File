using _3_Modul.Lesson_8_February_10_2023.LessonTasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_To_File
{
    internal class RunProject
    {
        public static AddFiles addFiles = new();
        public static void Run()
        {
            addFiles.AddToListAllItems();
            
            Console.Clear();

            Console.WriteLine("----------------------");
            Console.WriteLine("1. Add User");
            Console.WriteLine("2. Delete User");
            Console.WriteLine("3. Update User");
            Console.WriteLine("4. Show Users");
            Console.WriteLine("0. Exit");
            Console.WriteLine("----------------------");
            Console.Write(">> ");
            if (!int.TryParse(Console.ReadLine(), out int a))
            {
                Console.Clear();
                Console.WriteLine("To'g'ri formatda kiriting");
                Run();
            }
            switch (a)
            {
                case 1:
                    {
                        Console.Clear();
                        Console.WriteLine("<==== Add User ====>");
                        Console.WriteLine("Id kiriting: ");
                        Console.Write(">> ");
                        if (!int.TryParse(Console.ReadLine(), out int id))
                        {
                            Console.Clear();
                            Console.WriteLine("To'g'ri formatda kiriting");
                            Run();
                        }

                        //Guid id = Guid.NewGuid();

                        Console.WriteLine("Ism kiriting: ");
                        Console.Write(">> ");
                        string name = Console.ReadLine()!;
                        Console.WriteLine("Address kiriting: ");
                        Console.Write(">> ");
                        string address = Console.ReadLine()!;
                        addFiles.CreateFile(id, name, address);
                        Console.Clear();
                        //Console.WriteLine("User qo'shildi");
                        Run();
                    }
                    break;
                case 2:
                    {
                        Console.Clear();
                        Console.WriteLine("<==== Delete User  ====>");
                        Console.WriteLine("1. Find by ID");
                        Console.WriteLine("2. Find by NAME");
                        Console.Write(">> ");
                        if (!int.TryParse(Console.ReadLine(), out int id))
                        {
                            Console.Clear();
                            Console.WriteLine("To'g'ri formatda kiriting");
                            Run();
                        }
                        switch (id)
                        {
                            case 1:
                                {
                                    Console.Clear();
                                    Console.WriteLine("Id ni kiriting");
                                    int deletedID;
                                    Console.Write(">> ");
                                    while (!int.TryParse(Console.ReadLine(), out deletedID))
                                    {
                                        Console.Clear();
                                        Console.WriteLine("To'g'ri formatda kiriting");
                                    }
                                    addFiles.DeleteUserById(deletedID);
                                    Console.Clear();
                                    Run();
                                }
                                break;
                            case 2:
                                {
                                    Console.Clear();
                                    Console.WriteLine("Name ni kiriting");
                                    Console.Write(">> ");
                                    string DeletedName = Console.ReadLine()!;
                                    addFiles.DeleteUserByName(DeletedName);
                                    Console.Clear();
                                    Run();
                                }
                                break;
                            default:
                                Console.Clear();
                                Run();
                                break;
                        }
                    }
                    break;
                case 3:
                    {
                        Console.Clear();
                        Console.WriteLine("<==== Update User  ====>");
                        Console.WriteLine("1. Find by ID");
                        Console.WriteLine("2. Find by NAME");
                        Console.Write(">> ");
                        if (!int.TryParse(Console.ReadLine(), out int id))
                        {
                            Console.Clear();
                            Console.WriteLine("To'g'ri formatda kiriting");
                            Run();
                        }
                        switch (id)
                        {
                            case 1:
                                {
                                    Console.Clear();
                                    Console.WriteLine("Id ni kiriting");
                                    int updateId;
                                    Console.Write(">> ");
                                    while (!int.TryParse(Console.ReadLine(), out updateId))
                                    {
                                        Console.Clear();
                                        Console.WriteLine("To'g'ri formatda kiriting");
                                    }
                                    addFiles.UpdateUserById(updateId);
                                    Console.Clear();
                                    Run();
                                }
                                break;
                            case 2:
                                {
                                    Console.Clear();
                                    Console.WriteLine("Name ni kiriting");
                                    Console.Write(">> ");
                                    string updateName = Console.ReadLine()!;
                                    addFiles.UpdateUserByName(updateName);
                                    Console.Clear();
                                    Run();
                                }
                                break;
                            default:
                                Console.Clear();
                                Run();
                                break;
                        }
                    }
                    break;
                case 4:
                    {
                        Console.Clear();
                        Console.WriteLine("<==== Show Users  ====>");
                        addFiles.ShowInfo();
                        Console.ReadKey();
                        Console.Clear();
                        Run();
                    }
                    break;
                case 0:
                    {
                        Console.Clear();
                        Console.WriteLine("\n<===== Thanks for Attention =====>");
                    }
                    break;
                default:
                    Console.Clear();
                    Run();
                    break;
            }
        }
    }
}
