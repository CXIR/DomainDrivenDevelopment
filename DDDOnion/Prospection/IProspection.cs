using System;
using System.Collections.Generic;
using DDDPlanification;

namespace DDDOnion.Prospection
{
    public interface IProspection
    {
        Candidat GetCandidat(int identifiant);
    }
}
