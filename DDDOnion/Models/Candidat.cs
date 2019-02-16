using System;
using System.Collections.Generic;
using DDDPlanification.Models;

namespace DDDPlanification
{
    // value object
    public class Candidat : IEquatable<Candidat>
    { 
        public string              Nom      { get; set; }
        public string              Prenom   { get; set; }
        public Profil              Profil   { get; set; }
        public ConsultantRecruteur Cooptant { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as Candidat);
        }

        public bool Equals(Candidat other)
        {
            return other != null &&
                Nom == other.Nom &&
                Prenom == other.Prenom &&
                EqualityComparer<Profil>.Default.Equals(Profil, other.Profil);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Nom, Prenom, Profil, Cooptant);
        }
    }
}