using System;
using System.Collections.Generic;
using DDDPlanification.Models;

namespace DDDPlanification.MockService
{
    public class MockingFactory
    {
        public List<ConsultantRecruteur> ConsultantRecruteurs { get; set; }
        public List<Candidat> Candidats { get; set; }
        public Dictionary<string, Competence> Technologies{ get; set; }

        public MockingFactory()
        {
            ConsultantRecruteurs = new List<ConsultantRecruteur>();
            Candidats = new List<Candidat>();
            Technologies = new Dictionary<string, Competence>();

            GenererLesTechnologies();
            GenererLesConsultantsRecruteurs();
            GenererLesCandidats();
        }


        public void GenererLesTechnologies()
        {
            Technologies.Add("dotnet", new Competence()
            {
                Nom = ".NET"
            });
            Technologies.Add("java", new Competence()
            {
                Nom = "Java"
            });
            Technologies.Add("cpp", new Competence()
            {
                Nom = "C++"
            });
            Technologies.Add("csharp", new Competence()
            {
                Nom = "C#"
            });
            Technologies.Add("javascript", new Competence()
            {
                Nom = "JS"
            });
            Technologies.Add("php", new Competence()
            {
                Nom = "PHP"
            });
            Technologies.Add("ios", new Competence()
            {
                Nom = "iOS"
            });
            Technologies.Add("android", new Competence()
            {
                Nom = "Android by Google"
            });
            Technologies.Add("sm", new Competence()
            {
                Nom = "Agil - Scrum Master"
            });

            Technologies.Add("po", new Competence()
            {
                Nom = "Agile - Product Owner"
            });

            Technologies.Add("coach", new Competence()
            {
                Nom = "Agile - Coach"
            });

            Technologies.Add("devops", new Competence()
            {
                Nom = "Devops"
            });
        }

        public void GenererLesConsultantsRecruteurs()
        {
            //CONSULTANT 1
            ConsultantRecruteur consultantRecruteur1 = new ConsultantRecruteur()
            {
                Nom    = "ROKBANI",
                Prenom = "Wael",
                Profil = new Profil()
                {
                    Competences = new Dictionary<Competence, Niveau>()
                    {
                        { Technologies.GetValueOrDefault("dotnet"), Niveau.Intermediaire }
                    },
                    AnneesExperience = 5
                }
            };

            List<Creneau> indisponibilites1 = new List<Creneau>()
            {
                new Creneau(new DateTime(2019,02,20,14,00,00), 60),
                new Creneau(new DateTime(2019,02,20,17,00,00), 30),
                new Creneau(new DateTime(2019,02,21,10,00,00), 120),
                new Creneau(new DateTime(2019,02,22,13,00,00), 45)
            };
            consultantRecruteur1.Indisponibilites =  indisponibilites1;

            ConsultantRecruteurs.Add(consultantRecruteur1);

            //CONSULTANT 2
            ConsultantRecruteur consultantRecruteur2 = new ConsultantRecruteur()
            {
                Nom    = "WASH",
                Prenom = "Raphael",
                Profil = new Profil()
                {
                    Competences = new Dictionary<Competence, Niveau>()
                    {
                        { Technologies.GetValueOrDefault("ios"), Niveau.Expert }
                    },
                    AnneesExperience = 10
                }
            };

            List<Creneau> indisponibilites2 = new List<Creneau>();
            consultantRecruteur2.Indisponibilites = indisponibilites2;

            ConsultantRecruteurs.Add(consultantRecruteur2);

            //CONSULTANT 3
            ConsultantRecruteur consultantRecruteur3 = new ConsultantRecruteur()
            {
                Nom = "BANGOURA",
                Prenom = "Daouda",
                Profil = new Profil()
                {
                    Competences = new Dictionary<Competence, Niveau>()
                    {
                        { Technologies.GetValueOrDefault("android"), Niveau.Debutant }
                    },
                    AnneesExperience = 3
                }
            };

            List<Creneau> indisponibilites3 = new List<Creneau>()
            {
                new Creneau(new DateTime(2019,02,20,10,00,00), 60),
                new Creneau(new DateTime(2019,02,18,09,00,00), 30)
            };
            consultantRecruteur3.Indisponibilites = indisponibilites3;

            ConsultantRecruteurs.Add(consultantRecruteur3);

            //CONSULTANT 4
            ConsultantRecruteur consultantRecruteur4 = new ConsultantRecruteur()
            {
                Nom    = "LAMBY",
                Prenom = "Julien",
                Profil = new Profil()
                {
                    Competences = new Dictionary<Competence, Niveau>()
                    {
                        { Technologies.GetValueOrDefault("java"), Niveau.Intermediaire },
                        { Technologies.GetValueOrDefault("javascript"), Niveau.Intermediaire }
                    },
                    AnneesExperience = 6
                }
            };

            List<Creneau> indisponibilites4 = new List<Creneau>()
            {
                new Creneau(new DateTime(2019,02,18,07,00,00), 720),
                new Creneau(new DateTime(2019,02,20,07,00,00), 720),
                new Creneau(new DateTime(2019,02,22,07,00,00), 720)
            };
            consultantRecruteur4.Indisponibilites = indisponibilites4;

            ConsultantRecruteurs.Add(consultantRecruteur4);

            //CONSULTANT 5
            ConsultantRecruteur consultantRecruteur5 = new ConsultantRecruteur()
            {
                Nom    = "FELLAH",
                Prenom = "Yahia",
                Profil = new Profil()
                {
                    Competences = new Dictionary<Competence, Niveau>()
                    {
                        { Technologies.GetValueOrDefault("sm"), Niveau.Intermediaire }
                    },
                    AnneesExperience = 5
                }
            };

            List<Creneau> indisponibilites5 = new List<Creneau>()
            {
                new Creneau(new DateTime(2019,02,20,14,00,00), 120)
            };
            consultantRecruteur5.Indisponibilites = indisponibilites5;

            ConsultantRecruteurs.Add(consultantRecruteur5);
        }

        public void GenererLesCandidats()
        {
            //CANDIDAT 1
            Candidats.Add(new Candidat()
            {
                Nom    = "AIEFONESSO",
                Prenom = "Mickael",
                Profil = new Profil()
                {
                    Competences = new Dictionary<Competence, Niveau>()
                    {
                        { Technologies.GetValueOrDefault("dotnet"), Niveau.Debutant }
                    },
                    AnneesExperience = 4
                }
            });

            //CANDIDAT 2
            Candidats.Add(new Candidat()
            {
                Nom    = "ELMKIES DOUK",
                Prenom = "Eube",
                Profil = new Profil()
                {
                    Competences = new Dictionary<Competence, Niveau>()
                    {
                        { Technologies.GetValueOrDefault("php"), Niveau.Debutant }
                    },
                    AnneesExperience = 4
                }
            });

            //CANDIDAT 3
            Candidats.Add(new Candidat()
            {
                Nom    = "ROGER",
                Prenom = "Ludouigue",
                Profil = new Profil()
                {
                    Competences = new Dictionary<Competence, Niveau>()
                    {
                        { Technologies.GetValueOrDefault("javascript"), Niveau.Intermediaire }
                    },
                    AnneesExperience = 5
                }
            });
        }

    }
}
