using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Logic;

namespace TestLogic
{
    public class TestExam
    {
        [Fact]
        public void testteacher()
        {
            Exam exam = new Exam();
            exam.Teacher = "sano";
            Assert.Equal("sano", exam.Teacher);
        }

        [Fact]
        public void testdateExam()
        {
            Exam exam = new Exam();
            exam.DateExam = new DateTime(2021,11,16);
            Assert.Equal(new DateTime(2021, 11, 16), exam.DateExam);
        }

        [Fact]
        public void testcoef()
        {
            Exam exam = new Exam();
            exam.Coef = 1.5f;
            Assert.Equal(1.5f, exam.Coef);
            Assert.Throws<Exception>(() => { exam.Coef = -2; });
        }

        [Fact]
        public void testisAbsent()
        {
            Exam exam = new Exam();
            Assert.True(exam.IsAbsent);
            exam.IsAbsent = false;
            Assert.False(exam.IsAbsent);
        }

        [Fact]
        public void testscore()
        {
            Exam exam = new Exam();
            exam.Score = 11.5f;
            Assert.Equal(11.5f, exam.Score);
            Assert.Throws<Exception>(() => { exam.Score = -5; });
            Assert.Throws<Exception>(() => { exam.Score = 21; });
        }

        [Fact]
        public void testmodule()
        {
            Exam exam = new Exam();
            Module m = new Module();
            m.Coef = 2;
            m.Name = "maths";
            exam.Module = m;
            Assert.Equal(m, exam.Module);
            Assert.Throws<Exception>(() => { exam.Module = null; });
        }

        [Fact]
        public void testequals()
        {
            Module m = new Module();
            Exam exam1 = new Exam();
            exam1.DateExam = new DateTime(2021, 11, 16);
            exam1.Coef = 3;
            exam1.IsAbsent = false;
            exam1.Module = m;
            exam1.Score = 16;
            exam1.Teacher = "Itachi";
            Exam exam2 = new Exam();
            exam2.DateExam = new DateTime(2021, 11, 16);
            exam2.Coef = 3;
            exam2.IsAbsent = false;
            exam2.Module = m;
            exam2.Score = 16;
            exam2.Teacher = "Itachi";
            Exam exam3 = new Exam();           
            exam3.DateExam = new DateTime(2008, 08, 08);
            exam3.Coef = 3;
            exam3.IsAbsent = false;
            exam3.Module = m;
            exam3.Score = 16;
            exam3.Teacher = "Itachi";
            Assert.True(exam1.Equals(exam2));
            Assert.False(exam1.Equals(exam3));
        }
    }
}
