using System;
using System.Collections.Generic;
using DDDPlanification;
using DDDPlanification.Models;
using Xunit;

namespace DomainDrivenDevelopment
{
    public class UnitTest1
    {
        static Competence    competence    = new Competence() { Nom = ".NET" };
        static Disponibilite disponibilite = new Disponibilite() { debut = new DateTime(2018, 01, 01), fin = new DateTime(2019, 31, 12) };

        Candidat            candidat            = new Candidat() { Competence = competence };
        ConsultantRecruteur consultantRecruteur = new ConsultantRecruteur() { Competence = new List<Competence>() { competence }, disponibilites = new List<Disponibilite>() { disponibilite } };

        [Fact]
        public void normalProcess()
        {
            Planification planification = new Planification();
            Entretien entretien = planification.planifierEntretien(candidat, consultantRecruteur, DateTime.Now);
            Assert.Equal(candidat, entretien.Candidat);
        }

        [Fact]
        public void consultantNonDisponible()
        {
            Planification planification = new Planification();
            Assert.Equal(null, planification.planifierEntretien(candidat, consultantRecruteur, new DateTime(2017, 01, 01)));
        }

        [Fact]
        public void consultantNonCompetent()
        {
            Planification planification = new Planification();
            Competence comp = new Competence() { Nom = "Java" };
            consultantRecruteur.Competence = new List<Competence>() { new Competence(){ Nom = "Java" } };
            Assert.Equal(null, planification.planifierEntretien(candidat, consultantRecruteur, DateTime.Now));
        }

        [Fact]
        public void replanification()
        {
            Planification planification = new Planification();
            Entretien entretien = planification.planifierEntretien(candidat, consultantRecruteur, new DateTime(2019, 01, 01));
            Assert.Equal(DateTime.Now, planification.replanifierEntretien(entretien, DateTime.Now).Date);
        }

        //[Fact]
        //public void annuler()
        //{
        //    Planification planification = new Planification();
        //    Entretien
        //}
    }
}
