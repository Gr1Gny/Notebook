using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    /// <summary>
    /// classe qui permet de gérer une unit
    /// </summary>
    [DataContract]
    public class Unit : PedagogicalElement
    {
        //liste de modules dans une unité
        [DataMember] private List<Module> modules = new List<Module>();

        /// <summary>
        /// permet de récupérer les modules d'une unité
        /// </summary>
        /// <returns>un tableau de modules</returns>
        public Module[] ListModules()
        {
            return modules.ToArray();
        }

        /// <summary>
        /// permet d'ajouter un module à la liste des modules
        /// </summary>
        /// <param name="m">correspond au mmodule qu'on souhaite ajouter</param>
        public void Add(Module m)
        {
            foreach (Module v in modules)
            {
                if (v.Name == m.Name) throw new Exception("Name already exist");
            }
            modules.Add(m);
        }

        /// <summary>
        /// permet de retirer un module de la liste des modules
        /// </summary>
        /// <param name="m">correspond au module qu'on souhaite supprimer</param>
        public void Remove(Module m)
        {
            if (!modules.Contains(m)) throw new Exception("Unit not in NoteBook");
            modules.Remove(m);
        }

        /// <summary>
        /// permet de retourner la moyenne de tous les modules d'une unit
        /// </summary>
        /// <param name="examens">correspond à un tableau d'examens</param>
        /// <returns>un tableau contenant la moyenne des modules</returns>
        public AvgScore[] ComputeAverages(Exam[] examens)
        {
            List<AvgScore> moyennes = new List<AvgScore>();
            //pour tous les modules de l'unit
            foreach (Module module in modules)
            {
                AvgScore moyenne = module.ComputeAverage(examens);
                //la la moyenne de ce module est null (pas d'exams), alors on ne l'ajoute pas
                if (moyenne != null)
                {
                    moyennes.Add(moyenne);
                }
            }
            return moyennes.ToArray();
        }

    }
}
