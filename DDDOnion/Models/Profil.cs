using System;
using System.Collections.Generic;

namespace DDDPlanification.Models
{
    public enum Niveau
    {
        Debutant      = 1,
        Intermediaire = 2,
        Expert        = 3
    }

    // value object
    public class Profil : IEquatable<Profil>
    {

        public Dictionary<Competence, Niveau> Competences { get; set; }
        public int                            AnneesExperience { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as Profil);
        }

        public bool Equals(Profil other)
        {
            return other != null &&
                   EqualityComparer<Dictionary<Competence, Niveau>>.Default.Equals(Competences, other.Competences) &&
                   AnneesExperience == other.AnneesExperience;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Competences, AnneesExperience);
        }
        
        public bool EstCompatible(Profil autreProfil)
        {
            if (Competences.Keys.SequenceEqual(autreProfil.Competences.Keys)) {
                return true;
            }
            return false;
        }
    }
}
