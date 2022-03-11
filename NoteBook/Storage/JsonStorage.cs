using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Logic;

namespace Storage
{
    /// <summary>
    /// classe qui permet le stockage du notebook dans un fichier
    /// </summary>
    public class JsonStorage : IStorage
    {
        //fichier dans lequel on stock le fichier
        private string fileName;

        /// <summary>
        /// constructeur de la classe JsonStorage
        /// </summary>
        /// <param name="fileName">fichier dans lequel on sauvegarde et charge le notebook</param>
        public JsonStorage(string fileName)
        {
            this.fileName = fileName;
        }

        /// <summary>
        /// permet de charger le notebook
        /// </summary>
        /// <returns>le notebook chargé</returns>
        public NoteBook Load()
        {
            NoteBook noteBook;
            try
            {
                using (FileStream flux = new FileStream(this.fileName, FileMode.Open))
                {
                    DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(NoteBook));
                    noteBook = ser.ReadObject(flux) as NoteBook;
                }
            }
            catch
            {
                noteBook = new NoteBook();
            }

            return noteBook;
        }

        /// <summary>
        /// permet de sauvegarder un notebook
        /// </summary>
        /// <param name="n">correspond au notebook à sauvegarder</param>
        public void Save(NoteBook n)
        {
            using (FileStream flux = new FileStream(this.fileName, FileMode.Create))
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(NoteBook));
                ser.WriteObject(flux, n);
            }
        }
    }
}
