using System;
using System.Collections.Generic;
using System.Linq;

namespace DDDPlanification.Models
{
    public class ConsultantRecruteur : IEquatable<ConsultantRecruteur>
    {
        public string Nom    { get; set; }
        public string Prenom { get; set; }
        public Profil Profil { get; set; }
        public List<Creneau> Indisponibilites { get; set; }

        private List<Creneau> GetIndisponibilites(DateTime date)
        {
            // Retourne la liste des indispos sur 1 journée
            return Indisponibilites.Where(d => d.Debut == date).ToList();
        }

        public bool PeutTester(Candidat candidat)
        {
            return Profil.EstCompatible(candidat.Profil);// && !candidat.Cooptant.Equals(this);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as ConsultantRecruteur);
        }

        public bool Equals(ConsultantRecruteur other)
        {
            return other != null &&
                   Nom == other.Nom &&
                   Prenom == other.Prenom &&
                   EqualityComparer<Profil>.Default.Equals(Profil, other.Profil);
        }

        public bool EstDisponible(Creneau creneauSouhaite)
        {
            List<Creneau> creneaux = GetIndisponibilites(creneauSouhaite.GetJournee());
            foreach (Creneau c in creneaux)
            {
                bool result = creneauSouhaite.SeChevauche(c);
                if (result == false) return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Nom, Prenom, Profil);
        }

    }
}
