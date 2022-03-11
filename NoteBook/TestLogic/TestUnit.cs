using Logic;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TestLogic
{
    public class TestUnit
    {
        [Fact]
        public void TestBase()
        {
            NoteBook n = new NoteBook();

            Unit[] tab = n.ListUnits();

            Assert.NotNull(tab);
            Assert.Empty(tab);
        }

        [Fact]
        public void TestAdd()
        {
            Unit u = new Unit();
            u.Name = "maths";
            u.Coef = 2.0f;

            Module m = new Module();
            m.Name = "addition";
            m.Coef = 1;

            Module m2 = new Module();
            m2.Name = "addition";
            m2.Coef = 1;

            u.Add(m);
            Module[] tab = u.ListModules();

            Assert.Single(tab);
            Assert.Equal("addition", tab[0].Name);
            Assert.Equal(1, tab[0].Coef);

            Assert.Throws<Exception>(() => { u.Add(m2); });
        }

        [Fact]
        public void TestRemove()
        {
            Unit u = new Unit();
            u.Name = "maths";
            u.Coef = 2.0f;

            Module m = new Module();
            m.Name = "addition";
            m.Coef = 1;

            u.Add(m);
            u.Remove(m);

            Module[] tab = u.ListModules();
            Assert.NotNull(tab);
            Assert.Empty(tab);

            Assert.Throws<Exception>(() => { u.Remove(m); });
        }

        [Fact]
        public void TestComputeAverages()
        {
            Unit unit1 = new Unit();
            unit1.Name = "unit1";
            Unit unit2 = new Unit();
            unit2.Name = "unit2";
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
            unit1.Add(module1);
            unit1.Add(module2);

            AvgScore[] moyennes = unit1.ComputeAverages(examens);
            AvgScore[] moyennes2 = unit2.ComputeAverages(examens);

            Assert.Empty(moyennes2);
            Assert.Equal(2, moyennes.Length);
            Assert.Equal(((2f * 10f) + (4f * 6f)) / 6f, moyennes[0].Average, 2);
            Assert.Equal((18f + (2f * 7f)) / 3f, moyennes[1].Average, 2);        
        }
    }
}
