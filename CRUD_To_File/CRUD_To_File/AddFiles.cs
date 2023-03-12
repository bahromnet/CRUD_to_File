using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Xml.Linq;

namespace _3_Modul.Lesson_8_February_10_2023.LessonTasks
{
    internal class AddFiles
    {
        public List<Person> persons;

        public AddFiles()
        {
            persons = new List<Person>();
        }

        public void AddToListAllItems()
        {
            persons.Clear();
            string path = Directory.GetCurrentDirectory().ToString();
            DirectoryInfo? directoryInfo = new DirectoryInfo(path);
            directoryInfo = directoryInfo?.Parent?.Parent?.Parent;
            directoryInfo = new DirectoryInfo(directoryInfo?.FullName + @"\text.txt");
            string pathOfText = directoryInfo.FullName;
            using (StreamReader reader = File.OpenText(pathOfText))
            {
                string? line = reader.ReadLine();
                while (!string.IsNullOrEmpty(line))
                {
                    Person person = new Person();
                    person.Id = int.Parse(line.Substring("id: ".Length - 1));
                    line = reader.ReadLine();
                    person.Name = line.Substring("Name: ".Length);
                    line = reader.ReadLine();
                    person.Address = line.Substring("Address: ".Length);
                    line = reader.ReadLine();
                    line = reader.ReadLine();
                    persons.Add(person);
                }
            }
        }

        public void CreateFile(int id, string name, string address)
        {
            string path = Directory.GetCurrentDirectory().ToString();
            DirectoryInfo? directoryInfo = new DirectoryInfo(path);
            directoryInfo = directoryInfo?.Parent?.Parent?.Parent;
            directoryInfo = new DirectoryInfo(directoryInfo?.FullName + @"\text.txt");
            if (!File.Exists(directoryInfo.FullName))
            {
                File.Create(directoryInfo.FullName).Dispose();
            }
            string pathOfTextFile = directoryInfo.FullName;

            var pers = persons.FirstOrDefault(x => x.Id == id);
            if (pers == null)
            {
                persons.Add(new Person()
                {
                    Id = id,
                    Name = name,
                    Address = address
                });

                using (StreamWriter write = File.AppendText(pathOfTextFile))
                {
                    write.WriteLine($"id: {id}\nName: {name}\nAddress: {address}\n----------------------");
                }
                Console.WriteLine("----------------------\nUser qo'shildi");
                //Console.ReadKey();
                TimeSpan timeSpan = new TimeSpan(0, 0, 3);
                Thread.Sleep(timeSpan);
            }
            else
            {
                Console.WriteLine("----------------------\nBunday ID mavjud, Qaytadan urunib ko'ring");
                //Console.ReadKey();
                TimeSpan timeSpan = new TimeSpan(0, 0, 3);
                Thread.Sleep(timeSpan);
            }
        }

        public void ShowInfo()
        {
            /*
            //string path = Directory.GetCurrentDirectory().ToString();
            //DirectoryInfo? directoryInfo = new DirectoryInfo(path);
            //directoryInfo = directoryInfo?.Parent?.Parent?.Parent;
            //directoryInfo = new DirectoryInfo(directoryInfo?.FullName + @"\Lesson_8_February_10_2023\LessonTasks\text.txt");
            //string pathOfText = directoryInfo.FullName;
            ////string pathOfText = @"e:\ProGraM\DotNet\VisualStudio_Programms\Bahrom_Akramov\3-Modul\Lesson_8_February_10_2023\LessonTasks\text.txt";
            //using (StreamReader reader = new StreamReader(pathOfText))
            //{
            //    Console.Write(reader.ReadToEnd());
            //}
            */
            foreach (var item in persons)
            {
                Console.WriteLine($"id: {item.Id}\nName: {item.Name}\nAddress: {item.Address}\n----------------------");
            }
        }

