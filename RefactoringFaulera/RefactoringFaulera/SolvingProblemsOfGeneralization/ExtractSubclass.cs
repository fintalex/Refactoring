using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Выделение подкласса
namespace ExtractSubclass
{
    class JobItem
    {
        private int _unitPrice;
        private int _quantity;
        private bool _isLabor;
        private Employee _employee;

        public JobItem (int unitPrice, int quantiity, bool isLabor, Employee employee)
        {
            _unitPrice = unitPrice;
            _quantity = quantiity;
            _isLabor = isLabor;
            _employee = employee;
        }
        public int getTotalPrice()
        {
            return getUnitPrice() * _quantity;
        }
        public int getUnitPrice()
        {
            return (_isLabor) ? _employee.getRate() : _unitPrice;
        }
        public int getQuantity()
        {
            return _quantity;
        }
        public Employee getEmployee()
        {
            return _employee;
        }
    }
    class Employee
    {
        private int _rate;
        public Employee (int rate)
        {
            _rate = rate;
        }
        public int getRate()
        {
            return _rate;
        }
    }
}

namespace ExtractSubclass2
{
    class JobItem
    {
        private int _unitPrice;
        private int _quantity;
        // теперь не нужно, так как эта инфа хранится в иерархии,
        // и данные можно получить через метод isLabor()
        //private bool _isLabor; 
        protected Employee _employee;

        // _employee инициализируется теперь только в подклассе
        public JobItem(int unitPrice, int quantiity)
        {
            _unitPrice = unitPrice;
            _quantity = quantiity;
        }
        //public JobItem(int unitPrice, int quantity): this
        //    (unitPrice, quantity)
        //{
            
        //}
        public int getTotalPrice()
        {
            return getUnitPrice() * _quantity;
        }
        // а здесь мы применили замену условного оператора полиморфизмом
        // если экземпляр класса будет JobItem - вернет false
        // если экземпляр класса будет LaborItem - вернет true
        public int getUnitPrice()
        {
            return _unitPrice;
        }
        public int getQuantity()
        {
            return _quantity;
        }

        // к полю _isLabor применим самоинкапсуляцию поля
        protected bool isLabor()
        {
            return false;
        }
        
    }
    class Employee
    {
        private int _rate;
        public Employee(int rate)
        {
            _rate = rate;
        }
        public int getRate()
        {
            return _rate;
        }
    }

    // собственно сам выделенный класс
    class LaborItem : JobItem
    {
        public LaborItem(int quantity, Employee employee)
            : base(0, quantity)
        {
            _employee = employee;
        }
        public Employee getEmployee()
        {
            return _employee;
        }
        // эти два метода замещают условные операторы которые были в родительском классе
        // такие же два метода есть в родительском классе, но вызывающие, так сказать 
        // друге ветки из бывшего условного оператора
        protected bool isLabor()
        {
            return true;
        }
        public int getUnitPrice()
        {
            return _employee.getRate();
        }
    }
}
