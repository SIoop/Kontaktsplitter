using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using Kontaktsplitter.Model;

namespace Kontaktsplitter
{
    /// <summary>
    /// Die DbAccess beinhaltet die Instanz der Verbindung zu Datenbank
    /// </summary>
    public sealed class DbAccess : DbContext
    {
        public DbSet<Kunde> Kunden { get; set; }
        public DbSet<Anrede> Anreden { get; set; }
        public DbSet<Titel> Titel { get; set; }

        public DbAccess() : base(GetConnection(), false)
        {

        }

        /// <summary>
        /// Die statische Datenbankverbindung
        /// </summary>
        /// <returns></returns>
        public static DbConnection GetConnection()
        {
            var connection = ConfigurationManager.ConnectionStrings["SqlLiteDb"];
            var factory = DbProviderFactories.GetFactory(connection.ProviderName);
            var dbCon = factory.CreateConnection();
            if (dbCon != null)
            {
                dbCon.ConnectionString = connection.ConnectionString;
                return dbCon;
            }
            throw new Exception("Die verbindung zur Datenbank konnte nicht hergestellt werden. Bitte überprüfen Sie, ob die Datei vorhanden ist.");
        }

        /// <summary>
        /// Wird aufgerufen beim erstellen der DB Modelle
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.Add(new KundeMap());
            modelBuilder.Configurations.Add(new TitelMap());
            modelBuilder.Configurations.Add(new AnredeMap());
            base.OnModelCreating(modelBuilder);
        }

        /// <summary>
        /// Der Name der Datenbank
        /// </summary>
        public static string DataSource { get; } = "SqlLiteDemo.db";

