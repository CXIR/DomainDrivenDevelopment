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
        public void NormalProcess()
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
            Assert.Equal("Planifié", entretien.Statut);
        }


        [Fact]
        public void ConsultantNonDisponible()
        {
            Planification planification = new Planification();
            MockingFactory mockFactory = new MockingFactory();
            IProspection prospection = Mock.Of<IProspection>();
            Mock.Get(prospection).Setup(p => p.GetCandidats()).Returns(mockFactory.Candidats);

            IBaseSalariale baseSalariale = Mock.Of<IBaseSalariale>();
            Mock.Get(baseSalariale).Setup(b => b.GetConsultantRecruteurs()).Returns(mockFactory.ConsultantRecruteurs);


            Candidat candidat = prospection.GetCandidats().FirstOrDefault();

            planification.BaseSalariale = baseSalariale;
            Entretien entretien = planification.PlanifierEntretien(candidat, new DateTime(2019, 02, 22, 13, 30, 00), 60);
            Assert.Null(entretien);
        }

        [Fact]
        public void ConsultantNonCompetent()
        {
            Planification planification = new Planification();
            MockingFactory mockFactory = new MockingFactory();
            IProspection prospection = Mock.Of<IProspection>();
            Mock.Get(prospection).Setup(p => p.GetCandidats()).Returns(mockFactory.Candidats);

            IBaseSalariale baseSalariale = Mock.Of<IBaseSalariale>();
            Mock.Get(baseSalariale).Setup(b => b.GetConsultantRecruteurs()).Returns(mockFactory.ConsultantRecruteurs);


            Candidat candidat = prospection.GetCandidats().First(c => c.Profil.Competences.Where(p => p.Key.Nom == "php").First());
            planification.BaseSalariale = baseSalariale;
            Entretien entretien = planification.PlanifierEntretien(candidat, new DateTime(2019, 02, 24, 08, 00, 00), 60);
            Assert.Null(entretien);
        }
        

        //[Fact]
        //public void Annuler()
        //{
        //    Planification planification = new Planification();
        //    Entretien
        //}
    }
}
