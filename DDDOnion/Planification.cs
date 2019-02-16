using System;
using System.Collections.Generic;
using DDDOnion.Vivier;
using DDDPlanification.BaseSalariale;
using DDDPlanification.Models;

namespace DDDPlanification
{
    public class Planification 
    {
        public Entretien Entretien { get; set; }
        IVivier Vivier { get; set; }
        public IBaseSalariale BaseSalariale { get; set; }

        public Entretien PlanifierEntretien(Candidat candidat, DateTime debut, int dureeMinutes)
        {
            List<ConsultantRecruteur> consultantRecruteurs = BaseSalariale.GetConsultantRecruteurs();

            if(debut.Hour > 7 && debut.AddMinutes(dureeMinutes).Hour < 19)
            {
                Creneau creneau = new Creneau(debut, dureeMinutes);

                foreach (ConsultantRecruteur cr in consultantRecruteurs)
                {
                    if (cr.PeutTester(candidat) && cr.EstDisponible(creneau))
                    {
                        return new Entretien(candidat, cr, creneau);
                    }
                }
            }
            return null; //throw new Exception();
        }

        public void ReplanifierEntretien(Entretien entretien, DateTime nouvelleDate, int dureeMinutes)
        {
            List<ConsultantRecruteur> consultantRecruteurs = BaseSalariale.GetConsultantRecruteurs();

            if (nouvelleDate.Hour > 7 && nouvelleDate.AddMinutes(dureeMinutes).Hour < 19)
            {
                Creneau creneau = new Creneau(nouvelleDate, dureeMinutes);

                foreach (ConsultantRecruteur cr in consultantRecruteurs)
                {
                    if (cr.PeutTester(Entretien.Candidat) && cr.EstDisponible(creneau))
                    {
                        Entretien.Replanifier(cr, creneau);
                    }
                }
            }

            throw new Exception();
        }

        public void AnnulerEntretien(Entretien entretien, string raison)
        {
            entretien.Annuler(raison);
            Vivier.archiverCandidat(entretien.Candidat);
        }
    }
}
