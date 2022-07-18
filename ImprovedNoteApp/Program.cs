using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImprovedNoteApp
{
    class Program
    {
        static string path = "Notebook.txt";
        static List<Worker> worker = new List<Worker>();

        static void Main(string[] args)
        {

            if (!File.Exists(path))
            {
                FileInfo fi1 = new FileInfo(path);
            }

            else
            {
                ReadData();
            }


            while (true)
                {
                    bool exit = false;
                Console.WriteLine($"Доброго времени суток.\n Нажмите 1 чтобы вывести данные на экран" +
                $"\n Нажмите 2 для добавления сотрудника" +
                $"\n Нажмите 3 для удаления определённых данных" +
                $"\n Нажмите 4 для редактирования данных" +
                $"\n Нажмите 5 для того чтобы показать сотрудников в диапазоне определённых дат" +
                $"\n Нажмите 6 для сортировки по убыванию" +
                $"\n Нажмите 7 для сортировки по возрастанию" +
                $"\n Нажмите 0 для выхода");
                int number = int.Parse(Console.ReadLine());
                    switch (number)
                    {
                        case 1:
                            PrintFile();
                            break;
                        case 2:
                            AddLine();
                            break;
                        case 3:
                            Delete();
                            break;
                        case 4:
                            Edit();
                            break;
                        case 5:
                            SortDate();
                            break;
                        case 6:
                            SortDateDown();
                            break;
                        case 7:
                            SortDateUp();
                            break;
                        case 0:
                            Exit();
                            exit = true;
                            return;
                        default:
                            break;

                    }
                }
        }

        //Чтение из файла данных
        private static void ReadData()
        {
            using (StreamReader sr = new StreamReader(path))
            {
                while (!sr.EndOfStream)
                {
                    worker.Add(new Worker(sr.ReadLine()));
                }

            }
        }

        //Добавление сотрудника
        private static void AddLine()
        {
            string line = $"{worker.Count}#{DateTime.Now}#";
            Console.Write("Введите фамилию, имя и отчество сотрудника: ");
            line += Console.ReadLine() + "#";
            Console.Write("Введите возраст сотрудника: ");
            line += Console.ReadLine() + "#";
            Console.Write("Введите рост сотрудника: ");
            line += Console.ReadLine() + "#";
            Console.Write("Введите дату рождения сотрудника: ");
            line += Console.ReadLine() + "#";
            Console.Write("Введите место рождения сотрудника: ");
            line += Console.ReadLine();
            worker.Add(new Worker(line));

            Console.WriteLine("Готово. Нажмите любую кнопку чтобы продолжить");
            Console.ReadKey();
            Console.Clear();
        }

        

        //Редактирование записи о сотруднике
        static private void Edit()
        {
            Console.Write("Введите ID сотрудника для редактирования записи: ");
            int ID;
            try
            {
                int cid = int.Parse(Console.ReadLine());
                Console.Write($"Редактируемые данные о работнике: {worker[cid].ID} ");
                ID = cid;
            }
            catch
            {
                Console.Write($"Введите верный ID");
                Console.ReadKey();
                Console.Clear();
                return;
            }

            string line = $"{worker.Count}#{DateTime.Now}#";
            Console.Write("Введите фамилию, имя и отчество сотрудника: ");
            line += Console.ReadLine() + "#";
            Console.Write("Введите возраст сотрудника: ");
            line += Console.ReadLine() + "#";
            Console.Write("Введите рост сотрудника: ");
            line += Console.ReadLine() + "#";
            Console.Write("Введите дату рождения сотрудника: ");
            line += Console.ReadLine() + "#";
            Console.Write("Введите место рождения сотрудника: ");
            line += Console.ReadLine();
            worker.Add(new Worker(line));

            Console.WriteLine("Готово. Нажмите любую кнопку чтобы продолжить");
            Console.ReadKey();
            Console.Clear();
        }

        //Просмотр записей в определённом промежутке дат
        static private void SortDate()
        {
            DateTime min, max;
            Console.Write("Введите начальную дату: ");
            min = DateTime.Parse(Console.ReadLine());

            Console.Write("Введите конечную дату: ");
            max = DateTime.Parse(Console.ReadLine());

            foreach (Worker employee in worker)
            {
                if (employee.CurrentTime >= min && employee.CurrentTime <= max)
                {
                    Console.WriteLine($"{employee.ID}" + " " +
                                 $"{employee.CurrentTime}" + " " +
                                 $"{employee.Name}#" + " " +
                                 $"{employee.Age}#" + " " +
                                 $"{employee.Height}#" + " " +
                                 $"{employee.BirthDate}#" + " " +
                                 $"{employee.BirthPlace}");
                }
            }

            Console.WriteLine("Готово. Нажмите любую кнопку чтобы продолжить");
            Console.ReadKey();
            Console.Clear();
        }


        //Вывод на экран записей из файла
        static private void PrintFile()
        {
            if (worker != null)
            {
                foreach (Worker employee in worker)
                {
                    Console.WriteLine($"{employee.ID}" + " " +
                                 $"{employee.CurrentTime}" + " " +
                                 $"{employee.Name}" + " " +
                                 $"{employee.Age}" + " " +
                                 $"{employee.Height}" + " " +
                                 $"{employee.BirthDate}" + " " +
                                 $"{employee.BirthPlace}");
                }
            }

            Console.WriteLine("Готово. Нажмите любую кнопку чтобы продолжить");
            Console.ReadKey();
            Console.Clear();
        }

        //Сортировка данных в пордке возрастания
        static private void SortDateUp()
        {
            DateTime[] counter = new DateTime[worker.Count];
            string[] list = new string[worker.Count];

            for (int i = 0; i < list.Length; i++)
            {
                counter[i] = worker[i].CurrentTime;
                list[i] =
                    worker[i].ID + " " +
                    worker[i].Name + " " +
                    worker[i].Age + " " +
                    worker[i].Height + " " +
                    worker[i].BirthDate + " " +
                    worker[i].BirthPlace + " ";
            }

            Array.Sort(counter, list);

            for (int i = 0; i < counter.Length; i++)
            {
                int found = list[i].IndexOf(" ");
                Console.WriteLine(list[i].Substring(0, found) + "   " + counter[i] + "  " + list[i].Substring(found + 1));
            }

            Console.WriteLine("Готово. Нажмите любую кнопку чтобы продолжить");
            Console.ReadKey();
            Console.Clear();
        }

        //Сотировка данных в порядке убывания
        static private void SortDateDown()
        {
            DateTime[] counter = new DateTime[worker.Count];
            string[] list = new string[worker.Count];

            for (int i = 0; i < list.Length; i++)
            {
                counter[i] = worker[i].CurrentTime;
                list[i] =
                    worker[i].ID + " " +
                    worker[i].Name + " " +
                    worker[i].Age + " " +
                    worker[i].Height + " " +
                    worker[i].BirthDate + " " +
                    worker[i].BirthPlace + " ";
            }

            Array.Sort(counter, list);

            for (int i = counter.Length - 1; i >= 0; i--)
            {
                int found = list[i].IndexOf(" ");
                Console.WriteLine(list[i].Substring(0, found) + "   " + counter[i] + "  " + list[i].Substring(found + 1));
            }

            Console.WriteLine("Готово. Нажмите любую кнопку чтобы продолжить");
            Console.ReadKey();
            Console.Clear();
        }

        //Выход из программы
        static private void Exit()
        {
            Console.WriteLine("Для сохранения и выхода нажмите ENTER, для выхода без созранения введите N и нажмите ENTER:");
            if (Console.ReadLine() == "N")
            {
                Console.WriteLine("Выход без сохранения");
            }
            else
            {
                SaveToFile();
                Console.WriteLine("Данные были сохранены");
            }
        }

        //Удаление сотрудника
        static private void Delete()
        {
            Console.WriteLine("Введите ID сотрудника для удаления");
            string id = Console.ReadLine().ToString();
            List<Worker> notesForDelete = worker.FindAll(note => note.ID.ToString() == id);
            if (notesForDelete.Count == 0)
            {
                Console.WriteLine($"Записи с номером {id} не найдено");
            }
            else
            {
                DeleteNotes(notesForDelete);
            }
        }

        //Метод для удаления записи
        static void DeleteNotes(List<Worker> notesForDelete)
        {
            foreach (Worker note in notesForDelete)
            {
                worker.Remove(note);
            }
        }
    }
}
