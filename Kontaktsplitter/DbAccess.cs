using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SQLite;
using System.Linq;
using Kontaktsplitter.Model;

namespace Kontaktsplitter
{
    public sealed class DbAccess : DbContext
    {
        public DbSet<Kunde> Kunden { get; set; }
        public DbSet<Anrede> Anreden { get; set; }
        public DbSet<Titel> Titel { get; set; }

        public DbAccess() : base(GetConnection(), false)
        {

        }

        public static DbConnection GetConnection()
        {
            var connection = ConfigurationManager.ConnectionStrings["SqlLiteDb"];
            var factory = DbProviderFactories.GetFactory(connection.ProviderName);
            var dbCon = factory.CreateConnection();
            dbCon.ConnectionString = connection.ConnectionString;
            return dbCon;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.Add(new KundeMap());
            base.OnModelCreating(modelBuilder);
        }

        private static string dataSource = "SqlLiteDemo.db";

        public void CreateTables()
        {


            using (SQLiteConnection connection = new SQLiteConnection())
            {
                connection.ConnectionString = "Data Source=" + dataSource;
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(connection);

                // Erstellen der Tabelle, sofern diese noch nicht existiert.
                //command.CommandText = "CREATE TABLE IF NOT EXISTS Kunde ( id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, Anrede VARCHAR(100), " +
                //                      "Briefanrede VARCHAR(100), Titel VARCHAR(100), Geschlecht VARCHAR(100), Vorname VARCHAR(100), Nachname VARCHAR(100));";
                //command.ExecuteNonQuery();

                //command.CommandText = "CREATE TABLE IF NOT EXISTS Anrede ( id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, Geschlecht VARCHAR(100), " +
                //                      "Anrede VARCHAR(100), Briefanrede VARCHAR(100), Sprache VARCHAR(100));";

                //command.ExecuteNonQuery();



                connection.Close();
                connection.Dispose();
            }
        }

        public static void SaveCustomer(Kunde customer)
        {
            using (var context = new DbAccess())
            {
                ////Add the new Customer to the context
               
                var maxId = context.Kunden.Max(kunde => kunde.Id);
                customer.Id = maxId + 1;
                context.Kunden.Add(customer);

                //And save it to the db
                context.SaveChanges();
            }
        }


        public static List<Kunde> GetKunden()
        {
            using (var context = new DbAccess())
            {
                return context.Kunden.ToList();
            }
        }

        public static List<Anrede> GetAnreden()
        {
            using (var context = new DbAccess())
            {
                return context.Anreden.ToList();
            }
        }


        public static List<Titel> GetTitels()
        {
            using (var context = new DbAccess())
            {
                return context.Titel.ToList();
            }
        }


        public static void SaveTitel(Titel titel)
        {
            using (var context = new DbAccess())
            {
                ////Add the new Titel to the context

                var maxId = context.Titel.Max(tit => tit.Id);
                titel.Id = maxId + 1;
                context.Titel.Add(titel);

                //And save it to the db
                context.SaveChanges();
            }
        }

