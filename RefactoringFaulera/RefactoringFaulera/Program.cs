using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//using RemoveSettingMethod2;
//using ReplaceConstructorWithFactoryMethod;
//using ReplaceConstructorWithFactoryMethod2;
//using ReplaceConstructorWithFactoryMethod3;
//using ExtractSubclass;
//using ExtractSubclass2;

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
            //Employee eng = new Employee(0); // типа создали инженера
            //Employee2 emp = Employee2.create("Engineer");
            //Employee2 emp2 = Employee2.create("Salesman");

            //Person kent = new Male(); // можно будет заменить на:
            //Person kent2 = Person.createMale();

            // =================== test for ExtractSubclass2 ===========================
            //Employee kent = new Employee(5);
            //// JobItem j1 = new JobItem(0, 5, true, kent); // необходимо для создания экземпляра в ExtractSubclass
            //JobItem j2 = new JobItem(10, 15);
            //JobItem j1 = new LaborItem(0, kent);
           
            
		}
	}
}

