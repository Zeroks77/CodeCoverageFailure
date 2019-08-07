﻿using Taschenrechner;
using Xunit;

namespace GrundRechnerTest
{
    public  class TestInforechner
    {
        [Fact]
        public void TestBinToOther()
        {
            string Bin, Octal, Dec, Hexa;
            Bin = "110010";
            Octal = "62";
            Dec = "50";
            Hexa = "32";
           var result = new Informatikrechner().MyConverter(Bin, string.Empty, string.Empty, string.Empty);
           Assert.True(Bin == result[0]);
           Assert.True(Octal == result[1]);
           Assert.True(Dec == result[2]);
           Assert.True(Hexa == result[3]);
        }
    }
}
