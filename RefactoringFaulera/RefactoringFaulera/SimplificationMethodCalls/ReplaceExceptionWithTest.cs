using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Замена исключиттелььной ситуации проверкой
// Иногда проверка исключительных ситуаций излишняя и ее можно заменить на обычный if
namespace ReplaceExceptionWithTest
{
    class ReplaceExceptionWithTest
    {
        Stack<Resource> _available;
        Stack<Resource> _allocated;
        Resource getResource()
        {
            Resource result;
            try
            {
                result = (Resource)_available.Pop();
                _allocated.Push(result);
                return result;
            }
            catch (Exception ex)
            {
                result = new Resource();
                _allocated.Push(result);
                return result;
            }

        }

    }
    public class Resource
    {

    }
}

namespace ReplaceExceptionWithTest2
{
    class ReplaceExceptionWithTest
    {
        Stack<Resource> _available;
        Stack<Resource> _allocated;
        Resource getResource()
        {
            Resource result;
            if (_available == null || _available.Count == 0)
            {
                result = new Resource();
            }
            else
            {
                result = (Resource)_available.Pop();
            }
            _allocated.Push(result); // это кусок кода - консолидация
            return result;  // дублирующихся условных фрагментов
        }

    }
    public class Resource
    {

    }
}
