using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using Microsoft.Data.Sqlite;
using Users.Model;

namespace Users
{
    public class DbContext
    {
        private static string Connection()
        {
            return @"Data Source = C:\Users\fatih\Desktop\unit-testing\UnitTesting\Users\db.db";
        }

        ///<summary>
        ///<para>Returner alle bruger</para>
        ///</summary>
        public static List<User> GetStudents()
        {
            using (var cnn = new SqliteConnection(Connection()))
            {
                var ouput = cnn.Query<User>("SELECT * from klasse");
                return ouput.ToList();
            }
        }

        ///<summary>
        ///<para>Get en bruger</para>
        ///</summary>
        public static User GetStudent(string navn)
        {
            using (var cnn = new SqliteConnection(Connection()))
            {
                var ouput = cnn.Query<User>("SELECT * from klasse WHERE navn = @navn", new {navn = navn});
                return ouput.ToList()[0];
            }
        }

        ///<summary>
        ///<para>Indsæt bruger</para>
        ///</summary>
        public static List<User> SetStudent(string Navn, string Efternavn, int Alder)
        {
            using (var cnn = new SqliteConnection(Connection()))
            {
                var ouput = cnn.Query<User>("INSERT INTO klasse (Navn, Efternavn, Alder)VALUES(@Navn, @Efternavn, @Alder)", new {
                    Navn = Navn,
                    Efternavn = Efternavn,
                    Alder = (int?)Alder
                });
                return ouput.ToList();
            }
        }

        ///<summary>
        ///<para>Slet bruger</para>
        ///</summary>
        public static List<User> DeleteStudent(string Navn)
        {
            using (var cnn = new SqliteConnection(Connection()))
            {
                var ouput = cnn.Query<User>("DELETE FROM klasse WHERE Navn = @Navn;", new { Navn = Navn });
                return ouput.ToList();
            }
        }
    }
}
