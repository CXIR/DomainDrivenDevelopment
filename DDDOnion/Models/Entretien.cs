using System;
using DDDPlanification.Models;

namespace DDDPlanification
{
    public class Entretien
    {


        public Candidat Candidat { get; set; }
        public ConsultantRecruteur  ConsultantRecruteur  { get; set; }
        public DateTime Date { get; set; }
    }
}