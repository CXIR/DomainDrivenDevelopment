using System;
namespace DDDPlanification.Models
{
    // value object
    public class Creneau : IEquatable<Creneau>
    {
        public DateTime Debut { get; set; }
        public DateTime Fin   { get; set; }

        public Creneau(DateTime dateHeure, int dureeMinutes)
        {
            Debut = dateHeure;
            Fin = dateHeure.AddMinutes(dureeMinutes);
        }

        public DateTime GetJournee()
        {
            return Debut.Date;
        }

        public bool SeChevauche(Creneau creneau)
        {

            if ((this.Debut >= creneau.Debut && creneau.Debut >= this.Fin) || (this.Debut >= creneau.Fin && creneau.Fin >= this.Fin))
                return true;
            return false;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Creneau);
        }

        public bool Equals(Creneau other)
        {
            return other != null &&
                   Debut == other.Debut &&
                   Fin == other.Fin;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Debut, Fin);
        }
    }
}