        public void DeleteUserById(int deleteID)
        {
            string path = Directory.GetCurrentDirectory().ToString();
            DirectoryInfo? directoryInfo = new DirectoryInfo(path);
            directoryInfo = directoryInfo?.Parent?.Parent?.Parent;
            directoryInfo = new DirectoryInfo(directoryInfo?.FullName + @"\text.txt");
            string pathOfText = directoryInfo.FullName;

            var persID = persons.FirstOrDefault(x => x.Id == deleteID);
            if (persID != null)
            {
                persons.Remove(persID);
                using (StreamWriter write = new StreamWriter(pathOfText))
                {
                    int item = 0;
                    while (item < persons.Count())
                    {
                        var person = persons[item++];
                        write.WriteLine($"id: {person.Id}\nName: {person.Name}\nAddress: {person.Address}\n----------------------");
                    }
                }
                Console.WriteLine("----------------------\nUser o'chirildi");
                TimeSpan time = new TimeSpan(0, 0, 3);
                Thread.Sleep(time);
            }
            else
            {
                Console.WriteLine("----------------------\nBunday Id dagi User mavjud emas");
                TimeSpan time = new TimeSpan(0, 0, 3);
                Thread.Sleep(time);
            }
        }

        public void DeleteUserByName(string deleteName)
        {
            string path = Directory.GetCurrentDirectory().ToString();
            DirectoryInfo? directoryInfo = new DirectoryInfo(path);
            directoryInfo = directoryInfo?.Parent?.Parent?.Parent;
            directoryInfo = new DirectoryInfo(directoryInfo?.FullName + @"\text.txt");
            string pathOfText = directoryInfo.FullName;

            var persName = persons.FindAll(x => x.Name == deleteName);
            if (persName.Count != 0)
            {
                int i = 1;
                foreach (var item in persName)
                {
                    Console.WriteLine($"{i++}. id: {item.Id}\n   Name: {item.Name}\n   Address: {item.Address}\n----------------------");
                }
                if (persName.Count > 1)
                {
                    Console.WriteLine($"{i}. Hammasini o'chirish");
                }
                Console.Write(">> ");
                int chooseName;
                while (!int.TryParse(Console.ReadLine(), out chooseName))
                {
                    Console.Clear();
                    Console.WriteLine("To'g'ri formatda kiriting");
                }
                if (chooseName != i)    
                {
                    persons.Remove(persName[chooseName-1]);
                    using (StreamWriter write = new StreamWriter(pathOfText))
                    {
                        int item = 0;
                        while (item < persons.Count)
                        {
                            var person = persons[item++];
                            write.WriteLine($"id: {person.Id}\nName: {person.Name}\nAddress: {person.Address}\n----------------------");
                        }
                    }
                    Console.WriteLine("----------------------\nUser o'chirildi");
                    TimeSpan time = new TimeSpan(0, 0, 3);
                    Thread.Sleep(time);
                }
                else
                {
                    foreach (var item in persName)
                    {
                        persons.Remove(item);
                    }
                    using (StreamWriter write = new StreamWriter(pathOfText))
                    {
                        int item = 0;
                        while (item < persons.Count)
                        {
                            var person = persons[item++];
                            write.WriteLine($"id: {person.Id}\nName: {person.Name}\nAddress: {person.Address}\n----------------------");
                        }
                    }
                    Console.WriteLine("----------------------\nUserlar o'chirildi");
                    TimeSpan time = new TimeSpan(0, 0, 3);
                    Thread.Sleep(time);
                }
            }
            else
            {
                Console.WriteLine("----------------------\nBunday Name dagi User mavjud emas");
                TimeSpan time = new TimeSpan(0, 0, 3);
                Thread.Sleep(time);
            }
        }

