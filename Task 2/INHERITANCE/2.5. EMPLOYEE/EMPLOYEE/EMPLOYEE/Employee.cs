using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMPLOYEE
{
    public class Employee:User
    {
        string position;
        DateTime dateReceipt;
        int experienceYear;
        int experienceMounth;

        public Employee(string name, string surname, string patronymic, DateTime dateBirth,string position, DateTime dateReceipt)
            : base(name,surname,patronymic,dateBirth)
        {
            Position = position;
            DateReceipt = dateReceipt;
            CalculetExperience();
        }

        public string Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value ?? throw new NullReferenceException();
            }
        }

        public DateTime DateReceipt
        {
            get
            {
                return dateReceipt;
            }
            private set
            {
                if (value==null)
                {
                    throw new NullReferenceException();
                }

                if (value.Year<this.DateBirth.Year+18 || value.Year > this.DateBirth.Year + 100)
                {
                    throw new ArgumentOutOfRangeException();
                }

                if (value.Year == this.DateBirth.Year + 18)
                {
                    if (value.Month < this.DateBirth.Month)
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                    if (value.Month == this.DateBirth.Month)
                    {
                        if (value.Day < this.DateBirth.Day)
                        {
                            throw new ArgumentOutOfRangeException();
                        }
                    }
                }

                if (value>DateTime.Now)
                {
                    throw new ArgumentOutOfRangeException();
                }

                dateReceipt = value;
            }
        }

        public int ExperienceYear
        {
            get
            {
                return experienceYear;
            }
            private set
            {
                experienceYear = value;
            }
        }

        public int ExperienceMounth
        {
            get
            {
                return experienceMounth;
            }
            private set
            {
                experienceMounth = value;
            }
        }

        void CalculetExperience()
        {
            //DateTime today = new DateTime(2020, 5, 30);
            DateTime today = DateTime.Now;

            this.ExperienceMounth = today.Month - this.DateReceipt.Month;

            if (this.ExperienceMounth < 0)
            {
                this.ExperienceYear = today.Year - this.DateReceipt.Year - 1;
                this.ExperienceMounth = 12 + this.ExperienceMounth;
            }
            else
            {
                this.ExperienceYear = today.Year - this.DateReceipt.Year;
            }
        }

        string GetStringExperiance()
        {
            string result = "Стаж";

            if (this.ExperienceYear > 0)
            {
                if ((this.ExperienceYear % 100 >= 10) && (this.ExperienceYear % 100 <= 19))
                {
                    result += $" {this.ExperienceYear} лет";
                }
                else
                {
                    if (this.ExperienceYear % 10 == 1)
                    {
                        result += $" {this.ExperienceYear} год";
                    }
                    else if ((this.ExperienceYear % 10 >= 2) && (this.ExperienceYear % 10 <= 4))
                    {
                        result += $" {this.ExperienceYear} года";
                    }
                    else
                    {
                        result += $" {this.ExperienceYear} лет";
                    }
                }
            }

            if (this.ExperienceMounth != 0 && this.ExperienceMounth != 12)
            {
                if (this.ExperienceMounth == 1)
                {
                    result += $" {this.ExperienceMounth} месяц";
                }
                else if (this.ExperienceMounth >= 2 && this.ExperienceMounth <= 4)
                {
                    result += $" {this.ExperienceMounth} месяца";
                }
                else
                {
                    result += $" {this.ExperienceMounth} месяцев";
                }
            }
            return result;
        }

        public override string ToString()
        {
            string result = "Сотрудник:"+Environment.NewLine
                +$"Фамилия,Имя,Отчество: {this.Surname}, {this.Name}, {this.Patronymic}."+Environment.NewLine
                +$"Дата рождения: {this.DateBirth.ToString(("dd.MM.yyyy"))}. Возраст: {Age}."+Environment.NewLine
                +$"Должность: {this.Position}. {this.GetStringExperiance()}.";

            return result;
        }
    }
}
