using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImprovedNoteApp
{
    internal class WorkWithFile
    {
        //Сохранение в файл данных
        public void SaveToFile(List<Worker> worker, string path)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                foreach (Worker employee in worker)
                {
                    sw.WriteLine($"{employee.ID}#" + " " +
                                 $"{employee.CurrentTime}#" + " " +
                                 $"{employee.Name}#" + " " +
                                 $"{employee.Age}#" + " " +
                                 $"{employee.Height}#" + " " +
                                 $"{employee.BirthDate}#" + " " +
                                 $"{employee.BirthPlace}");
                }
            }
        }
    }
}
