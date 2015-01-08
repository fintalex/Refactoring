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
        protected string _name;
    }
    public class Employee : Party
    {
        private int _annualCost;
        private string _id;
        public Employee(string name, string id, int annualCost)
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

    public class Department : Party
    {
        private List<Employee> _staff = new List<Employee>();

        public Department(string name)
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
