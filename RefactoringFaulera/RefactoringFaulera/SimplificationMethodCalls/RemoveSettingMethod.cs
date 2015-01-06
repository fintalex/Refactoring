using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Удаление метода установки значения
namespace RemoveSettingMethod
{
    class Account
    {
        private String _id;
        Account (String id)
        {
            setId(id);
        }
        void setId(String arg)
        {
            _id = arg;
        }
    }
}

// Удаление метода установки значения
namespace RemoveSettingMethod2
{
    public class Account
    {
        private  String _id;
        protected Account()
        { }
        public Account(String id)
        {
            initializeId(id);
        }
        protected void initializeId(String arg)
        {
            _id = "ZZ" +  arg;
        }
        public String getId()
        {
            return _id;
        }
    }
    class InterestAccount : Account
    {
        public InterestAccount(String id, double rate)
        {
            initializeId(id);
            _interestRate = rate;
        }
        public double getIntRate()
        {
            return _interestRate;
        }
        private double _interestRate;
    }

}
