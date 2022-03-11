using Logic;
using System;
using Xunit;

namespace TestLogic
{
    public class TestPedagogicalElement
    {
        [Fact]
        public void Testbase()
        {
            PedagogicalElement p = new PedagogicalElement();

            p.Name = "aaaa";
            Assert.Equal("aaaa", p.Name);

            p.Coef = 1;
            Assert.Equal(1, p.Coef);

            Assert.Throws<Exception>(() => { p.Coef = -1; });
            Assert.Throws<Exception>(() => { p.Name = ""; });
 
        }

        [Fact]
        public void TestToString()
        {
            PedagogicalElement p = new PedagogicalElement();
            p.Name = "test";
            p.Coef = 2;
            string test = "test (2)";

            Assert.Equal(test, p.ToString());
        }

        [Fact]
        public void testequals()
        {
            PedagogicalElement p1 = new PedagogicalElement();
            p1.Name = "test";
            p1.Coef = 2;
            PedagogicalElement p2 = new PedagogicalElement();
            p2.Name = "test";
            p2.Coef = 2;
            PedagogicalElement p3 = new PedagogicalElement();
            p3.Name = "test2";
            p3.Coef = 3;

            Assert.True(p1.Equals(p2));
            Assert.False(p1.Equals(p3));

        }
    }
}
