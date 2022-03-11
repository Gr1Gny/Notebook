using System;
using Xunit;
using Storage;
using Logic;

namespace TestStorage
{
    public class TestJsonStorage
    {
        [Fact]
        public void TestJson()
        {
            NoteBook nb = new NoteBook();

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

            Exam exam1 = new Exam();
            exam1.Coef = 2;
            exam1.Score = 10;
            exam1.Module = module1;
            Exam exam2 = new Exam();
            exam2.Coef = 4;
            exam2.Score = 6;
            exam2.Module = module1;

            unit1.Add(module1);
            unit1.Add(module2);

            nb.AddUnit(unit1);
            nb.AddUnit(unit2);

            nb.AddExam(exam1);
            nb.AddExam(exam2);

            JsonStorage j = new JsonStorage("test.txt");
            j.Save(nb);
            NoteBook nb2 = j.Load();

            for(int i = 0; i < nb.ListUnits().Length; i++)
            {
                Assert.True(nb.ListUnits()[i].Equals(nb2.ListUnits()[i]));
            }

            for (int i = 0; i < nb.ListModules().Length; i++)
            {
                Assert.True(nb.ListModules()[i].Equals(nb2.ListModules()[i]));
            }
        }
    }
}
