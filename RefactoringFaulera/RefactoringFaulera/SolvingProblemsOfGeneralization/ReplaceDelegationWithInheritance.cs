﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReplaceDelegationWithInheritance
{
    class Employee
    {
        Person _person = new Person();
        public string getName()
        {
            return _person.getName();
        }
        public void setName(string arg)
        {
            _person.setName(arg);
        }
        public String toString()
        {
            return "Emp: " + _person.getLastName();
        }
    }
    class Person
    {
        String _name;

        public String getName()
        {
            return _name;
        }
        public void setName(String arg)
        {
            _name = arg;
        }
        public String getLastName()
        {
            return _name.Substring(_name.LastIndexOf(' ') + 1);
        }
    }
}
