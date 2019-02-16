using System;
using System.Collections.Generic;
using DDDPlanification.Models;

namespace DDDPlanification
{
    // entity 

    public class Entretien : IEquatable<Entretien>
    {

        private Guid ID;
        public string Statut { get; set; }
        public Candidat Candidat { get; set; }
        public ConsultantRecruteur ConsultantRecruteur { get; set; }
        public Creneau Creneau { get; set; }

        public Entretien(Candidat candidat, ConsultantRecruteur consultantRecruteur, Creneau creneau)
        {
            ID = Guid.NewGuid();
            Statut = "Planifié";
            Candidat = candidat;
            ConsultantRecruteur = consultantRecruteur;
            Creneau = creneau;
        }

        public void Replanifier(ConsultantRecruteur consultantRecruteur, Creneau nouveauCreneau)
        {
            Statut = "Replanifié";
            ConsultantRecruteur = consultantRecruteur;
            Creneau = nouveauCreneau;
        }

        public void Annuler(string raison)
        {
            Statut = "Annulé - " + raison;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Entretien);
        }

        public bool Equals(Entretien other)
        {
            return other != null &&
                   ID.Equals(other.ID) &&
                   Statut == other.Statut &&
                   EqualityComparer<Candidat>.Default.Equals(Candidat, other.Candidat) &&
                   EqualityComparer<ConsultantRecruteur>.Default.Equals(ConsultantRecruteur, other.ConsultantRecruteur) &&
                   EqualityComparer<Creneau>.Default.Equals(Creneau, other.Creneau);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ID, Statut, Candidat, ConsultantRecruteur, Creneau);
        }
    }
}