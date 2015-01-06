using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//using RemoveSettingMethod2;
using ReplaceConstructorWithFactoryMethod;
using ReplaceConstructorWithFactoryMethod2;

namespace RefactoringFaulera
{
	class Program
	{
		static void Main(string[] args)
		{
            // =================== test for RemoveSettingMethod ===========================
            //Account account = new Account("2323423");
            //string ex = account.getId();

            //InterestAccount interAccount = new InterestAccount("88888", 9999);
            //string intRateId = interAccount.getId();
            //double exdouble = interAccount.getIntRate();

            // =================== test for ReplaceConstructorWithFactoryMethod ===========================
            Employee eng = new Employee(0); // типа создали инженера
            Employee2 emp = Employee2.create("Engineer");
            Employee2 emp2 = Employee2.create("Salesman");
		}
	}
}
