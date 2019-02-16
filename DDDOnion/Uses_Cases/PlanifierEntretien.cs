using System;
namespace DDDPlanification.Uses_Cases
{
    public class PlanifierEntretien
    {
        private Planification Planification;

        public PlanifierEntretien()
        {
            Planification = new Planification();
        }

        public void Executer(Candidat candidat, DateTime date, int duree)
        {
            Planification.PlanifierEntretien(candidat, date, duree);
        }
    }
}
