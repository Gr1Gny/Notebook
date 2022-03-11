using Logic;
using System;
using Xunit;
using System.Collections.Generic;
using System.Text;

namespace TestLogic
{
    public class TestModule
    {
        [Fact]
        public void TestComputeAverage()
        {
            Module module1 = new Module();
            module1.Name = "module1";
            Module module2 = new Module();
            module2.Name = "module2";
            Exam exam1 = new Exam();
            exam1.Coef = 2;
            exam1.Score = 10;
            exam1.Module = module1;
            Exam exam2 = new Exam();
            exam2.Coef = 4;
            exam2.Score = 6;
            exam2.Module = module1;
            Exam exam3 = new Exam();
            exam3.Coef = 1;
            exam3.Score = 18;
            exam3.Module = module2;
            Exam exam4 = new Exam();
            exam4.Coef = 2;
            exam4.Score = 7;
            exam4.Module = module2;
            Exam[] examens = { exam1, exam2, exam3, exam4 };
            Exam[] examens2 = { };

            AvgScore moyenne = module1.ComputeAverage(examens);
            AvgScore moyenne2 = module2.ComputeAverage(examens);
            AvgScore moyenne3 = module1.ComputeAverage(examens2);

            Assert.Equal(((2f * 10f) + (4f * 6f)) / 6f, moyenne.Average, 2);
            Assert.Equal((18f + (2f * 7f)) / 3f, moyenne2.Average, 2);
            Assert.Null(moyenne3);
        }
    }
}
