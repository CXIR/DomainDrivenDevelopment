using System;
using System.Collections.Generic;
using DDDPlanification.Models;

namespace DDDPlanification.BaseSalariale
{
    public interface IBaseSalariale
    {
        List<ConsultantRecruteur> getConsultantRecruteurs();
    }
}
