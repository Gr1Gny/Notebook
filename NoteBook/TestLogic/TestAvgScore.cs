using Logic;
using System;
using Xunit;
using System.Collections.Generic;
using System.Text;

namespace TestLogic
{
    public class TestAvgScore
    {
        [Fact]
        public void TestBase()
        {
            PedagogicalElement p = new PedagogicalElement();
            p.Name = "test";
            AvgScore a = new AvgScore(2.5f, p);
            Assert.Equal(2.5f, a.Average);
            Assert.Equal(a.ElementName, p.Name);
            Assert.Equal("test", a.ElementName);
        }

        [Fact]
        public void TesttoString()
        {
            PedagogicalElement p = new PedagogicalElement();
            p.Name = "test";
            AvgScore a = new AvgScore(2.5f, p);
            string test = "L'element pedagogique test a pour moyenne 2,5";

            Assert.Equal(test, a.ToString());
        }
    }
}
