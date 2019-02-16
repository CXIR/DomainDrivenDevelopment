using System;
namespace DDDPlanification.Uses_Cases
{
    public class ReplanifierEntretien
    {
        private Planification Planification;

        public ReplanifierEntretien()
        {
            Planification = new Planification();
        }

        public void Executer(Entretien entretien, DateTime date, int duree)
        {
            Planification.ReplanifierEntretien(entretien, date, duree);
        }
    }
}
