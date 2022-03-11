using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    /// <summary>
    /// classe qui correspond à un élément pédagogique tel qu'un module ou une unité
    /// </summary>
    [DataContract]
    public class PedagogicalElement
    {

        //correspond au coefficient de lélément pédagogique
        [DataMember] private float coef;

        //correspond au nom de lélément pédagogique
        [DataMember] private String name;

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

        // <summary>
        /// permet de modifier et de récupérer le nom
        /// </summary>
        public String Name
        {
            get => name;
            set
            {
                if (value == string.Empty) throw new Exception("Name can't be empty");
                name = value;
            }
        }

        /// <summary>
        /// permet de comparer deux elements pedagogiques
        /// </summary>
        /// <param name="obj">l'objet avec lequel se comparer</param>
        /// <returns>true si ce sont les mêmes Exam</returns>
        public override bool Equals(object obj)
        {
            return obj is PedagogicalElement element &&
                   coef == element.coef &&
                   name == element.name;
        }

        /// <summary>
        /// permet de récupérer le nom et le coef sous forme de caractère
        /// </summary>
        /// <returns>une chaine de caractère</returns>
        public override string ToString()
        {
            return this.name + " (" + this.coef + ")";
        }



    }
}
