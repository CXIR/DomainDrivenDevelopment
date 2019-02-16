using System;

namespace DDDPlanification
{
    public class Competence : IEquatable<Competence>
    {
        public string Nom { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as Competence);
        }

        public bool Equals(Competence other)
        {
            return other != null &&
                   Nom == other.Nom;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Nom);
        }
    }
}