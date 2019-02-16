using System;
namespace DDDPlanification.Uses_Cases
{
    public class AnnulerEntretien
    {
        private Planification Planification;

        public AnnulerEntretien()
        {
            Planification = new Planification();
        }

        public void Executer(Entretien entretien, string raison)
        {
            Planification.AnnulerEntretien(entretien, raison);
        }

    }
}
