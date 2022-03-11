using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    /// <summary>
    /// classe qui permet de gerer la moyenne
    /// </summary>
    [DataContract]
    public class AvgScore
    {
        [DataMember] private float average;
        [DataMember] private string elementname;
        [DataMember] private PedagogicalElement element;
        /// <summary>
        /// permet de modifier et de récupérer le coef
        /// </summary>
        public float Average
        {
            get => average;
            set
            {
                average = value;
            }
        }

        /// <summary>
        /// permet de modifier et de récupérer le coef
        /// </summary>
        public string ElementName
        {
            get => elementname;
            set
            {
                elementname = value;
                element.Name = value;
            }
        }

        /// <summary>
        /// constructeur de la classe AvgScore
        /// </summary>
        /// <param name="average">correspond a la moyenne</param>
        /// <param name="ee">correspond à l'élément pédagogique</param>
        public AvgScore(float average, PedagogicalElement ee)
        {
            this.average = average;
            this.element = ee;
            this.elementname = ee.Name; 
        }

        /// <summary>
        /// retourne les informations de la classe sous forme de chaine de caractères
        /// </summary>
        /// <returns>retourne un chaine de caractères</returns>
        public override string ToString()
        {
            return "L'element pedagogique " + elementname.ToString() + " a pour moyenne " + average.ToString();
        }
    }
}
