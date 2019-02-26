using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace MVVMExample
{
    public class InitCollections
    {
        static string[] Roles = {"Программист 3 кат.", "Программист 2 кат.", "Программист 1 кат.", "Программист 0 кат." };

        public static ObservableCollection<IEmployee> Go()
        {
            Random ran = new Random();
            ObservableCollection<IEmployee> Employees = new ObservableCollection<IEmployee>();
            for(int i = 0; i < 10; i++)
            {
                Employees.Add(Employee.Create(i + 18, 2000 + (i * 5000), "Работник" + i.ToString(), "Отдела", Roles[ran.Next(0, Roles.Length)]));
            }
            return Employees;
        }

        public static IEmployee CreateRandomEmployee()
        {
            Random ran = new Random();
            return Employee.Create(ran.Next(), ran.Next(), "Имя" + ran.Next().ToString(), "Фамилия" + ran.Next().ToString(), ran.Next().ToString());
        }
    }
}