        public static void ReloadTableContent()
        {
            using (var context = new DbAccess())
            {
                context.Titel.RemoveRange(context.Titel.ToList());
                context.Anreden.RemoveRange(context.Anreden.ToList());

                context.SaveChanges();
                
            }

            using (var context = new DbAccess())
            {
                // Vorhandene Titel Befüllen
                var titelList = new List<Titel>()
                {
                    new Titel()
                    {
                        Id = 0,
                        Kuerzel = "Dr",
                        Bezeichnung = "Doktor"
                    },
                    new Titel()
                    {
                        Id = 1,
                        Kuerzel = "Prof",
                        Bezeichnung = "Proffessor"
                    },
                    new Titel()
                    {
                        Id = 2,
                        Kuerzel = "Ing",
                        Bezeichnung = "Ingenieur"
                    },
                    new Titel()
                    {
                        Id = 3,
                        Kuerzel = "B",
                        Bezeichnung = "Bachelor"
                    },
                    new Titel()
                    {
                        Id = 4,
                        Kuerzel = "M",
                        Bezeichnung = "Bachelor"
                    },
                    new Titel()
                    {
                        Id = 5,
                        Kuerzel = "Dipl",
                        Bezeichnung = "Diplom"
                    },
                    new Titel()
                    {
                        Id = 6,
                        Kuerzel = "rer",
                        Bezeichnung = "Rerum"
                    },
                    new Titel()
                    {
                        Id = 7,
                        Kuerzel = "mult",
                        Bezeichnung = "Multiple"
                    },
                    new Titel()
                    {
                        Id = 8,
                        Kuerzel = "nat",
                        Bezeichnung = "Naturwissenschaftler"
                    },

                };

                foreach (var titel in titelList)
                {
                    context.Titel.Add(titel);
                }
                //And save it to the db
                context.SaveChanges();
            }

            using (var context = new DbAccess())
            {

                // TODO Denis

                // Vorhandene Anreden Befüllen
                var anredeList = new List<Anrede>()
                {
                    new Anrede()
                    {
                        Geschlecht = "weiblich",
                        AnredeNormal = "Frau",
                        AnredeBrief = "Sehr geehrte Frau"
                    },
                    new Anrede()
                    {
                        Geschlecht = "weiblich",
                        AnredeNormal = "Frau Dr.",
                        AnredeBrief = "Sehr geehrte Frau Dr."
                    },
                    new Anrede()
                    {
                        Geschlecht = "weiblich",
                        AnredeNormal = "Frau Prof.",
                        AnredeBrief = "Sehr geehrte Frau Prof."
                    },
                    new Anrede()
                    {
                        Geschlecht = "weiblich",
                        AnredeNormal = "Mrs",
                        AnredeBrief = "Dear Mrs"
                    },
                    new Anrede()
                    {
                        Geschlecht = "weiblich",
                        AnredeNormal = "Ms",
                        AnredeBrief = "Dear Ms"
                    },
                    new Anrede()
                    {
                        Geschlecht = "weiblich",
                        AnredeNormal = "Signora",
                        AnredeBrief = "Gentile Signora"
                    },
                    new Anrede()
                    {
                        Geschlecht = "weiblich",
                        AnredeNormal = "Mme",
                        AnredeBrief = "Madame"
                    },
                    new Anrede()
                    {
                        Geschlecht = "weiblich",
                        AnredeNormal = "Señora",
                        AnredeBrief = "Estimada Señora"
                    },
                    new Anrede()
                    {
                        Geschlecht = "männlich",
                        AnredeNormal = "Herrn",
                        AnredeBrief = "Sehr geehrter Herr"
                    },
                    new Anrede()
                    {
                        Geschlecht = "männlich",
                        AnredeNormal = "Herrn Dr.",
                        AnredeBrief = "Sehr geehrter Herr Dr."
                    },
                    new Anrede()
                    {
                        Geschlecht = "männlich",
                        AnredeNormal = "Herrn Prof.",
                        AnredeBrief = "Sehr geehrter Herr Prof."
                    },
                    new Anrede()
                    {
                        Geschlecht = "männlich",
                        AnredeNormal = "Mr",
                        AnredeBrief = "Dear Mr"
                    },
                    new Anrede()
                    {
                        Geschlecht = "männlich",
                        AnredeNormal = "Sig.",
                        AnredeBrief = "Egregio Signor"
                    },
                    new Anrede()
                    {
                        Geschlecht = "männlich",
                        AnredeNormal = "M",
                        AnredeBrief = "Monsieur"
                    },
                    new Anrede()
                    {
                        Geschlecht = "männlich",
                        AnredeNormal = "Señor",
                        AnredeBrief = "Estimado Señor"
                    },
                    new Anrede()
                    {
                        Geschlecht = "ohne",
                        AnredeNormal = "Sehr geehrte Damen und Herren",
                        AnredeBrief = "Sehr geehrte Damen und Herren"
                    },
                    new Anrede()
                    {
                        Geschlecht = "ohne",
                        AnredeNormal = "Dear Sirs",
                        AnredeBrief = "Dear Sirs"
                    },
                    new Anrede()
                    {
                        Geschlecht = "ohne",
                        AnredeNormal = "Egregi Signori",
                        AnredeBrief = "Egregi Signori"
                    },
                    new Anrede()
                    {
                        Geschlecht = "ohne",
                        AnredeNormal = "Messieursdames",
                        AnredeBrief = "Messieursdames"
                    },
                    new Anrede()
                    {
                        Geschlecht = "ohne",
                        AnredeNormal = "Estimados Señores y Señoras",
                        AnredeBrief = "Estimados Señores y Señoras"
                    },
                };
                foreach (var anrede in anredeList)
                {
                    context.Anreden.Add(anrede);
                }
                //And save it to the db
                context.SaveChanges();
            }



        }
    }
}

