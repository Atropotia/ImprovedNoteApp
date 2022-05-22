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
        public int iD { get; set; }

        /// <summary>
        /// Дата и время добавления сотрудника
        /// </summary>
        public DateTime currentTime { get; set; }

        /// <summary>
        /// Имя сотрудника
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Возраст сотрудника
        /// </summary>
        public int age { get; set; }

        /// <summary>
        /// Рост сотрудника
        /// </summary>
        public int height { get; set; }

        /// <summary>
        /// Дата рождения сотрудника
        /// </summary>
        public DateTime birthDate { get; set; }

        /// <summary>
        /// Место рождения сотрудника
        /// </summary>
        public string birthPlace { get; set; }
 
        public Worker(string input)
        {
            string[] arr = input.Split('#'); //Добавление # после каждого введённого параметра

            iD = int.Parse(arr[0]);
            currentTime = DateTime.Parse(arr[1]);
            name = arr[2];
            age = int.Parse(arr[3]);
            height = int.Parse(arr[4]);
            birthDate = DateTime.Parse(arr[5]);
            birthPlace = arr[6];

        }
    }

}
