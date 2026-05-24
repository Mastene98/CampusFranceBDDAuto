using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace CampusFranceBDDAuto
{
    internal class LectureFichierJson
    {
        public string filename;
        public string jsonString;
        public List<Utilisateurs> utilisateurs;

        public List<Utilisateurs> ReadEtudiantsJson()
        {
            filename = "Data/Data_Etudiants.json";

            using (StreamReader reader = new StreamReader(filename))
            {
                jsonString = reader.ReadToEnd();
                utilisateurs = JsonConvert.DeserializeObject<List<Utilisateurs>>(jsonString);
            }

            return utilisateurs;
        }

        public List<Utilisateurs> ReadChercheursJson()
        {
            filename = "Data/Data_Chercheurs.json";

            using (StreamReader reader = new StreamReader(filename))
            {
                jsonString = reader.ReadToEnd();
                utilisateurs = JsonConvert.DeserializeObject<List<Utilisateurs>>(jsonString);
            }

            return utilisateurs;
        }

        public List<Utilisateurs> ReadInstitutionnelsJson()
        {
            filename = "Data/Data_Institutionnel.json";

            using (StreamReader reader = new StreamReader(filename))
            {
                jsonString = reader.ReadToEnd();
                utilisateurs = JsonConvert.DeserializeObject<List<Utilisateurs>>(jsonString);
            }

            return utilisateurs;
        }
    }
}