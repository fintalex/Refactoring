using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// подъем метода
namespace PullUpConstructorBody
{
    class Employee
    {
        protected String _name;
        protected String _id;

    }
    class Manager : Employee
    {
        public Manager (String name, String id, int grade)
        {
            _name = name;
            _id = id;
            _grade = grade;
        }
        private int _grade;
    }
}

namespace PullUpConstructorBody2
{
    class Employee
    {
        protected String _name;
        protected String _id;
        protected Employee()
        {
        }
        protected Employee(String name, String id)
        {
            _name = name;
            _id = id;
        }
        protected bool isPrivileged() { return true; }
        protected void assignCar() { }
    }
    class Manager : Employee
    {
        public Manager(String name, String id, int grade):base(name, id)
        {
            _grade = grade;
            if (isPrivileged()) assignCar();
        }
        private int _grade;
        bool isPrivileged() 
        {
            return _grade > 4;
        }
    }
}
