using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalExamProject_Sem3.Entity;
namespace FinalExamProject_Sem3.Config
{
    public class CRUD_Command
    {
        private static SQLiteConnection sQLiteConnection = new SQLiteConnection("ContactDB.db");
        public static bool CreateTables()
        {
            var conn = new SQLiteConnection("ContactDB.db");
            string sql = @"CREATE TABLE IF NOT EXISTS    
                           Contact (Id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
                            Name    VARCHAR( 140 ),
                              PhoneNumber VARCHAR(150));";
            using (var statement = conn.Prepare(sql))
            {
                statement.Step();
            }
            return true;
        }

        public bool CreateRecord(string name,string phone, string errName, string errPhone)
        {
            var conn = new SQLiteConnection("ContactDB.db");
            try
            {
                var stmt = "INSERT INTO Contact(Name, PhoneNumber)" +
                    "VALUES (?,?)";
                using (var spmt = conn.Prepare(stmt))
                {
                    if(name.ToString() == "")
                    {
                        errName = "*Name is required !";
                        return false;
                    }
                    else
                    {
                        errName = "";
                        spmt.Bind(1, name.ToString());
                    }

                    if(phone.ToString() == "")
                    {
                        errPhone = "*Phone is required !";
                        return false;
                    }
                    else
                    {
                        errPhone = "";
                        spmt.Bind(2, phone.ToString());
                    }

                    spmt.Step();
                };
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<Contact> ListData()
        {
            var infoData = new List<Contact>();
            var sql = "SELECT * FROM Contact";

            using (var stt = sQLiteConnection.Prepare(sql))
            {
                while (stt.Step() == SQLiteResult.ROW)
                {
                    var id = Convert.ToInt32(stt["Id"]);
                    var name = (string)stt["Name"];
                    var desc = (string)stt["PhoneNumber"];
                   
                    var infoObj = new Contact(id, name, desc);
                    infoData.Add(infoObj);
                }
            }
            return infoData;
        }

        public List<Contact> FilterByName(string nameContact)
        {
            var infoData = new List<Contact>();
            var sql = "SELECT * FROM Contact " +
                "WHERE Name like ?";

            using (var stt = sQLiteConnection.Prepare(sql))
            {
                stt.Bind(1,"%" + nameContact.ToString() +"%");
                while (stt.Step() == SQLiteResult.ROW)
                {
                    var id = Convert.ToInt32(stt["Id"]);
                    var name = (string)stt["Name"];
                    var desc = (string)stt["PhoneNumber"];

                    var infoObj = new Contact(id, name, desc);
                    infoData.Add(infoObj);
                }
            }
            return infoData;
        }


    }



}
