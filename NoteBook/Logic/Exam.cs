using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    /// <summary>
    /// classe qui permet de gerer les examens
    /// </summary>
    [DataContract]
    public class Exam
    {
        //correspond au professeur qui fait l'examen
        [DataMember] private string teacher;
        //correspond a la date de l'examen
        [DataMember] private DateTime dateExam = DateTime.Now;
        //correspond au coefficient de l'examen
        [DataMember] private float coef = 1;
        //permet de savoir si l'eleve etait absent
        [DataMember] private Boolean isAbsent = true;
        //correspond au score de l'eleve
        [DataMember] private float score = 0;
        //correspond au module de l'examen
        [DataMember] private Module module;


        /// <summary>
        /// permet de modifier et de récupérer le professeur
        /// </summary>
        public string Teacher
        {
            get => teacher;
            set
            {
                teacher = value;
            }
        }

        /// <summary>
        /// permet de modifier et de récupérer la date de l'examen
        /// </summary>
        public DateTime DateExam
        {
            get => dateExam;
            set
            {
                dateExam = value;
            }
        }

        /// <summary>
        /// permet de modifier et de récupérer le coef
        /// </summary>
        public float Coef
        {
            get => coef;
            set
            {
                if (value <= 0) throw new Exception("The coef must be >0");
                coef = value;
            }
        }

        /// <summary>
        /// permet de savoir si l'eleve etait present
        /// </summary>
        public Boolean IsAbsent
        {
            get => isAbsent;
            set
            {
                isAbsent = value;
            }
        }

        /// <summary>
        /// permet de modifier et de récupérer le score
        /// </summary>
        public float Score
        {
            get => score;
            set
            {
                if (value < 0 || value > 20) throw new Exception("The coef must be >= 0 and <= 20");
                score = value;
            }
        }

        /// <summary>
        /// permet de modifier et de récupérer le score
        /// </summary>
        public Module Module
        {
            get => module;
            set
            {
                if (value == null) throw new Exception("module can't be null");
                module = value;
            }
        }

        /// <summary>
        /// permet de comparer deux Exam
        /// </summary>
        /// <param name="obj">l'objet avec lequel se comparer</param>
        /// <returns>true si ce sont les mêmes Exam</returns>
        public override bool Equals(object obj)
        {
            return obj is Exam exam &&
                   teacher == exam.teacher &&
                   DateTime.Compare(dateExam, exam.dateExam) == 0 &&
                   coef == exam.coef &&
                   isAbsent == exam.isAbsent &&
                   score == exam.score &&
                   module.Equals(exam.module);
        }
    }
}
