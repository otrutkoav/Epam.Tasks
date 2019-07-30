using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User
{
    public class User
    {
        public static DateTime minDateBirth = new DateTime(1920,1,1); 
        string name;
        string surname;
        string patronymic;
        DateTime dateBirth;
        int age;
        DateTime dateCreate;


        public User(string name, string surname, string patronymic, DateTime dateBirth) 
        {
            this.name = name;
            this.surname = surname;
            this.patronymic = patronymic;
            this.DateBirth = dateBirth;
            this.Age=CalculeteAge();
            dateCreate = DateTime.Now;
        }

        public DateTime DateBirth
        {
            get
            {
                return dateBirth;
            }
            private set
            {
                if (value<minDateBirth)
                {
                    throw new DateBirthException($"Год даты рождения не может быть меньше {minDateBirth.Year}");
                }
                dateBirth = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }
            private set
            {
                age = value;
            }
        }

        private int CalculeteAge()
        {
            DateTime today = DateTime.Now;
            int age = 0;

            if (dateBirth.Month < today.Month)
            {
                age = today.AddYears(-dateBirth.Year).Year;
            }
            else if (dateBirth.Month > today.Month)
            {
                age = today.AddYears(- dateBirth.Year-1).Year;
            }
            else 
            {
                if (today.Day>=DateBirth.Day)
                {
                    age = today.AddYears( - dateBirth.Year).Year;
                }
                else
                {
                    age = today.AddYears(- dateBirth.Year-1).Year;
                }
            }
            return age;
        }

        public void GetInfo()
        {
            Console.WriteLine($"Информация о человеке:\n"
                +$"{surname} {name} {patronymic}.\n"
                +$"Дата рождения: {dateBirth.ToLongDateString()}\n"
                +$"Возраст {age}.");
        }

        public override string ToString()
        {
            return $"Информация о человеке:\n"
                + $"{surname} {name} {patronymic}.\n"
                + $"Дата рождения: {dateBirth.ToLongDateString()}\n"
                + $"Возраст {age}.";
        }
    }
}
