using System;
using System.Collections.Generic;
using System.Linq;
using DDDOnion.Prospection;
using DDDPlanification;
using DDDPlanification.BaseSalariale;
using DDDPlanification.MockService;
using DDDPlanification.Models;
using Moq;
using Xunit;

namespace DomainDrivenDevelopment
{
    public class UnitTest1
    {

        [Fact]
        public void normalProcess()
        {
            Planification planification = new Planification();
            MockingFactory mockFactory = new MockingFactory();
            IProspection prospection = Mock.Of<IProspection>();
            Mock.Get(prospection).Setup(p => p.GetCandidats()).Returns(mockFactory.Candidats);

            IBaseSalariale baseSalariale = Mock.Of<IBaseSalariale>();
            Mock.Get(baseSalariale).Setup(b => b.GetConsultantRecruteurs()).Returns(mockFactory.ConsultantRecruteurs);


           Candidat candidat = prospection.GetCandidats().FirstOrDefault();

            planification.BaseSalariale = baseSalariale;
            Entretien entretien = planification.PlanifierEntretien(candidat, new DateTime(2019, 02, 24, 08, 00, 00), 60);
            //Entretien entretien = planification.planifierEntretien(candidat, consultantRecruteur, DateTime.Now);
            Assert.Equal("Planifié", entretien.Statut);
        }



        //[Fact]
        //public void annuler()
        //{
        //    Planification planification = new Planification();
        //    Entretien
        //}
    }
}
