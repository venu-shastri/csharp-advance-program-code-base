using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PUnitTestFxLib;
namespace DarkThemeLib.Tests
{
    [TestSuiteAttribute]
    public class ThemeTypeTests
    {
        [TestAttribute]
        public void AssertGetThemeToBeTrue()
        {
            DarkThemeLib.ThemeType _objectUnderTest = new DarkThemeLib.ThemeType();
           string actualValue= _objectUnderTest.GetTheme();
            //Assert.Equals(actualVale,"Dark Theme");


           
        }
    }
}
