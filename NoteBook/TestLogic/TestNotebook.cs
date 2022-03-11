using Logic;
using System;
using Xunit;

namespace TestLogic
{
    public class TestNotebook
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
            NoteBook n = new NoteBook();       

            Unit u = new Unit();
            u.Name = "maths";
            u.Coef = 2.0f;

            Unit u2 = new Unit();
            u2.Name = "maths";
            u2.Coef = 2.0f;

            n.AddUnit(u);
            Unit[] tab = n.ListUnits();

            Assert.Single(tab);
            Assert.Equal("maths", tab[0].Name);
            Assert.Equal(2, tab[0].Coef);

            Assert.Throws<Exception>(() => { n.AddUnit(u2); });
        }

        [Fact]
        public void TestRemove()
        {
            NoteBook n = new NoteBook();

            Unit u = new Unit();
            u.Name = "maths";
            u.Coef = 2.0f;

            n.AddUnit(u);
            n.RemoveUnit(u);

            Unit[] tab = n.ListUnits();
            Assert.NotNull(tab);
            Assert.Empty(tab);

            Assert.Throws<Exception>(() => { n.RemoveUnit(u); });
        }

        [Fact]
        public void TestListModules()
        {
            NoteBook n = new NoteBook();

            Unit u = new Unit();
            u.Name = "maths";
            u.Coef = 2.0f;

            Unit u2 = new Unit();
            u2.Name = "langues";
            u2.Coef = 1.5f;

            n.AddUnit(u);
            n.AddUnit(u2);

            Module m = new Module();
            m.Coef = 2;
            m.Name = "proba";
            u.Add(m);

            Module m2 = new Module();
            m2.Coef = 2;
            m2.Name = "francais";
            u.Add(m2);

            Module[] tab = n.ListModules();

            Assert.Equal(2, tab.Length);
            Assert.Equal("proba", tab[0].Name);
            Assert.Equal(2, tab[0].Coef);
        }

        [Fact]
        public void TestAddListExams()
        {
            NoteBook n = new NoteBook();
            Exam e = new Exam();
            e.Coef = 2.5f;
            e.Score = 18.5f;

            n.AddExam(e);

            Exam[] exams = n.ListExams();

            Assert.Single(exams);
            Assert.Equal(2.5f, exams[0].Coef);
            Assert.Equal(18.5f, exams[0].Score);
        }

        [Fact]
        public void TestComputeScores()
        {
            NoteBook nb = new NoteBook();

            AvgScore[] moyenne = nb.ComputeScores();
            Assert.Empty(moyenne);

            Unit unit1 = new Unit();
            unit1.Name = "unit1";
            unit1.Coef = 2;
            Unit unit2 = new Unit();
            unit2.Name = "unit2";
            unit2.Coef = 2;

            Module module1 = new Module();
            module1.Name = "module1";
            module1.Coef = 1;
            Module module2 = new Module();
            module2.Name = "module2";
            module2.Coef = 2;
            Module module3 = new Module();
            module3.Name = "module3";
            module3.Coef = 3;

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
            exam4.Score = 15;
            exam4.Module = module3;

            unit1.Add(module1);
            unit1.Add(module2);
            unit2.Add(module3);

            nb.AddUnit(unit1);
            nb.AddUnit(unit2);

            nb.AddExam(exam1);
            nb.AddExam(exam2);
            nb.AddExam(exam3);
            nb.AddExam(exam4);

            AvgScore[] moyennes = nb.ComputeScores();

            //6 car 1 nb, 2 units et 3 modules
            Assert.Equal(6, moyennes.Length);

            //module 1
            Assert.Equal(((2f * 10f) + (4f * 6f)) / 6f, moyennes[0].Average);
            //module 2
            Assert.Equal(18, moyennes[1].Average);
            //unit 1
            Assert.Equal((moyennes[0].Average * module1.Coef + moyennes[1].Average * module2.Coef) / (module1.Coef + module2.Coef), moyennes[2].Average);
            //module 3
            Assert.Equal(15, moyennes[3].Average);
            //unit 2
            Assert.Equal(15, moyennes[4].Average);
            //notebook
            Assert.Equal((moyennes[2].Average * unit1.Coef + moyennes[4].Average * unit2.Coef) / (unit1.Coef + unit2.Coef), moyennes[5].Average);
        }
    }
}
