using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// замениа конструктора фабричным методом
namespace ReplaceConstructorWithFactoryMethod
{
    class Employee
    {
        private int _type;
        public static int ENGINEER = 0;
        public static int SALESMAN = 1;
        public static int MANAGER = 2;

        public Employee (int type)
        {
            _type = type;
        }
    }
}

namespace ReplaceConstructorWithFactoryMethod2
{
    class Employee2
    {
        private int _type;
        public static int ENGINEER = 0;
        public static int SALESMAN = 1;
        public static int MANAGER = 2;
        // а, ну , и делаем конструктор закрытым если хотим создавать особенные экземпляры
        private Employee2(int type)
        {
            _type = type;
        }
        // если мы хотим создать подклассы Employee, сответствующие кодам типов
        // поэтому нужен фабричный метод
        public static Employee2 create(int type)
        {
            return new Employee2(type);
        }
    }
}

