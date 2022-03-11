using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    /// <summary>
    /// interface pour le stockage
    /// </summary>
    public interface IStorage
    {
        /// <summary>
        /// permet de sauvegarder un notebook
        /// </summary>
        /// <param name="n">le notebook a sauvegarder</param>
        void Save(NoteBook n);
        /// <summary>
        /// permet de charger un notebook
        /// </summary>
        /// <returns>un notebook</returns>
        NoteBook Load();
    }
}
