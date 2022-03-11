using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;


namespace Logic
{
    [DataContract]
    /// <summary>
    /// classe qui permet la création d'un module
    /// </summary>
    public class Module : PedagogicalElement
    {
        /// <summary>
        /// permet de calculer la moyenne des examens d'un module
        /// </summary>
        /// <param name="examens">correspond a un tableau d'examens</param>
        /// <returns>un objet de type AvgScore contenant la moyenne du module</returns>
        public AvgScore ComputeAverage(Exam[] examens)
        {
            AvgScore moyenne = null;
            float score = 0;
            float coef = 0;
            //on parcourt tous les exams
            foreach (Exam exam in examens)
            {
                //si le module de l'examen est le meme que ce module
                if (exam.Module.Equals(this))
                {
                    //alors on incrémente le score et le coef
                    score += exam.Score * exam.Coef;
                    coef += exam.Coef;
                }
            }
            if(coef > 0)
            {
                moyenne = new AvgScore(score / coef, this);
            }     
            return moyenne;
        }
    }
}
