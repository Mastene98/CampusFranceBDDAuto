using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampusFranceBDDAuto
{
    internal class Utilisateurs
    {
        // informations 
        public string email { get; set; }
        public string motDePasse { get; set; }
        public string confirmationMotDePasse { get; set; }
        public string civilite { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public string paysResidence { get; set; }
        public string paysNationalite { get; set; }
        public string codePostal { get; set; }
        public string ville { get; set; }
        public string telephone { get; set; }

        // type de profil
        public string profil { get; set; }

        // etudiant / chercheur
        public string domaineEtudes { get; set; }
        public string niveauEtudes { get; set; }

        // institutionnel
        public string fonction { get; set; }
        public string typeOrganisme { get; set; }
        public string nomOrganisme { get; set; }
    }
}
