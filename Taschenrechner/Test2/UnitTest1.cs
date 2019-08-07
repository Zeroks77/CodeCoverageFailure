using System;
using Taschenrechner;
using Xunit;

namespace Test2
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            //Arrange
            var num = 1.2;
            var pow = 2.8;

            //Act
            var math = new MathCalc();
            var result = math.Power(num,pow);


            // Asserrt
            Assert.True(1.6661246469165398 == result);
        }
    }
}
