using System;
using System.Collections.Generic;

namespace DDDPlanification.Models
{
    public class ConsultantRecruteur
    {
        public List<Competence> Competence { get; set; }

        public List<Disponibilite> disponibilites { get; set; }

        public bool uneCompetence(Competence competence)
        {
            if (Competence.Contains(competence))
            {
                return true;
            }
            return false;
        }
    }
}
