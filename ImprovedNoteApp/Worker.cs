using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImprovedNoteApp
{
    /// <summary>
    /// Структура, описывающая данные работника
    /// </summary>

    public struct Worker
    {
        /// <summary>
        /// ID сотрудника
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Дата и время добавления сотрудника
        /// </summary>
        public DateTime CurrentTime { get; set; }

        /// <summary>
        /// Имя сотрудника
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Возраст сотрудника
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Рост сотрудника
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Дата рождения сотрудника
        /// </summary>
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// Место рождения сотрудника
        /// </summary>
        public string BirthPlace { get; set; }
 
        public Worker(string input)
        {
            string[] arr = input.Split('#'); //Добавление # после каждого введённого параметра

            ID = int.Parse(arr[0]);
            CurrentTime = DateTime.Parse(arr[1]);
            Name = arr[2];
            Age = int.Parse(arr[3]);
            Height = int.Parse(arr[4]);
            BirthDate = DateTime.Parse(arr[5]);
            BirthPlace = arr[6];

        }
    }

}
