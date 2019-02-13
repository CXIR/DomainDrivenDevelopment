using System;
using DDDOnion.Vivier;
using DDDPlanification.Models;

namespace DDDPlanification
{
    public class Planification 
    {

        IVivier vivier;

        private bool crDisponible(ConsultantRecruteur consultantRecruteur, DateTime date)
        {
            return consultantRecruteur.disponibilites.Exists(dispo => dispo.debut <= date && dispo.fin >= date);
        }

        private bool verificationPlanification(Candidat candidat, ConsultantRecruteur consultantRecruteur, DateTime date)
        {
            if (consultantRecruteur.uneCompetence(candidat.Competence))
            {
                if (crDisponible(consultantRecruteur, date))
                {
                    return true;
                }
            }
            return false;

        }

        public Entretien planifierEntretien(Candidat candidat, ConsultantRecruteur consultantRecruteur, DateTime date)
        {
            if(verificationPlanification(candidat, consultantRecruteur, date))
            {
                return new Entretien()
                {
                    Candidat = candidat,
                    ConsultantRecruteur = consultantRecruteur,
                    Date = date
                };
            }

            return null;
        }

        public Entretien replanifierEntretien(Entretien entretien, DateTime nouvelleDate)
        {
            if (verificationPlanification(entretien.Candidat, entretien.ConsultantRecruteur, nouvelleDate))
            {
                entretien.Date = nouvelleDate;
            }
            return entretien;
        }

        public bool  annulerEntretien(Entretien entretien)
        {
            return vivier.archiverCandidat(entretien.Candidat);
        }
    }
}
