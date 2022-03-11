using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    /// <summary>
    /// classe qui permet la création d'un Notebook (carnet de notes)
    /// </summary>
    [DataContract]
    public class NoteBook
    {
        //une liste qui contient toutes les unités du Notebook
        [DataMember] private List<Unit> units = new List<Unit>();
        [DataMember] private List<Exam> exams = new List<Exam>();

        /// <summary>
        /// fonction qui permet de récupérer les unités du Notebook
        /// </summary>
        /// <returns>un tableau contenant les unités</returns>
        public Unit[] ListUnits()
        {
            return units.ToArray();
        }

        /// <summary>
        /// permet d'ajouter une unité au Notebook
        /// </summary>
        /// <param name="u">correspond à l'unité qu'on souhaite ajouter</param>
        public void AddUnit(Unit u)
        {
            foreach (Unit v in units)
            {
                //si une unité du même nom existe déjà, on lève une exception
                if(v.Name == u.Name) throw new Exception("Name already exist");
            }
            units.Add(u);
        }

        /// <summary>
        /// permet de supprimer une unité du Notebook
        /// </summary>
        /// <param name="u">correspond à l'unité qu'on souhaite supprimer</param>
        public void RemoveUnit(Unit u)
        {
            if(!units.Contains(u)) throw new Exception("Unit not in NoteBook");
            units.Remove(u);
        }

        /// <summary>
        /// permet de lister les modules
        /// </summary>
        /// <returns>un tableau de module</returns>
        public Module[] ListModules()
        {
            List<Module> modules = new List<Module>();
            foreach(Unit u in units)
            {
                foreach(Module m in u.ListModules())
                {
                    modules.Add(m);
                }
            }
            return modules.ToArray();
        }

        /// <summary>
        /// permet d'ajouter un examen
        /// </summary>
        /// <param name="exam">correspond a l'axamen qu'on souhaite ajouter</param>
        public void AddExam(Exam exam)
        {
            exams.Add(exam);
        }

        /// <summary>
        /// permet de retourner les examens du notebook
        /// </summary>
        /// <returns>un tableau contenant les examens</returns>
        public Exam[] ListExams()
        {
            return exams.ToArray();
        }
       
        /// <summary>
        /// permet de calculer la moyenne du notebook
        /// </summary>
        /// <returns>un tableau de moyennes contenant les moyennes des modules, units et notebook</returns>
        public AvgScore[] ComputeScores()
        {
            List<AvgScore> moyenneGlobale = new List<AvgScore>();
            float scoreTotal = 0;
            float coefTotal = 0;
            //on parcours les unit afin de recuperer la moyenne des modules
            foreach (Unit unit in units)
            {
                AvgScore[] moyenneModule = unit.ComputeAverages(this.exams.ToArray());
                float score = 0;
                float coef = 0;
                foreach (AvgScore a in moyenneModule)
                {
                    //permet de recuperer le coef du module 
                    foreach (Module m in unit.ListModules())
                    {
                        //en recuperant le module du meme nom dans l'unite
                        if(a.ElementName == m.Name)
                        {
                            score += a.Average * m.Coef;
                            coef += m.Coef;
                            moyenneGlobale.Add(a);
                        }
                    }     
                }
                //calcul de la moyenne de l'unit si coef > 0 car erreur si div par 0
                if(coef > 0)
                {
                    AvgScore moyenneUnit = new AvgScore(score / coef, unit);
                    moyenneGlobale.Add(moyenneUnit);
                    scoreTotal += score / coef * unit.Coef;
                    coefTotal += unit.Coef;
                } 
            }
            //calcul de la moyenne du notebook si coef > 0 car erreur si div par 0
            if (coefTotal > 0)
            {
                PedagogicalElement p = new PedagogicalElement();
                p.Name = "MoyenneGenerale";
                p.Coef = 1;
                AvgScore MoyenneGenerale = new AvgScore(scoreTotal / coefTotal, p);
                moyenneGlobale.Add(MoyenneGenerale);
            } 
            return moyenneGlobale.ToArray();
        }    
    }
}