        /// <summary>
        /// Speichert den Kunden in der Datenbankdatei
        /// </summary>
        /// <param name="customer"></param>
        public static void SaveCustomer(Kunde customer)
        {
            using (var context = new DbAccess())
            {
                // Neuen Kunden hinzufügen
                // Da keine DB-Managementsystem vorhanden ist muss die ID selbst vergeben werden.
                var id = 0;
                if (context.Kunden.ToList().Count != 0)
                {
                    id = context.Kunden.Max(kunde => kunde.Id) + 1;
                }
                customer.Id = id;
                context.Kunden.Add(customer);

                // In DB speichern
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Gibt alle Kunden aus der Datenbankdatei zurück
        /// </summary>
        /// <returns>Die Liste der Kunden</returns>
        public static List<Kunde> GetCustomer()
        {
            using (var context = new DbAccess())
            {
                return context.Kunden.ToList();
            }
        }

        /// <summary>
        /// Gibt alle Anreden aus der Datenbankdatei zurück
        /// </summary>
        /// <returns>Die Anreden der Kunden</returns>
        public static List<Anrede> GetSalutation()
        {
            using (var context = new DbAccess())
            {
                return context.Anreden.ToList();
            }
        }

        /// <summary>
        /// Gibt alle Titel aus der Datenbankdatei zurück
        /// </summary>
        /// <returns>Die Titel der Kunden</returns>
        public static List<Titel> GetTitels()
        {
            using (var context = new DbAccess())
            {
                return context.Titel.ToList();
            }
        }

        /// <summary>
        /// Speichert den Titel in der Datenbankdatei
        /// </summary>
        public static void SaveTitel(Titel titel)
        {
            using (var context = new DbAccess())
            {
                // Da keine DB-Managementsystem vorhanden ist muss die ID selbst vergeben werden.
                var maxId = context.Titel.Max(tit => tit.Id);
                titel.Id = maxId + 1;
                context.Titel.Add(titel);

                context.SaveChanges();
            }
        }

        /// <summary>
        /// Läd die Titel und Anreden der Datenbank neu
        /// Hierbei werden alle bisherigen einträge überschrieben
        /// Hinweis: Dies Methode wird nur initial oder bei Fehlern benötig und nicht im laufenden Betrieb verwendet.
        /// </summary>
        public static void ReloadTableContent()
        {
            // Tabelleninhalt löschen
            using (var context = new DbAccess())
            {
                context.Titel.RemoveRange(context.Titel.ToList());
                context.Anreden.RemoveRange(context.Anreden.ToList());

                context.SaveChanges();

            }

            // Titel befüllen
            using (var context = new DbAccess())
            {
                // Vorhandene Titel Befüllen
                var titelList = new List<Titel>()
                {
                    new Titel()
                    {
                        Id = 0,
                        Kuerzel = "Dr.",
                        Bezeichnung = "Doktor"
                    },
                    new Titel()
                    {
                        Id = 1,
                        Kuerzel = "Prof.",
                        Bezeichnung = "Professor"
                    },
                    new Titel()
                    {
                        Id = 2,
                        Kuerzel = "Ing.",
                        Bezeichnung = "Ingenieur"
                    },
                    new Titel()
                    {
                        Id = 3,
                        Kuerzel = "Dipl.",
                        Bezeichnung = "Diplom"

                    },
                    new Titel()
                    {
                        Id = 4,
                        Kuerzel = "M.",
                        Bezeichnung = "Bachelor"
                    },
                    new Titel()
                    {
                        Id = 5,
                        Kuerzel = "B.",
                        Bezeichnung = "Bachelor"
                    },
                    new Titel()
                    {
                        Id = 6,
                        Kuerzel = "rer.",
                        Bezeichnung = "Rerum"
                    },
                    new Titel()
                    {
                        Id = 7,
                        Kuerzel = "mult.",
                        Bezeichnung = "Multiple"
                    },
                    new Titel()
                    {
                        Id = 8,
                        Kuerzel = "nat.",
                        Bezeichnung = "Naturwissenschaftler"
                    },

                };

                foreach (var titel in titelList)
                {
                    context.Titel.Add(titel);
                }
                // In DB speichern
                context.SaveChanges();
            }

            // Anreden befüllen
            using (var context = new DbAccess())
            {
                // Vorhandene Anreden Befüllen
                var anredeList = new List<Anrede>()
                {
                    new Anrede()
                    {
                        Id = 0,
                        Geschlecht = Geschlecht.Weiblich.ToString(),
                        AnredeNormal = "Frau",
                        AnredeBrief = "Sehr geehrte Frau"
                    },
                    new Anrede()
                    {
                        Id = 1,
                        Geschlecht = Geschlecht.Weiblich.ToString(),
                        AnredeNormal = "Mrs.",
                        AnredeBrief = "Dear Mrs."
                    },
                    new Anrede()
                    {
                        Id = 2,
                        Geschlecht = Geschlecht.Weiblich.ToString(),
                        AnredeNormal = "Ms.",
                        AnredeBrief = "Dear Ms."
                    },
                    new Anrede()
                    {
                        Id = 3,
                        Geschlecht =Geschlecht.Weiblich.ToString(),
                        AnredeNormal = "Signora",
                        AnredeBrief = "Gentile Signora"
                    },
                    new Anrede()
                    {
                        Id = 4,
                        Geschlecht = Geschlecht.Weiblich.ToString(),
                        AnredeNormal = "Mme.",
                        AnredeBrief = "Madame"
                    },
                    new Anrede()
                    {
                        Id = 5,
                        Geschlecht = Geschlecht.Weiblich.ToString(),
                        AnredeNormal = "Señora",
                        AnredeBrief = "Estimada Señora"
                    },
                    new Anrede()
                    {
                        Id = 6,
                        Geschlecht = Geschlecht.Männlich.ToString(),
                        AnredeNormal = "Herrn",
                        AnredeBrief = "Sehr geehrter Herr"
                    },
                    new Anrede()
                    {
                        Id = 7,
                        Geschlecht = Geschlecht.Männlich.ToString(),
                        AnredeNormal = "Herr",
                        AnredeBrief = "Sehr geehrter Herr"
                    },
                   new Anrede()
                    {
                        Id = 8,
                        Geschlecht = Geschlecht.Männlich.ToString(),
                        AnredeNormal = "Mr.",
                        AnredeBrief = "Dear Mr."
                    },
                    new Anrede()
                    {
                        Id = 9,
                        Geschlecht = Geschlecht.Männlich.ToString(),
                        AnredeNormal = "Sig.",
                        AnredeBrief = "Egregio Signor"
                    },
                    new Anrede()
                    {
                        Id = 10,
                        Geschlecht = Geschlecht.Männlich.ToString(),
                        AnredeNormal = "M",
                        AnredeBrief = "Monsieur"
                    },
                    new Anrede()
                    {
                        Id = 11,
                        Geschlecht = Geschlecht.Männlich.ToString(),
                        AnredeNormal = "Señor",
                        AnredeBrief = "Estimado Señor"
                    },
                    new Anrede()
                    {
                        Id = 12,
                        Geschlecht = Geschlecht.Ohne.ToString(),
                        AnredeNormal = "Sehr geehrte Damen und Herren",
                        AnredeBrief = "Sehr geehrte Damen und Herren"
                    },
                    new Anrede()
                    {
                        Id = 13,
                        Geschlecht = Geschlecht.Ohne.ToString(),
                        AnredeNormal = "Dear Sirs",
                        AnredeBrief = "Dear Sirs"
                    },
                    new Anrede()
                    {
                        Id = 14,
                        Geschlecht = Geschlecht.Ohne.ToString(),
                        AnredeNormal = "Egregi Signori",
                        AnredeBrief = "Egregi Signori"
                    },
                    new Anrede()
                    {
                        Id = 15,
                        Geschlecht = Geschlecht.Ohne.ToString(),
                        AnredeNormal = "Messieursdames",
                        AnredeBrief = "Messieursdames"
                    },
                    new Anrede()
                    {
                        Id = 16,
                        Geschlecht = Geschlecht.Ohne.ToString(),
                        AnredeNormal = "Estimados Señores y Señoras",
                        AnredeBrief = "Estimados Señores y Señoras"
                    },
                    new Anrede()
                    {
                        Id = 17,
                        Geschlecht = Geschlecht.Divers.ToString(),
                        AnredeNormal = "Guten Tag",
                        AnredeBrief = "Guten Tag"
                    }
                };
                foreach (var anrede in anredeList)
                {
                    context.Anreden.Add(anrede);
                }
                // In DB speichern
                context.SaveChanges();
            }



        }
    }
}

