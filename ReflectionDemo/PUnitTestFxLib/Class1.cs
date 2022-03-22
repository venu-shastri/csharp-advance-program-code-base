using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PUnitTestFxLib
{
    //Custom Attribute 
    [AttributeUsage(AttributeTargets.Class)]
    public class TestSuiteAttribute:System.Attribute
    {

    }

    [AttributeUsage(AttributeTargets.Method)]
    public class TestAttribute : System.Attribute
    {

    }

}
