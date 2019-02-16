using System;
using DDDPlanification.Models;
using System.Collections.Generic;

namespace DDDPlanification.MockService
{
    public interface IMockFactory
    {
        List<ConsultantRecruteur> GetConsultantRecruteurs();
    }
}