        public void UpdateUserById(int updateID)
        {
            string path = Directory.GetCurrentDirectory().ToString();
            DirectoryInfo? directoryInfo = new DirectoryInfo(path);
            directoryInfo = directoryInfo?.Parent?.Parent?.Parent;
            directoryInfo = new DirectoryInfo(directoryInfo?.FullName + @"\text.txt");
            string pathOfText = directoryInfo.FullName;

            var updateByIDPers = persons.FirstOrDefault(x => x.Id == updateID);
            if (updateByIDPers != null)
            {
                Console.WriteLine("Yangi ID ni kiriting: ");
                Console.Write(">> ");
                string? newID = Console.ReadLine();
                Console.WriteLine("Yangi Name ni kiriting: ");
                Console.Write(">> ");
                string? newName = Console.ReadLine();
                Console.WriteLine("Yangi Address ni kiriting: ");
                Console.Write(">> ");
                string? newAddress = Console.ReadLine();
                if (newID != "")
                {
                    updateByIDPers.Id = int.Parse(newID!);
                }
                if (newName != "")
                {
                    updateByIDPers.Name = newName!;
                }
                if (newAddress != "")
                {
                    updateByIDPers.Address = newAddress!;
                }
                using (StreamWriter write = new StreamWriter(pathOfText))
                {
                    int item = 0;
                    while (item < persons.Count)
                    {
                        var person = persons[item++];
                        write.WriteLine($"id: {person.Id}\nName: {person.Name}\nAddress: {person.Address}\n----------------------");
                    }
                }
                Console.WriteLine("----------------------\nUser yangilandi");
                TimeSpan time = new TimeSpan(0, 0, 3);
                Thread.Sleep(time);
            }
            else
            {
                Console.WriteLine("----------------------\nBunday ID dagi User mavjud emas");
                TimeSpan time = new TimeSpan(0, 0, 3);
                Thread.Sleep(time);
            }
        }

        public void UpdateUserByName(string updateName)
        {
            string path = Directory.GetCurrentDirectory().ToString();
            DirectoryInfo? directoryInfo = new DirectoryInfo(path);
            directoryInfo = directoryInfo?.Parent?.Parent?.Parent;
            directoryInfo = new DirectoryInfo(directoryInfo?.FullName + @"\text.txt");
            string pathOfText = directoryInfo.FullName;

            var updateByNamePers = persons.FindAll(x => x.Name == updateName);
            if (updateByNamePers != null)
            {
                int i = 1;
                foreach (var item in updateByNamePers)
                {
                    Console.WriteLine($"{i++}. id: {item.Id}\n   Name: {item.Name}\n   Address: {item.Address}\n----------------------");
                }
                Console.Write(">> ");
                int chooseName;
                while (!int.TryParse(Console.ReadLine(), out chooseName))
                {
                    Console.Clear();
                    Console.WriteLine("To'g'ri formatda kiriting");
                }
                Console.WriteLine("Yangi ID ni kiriting: ");
                Console.Write(">> ");
                string? newID = Console.ReadLine();
                Console.WriteLine("Yangi Name ni kiriting: ");
                Console.Write(">> ");
                string? newName = Console.ReadLine();
                Console.WriteLine("Yangi Address ni kiriting: ");
                Console.Write(">> ");
                string? newAddress = Console.ReadLine();
                if (newID != "")
                {
                    updateByNamePers[chooseName-1].Id = int.Parse(newID!);
                }
                if (newName != "")
                {
                    updateByNamePers[chooseName-1].Name = newName!;
                }
                if (newAddress != "")
                {
                    updateByNamePers[chooseName-1].Address = newAddress!;
                }

                using (StreamWriter write = new StreamWriter(pathOfText))
                {
                    int item = 0;
                    while (item < persons.Count)
                    {
                        var person = persons[item++];
                        write.WriteLine($"id: {person.Id}\nName: {person.Name}\nAddress: {person.Address}\n----------------------");
                    }
                }
                Console.WriteLine("----------------------\nUser yangilandi");
                TimeSpan time = new TimeSpan(0, 0, 3);
                Thread.Sleep(time);
            }
            else
            {
                Console.WriteLine("----------------------\nBunday Name dagi User mavjud emas");
                TimeSpan time = new TimeSpan(0, 0, 3);
                Thread.Sleep(time);
            }
        }

    }
}
