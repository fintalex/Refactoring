using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// выделение суперкласса
namespace ExtractSuperclass
{
    public class Employee
    {
        private string _name;
        private int _annualCost;
        private string _id;
        public Employee (string name, string id, int annualCost)
        {
            _name = name;
            _id = id;
            _annualCost = annualCost;
        }
        public int getAnnualCost()
        {
            return _annualCost;
        }
        public string getId()
        {
            return _id;
        }
        public string getName()
        {
            return _name;
        }

    }

    public class Department
    {
        private string _name;
        private List<Employee> _staff = new List<Employee>();

        public Department (string name)
        {
            _name = name;
        }
        public int getTotalAnnualCost()
        {
            int result = 0;

            return result;
        }
        public int getHeadCount()
        {
            return _staff.Count();
        }
        public List<Employee> getStaff()
        {
            return _staff;
        }
        public void addStaff(Employee arg)
        {
            _staff.Add(arg);
        }
        public string getName()
        {
            return _name;
        }
    }
}

namespace ExtractSuperclass2
{
    public abstract class Party
    {
        protected string _name;// Подъем поля
        public string getName() // подъем метода
        {
            return _name;
        }
        protected Party (string name) // подъем тела консттруктора
        {
            _name = name;
        }
        // так как этот метод имеет разную реализацию
        // но имеет одну сигнатуру , то переименовываем его
        // и создаем абстрактный метод в базовом классе
        abstract public int getAnnualCost(); 
    }
    public class Employee : Party
    {
        private int _annualCost;
        private string _id;
        public Employee(string name, string id, int annualCost)// немного подкорректировали старый конструктор
            : base (name)
        {
            _id = id;
            _annualCost = annualCost;
        }
        public override int getAnnualCost()
        {
            return _annualCost;
        }
        public string getId()
        {
            return _id;
        }
       
    }

    public class Department : Party
    {
        private List<Employee> _staff = new List<Employee>();

        public Department(string name) : base(name) {} // немного подкорректировали старый конструктор

        public override int getAnnualCost()
        {
            int result = 0;
            foreach (Employee each in getStaff())
            {
                result += each.getAnnualCost();
            }

            return result;
        }
        public int getHeadCount()
        {
            return _staff.Count();
        }
        public List<Employee> getStaff()
        {
            return _staff;
        }
        public void addStaff(Employee arg)
        {
            _staff.Add(arg);
        }
       
    }
}
