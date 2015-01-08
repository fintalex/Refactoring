using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// выделение интерфейса
namespace ExtractInterface
{
    class ExtractInterface
    {
        double charge(Employee emp, int days)
        {
            int baser = emp.getRate() * days;
            if (emp.hasSpecialSkill())
            {
                return baser * 1.05;
            }
            else
                return baser;
        }
    }
    class Employee
    {
        public int getRate()
        {
            return 5;
        }
        public bool hasSpecialSkill()
        {
            return true;
        }
    }
}

namespace ExtractInterface2
{
    // объявляем интерфейс
    public interface Billable
    {
        int getRate();
        bool hasSpecialSkill();
    }
    class ExtractInterface
    {
        // а тут мы ослабляем зависимость с классом Employee
        // данный класс не знает о существовании класса Employee
        // а знает что есть интерфейс Billable и, то , что этот
        // интерфейс реализовывает методы getRate и hasSpecialSkill
        double charge(Billable emp, int days) 
        {
            int baser = emp.getRate() * days;
            if (emp.hasSpecialSkill())
            {
                return baser * 1.05;
            }
            else
                return baser;
        }
    }
    class Employee : Billable // объявляем как реализующий этот интерфейс
    {
        public int getRate()
        {
            return 5;
        }
        public bool hasSpecialSkill()
        {
            return true;
        }
    }
}