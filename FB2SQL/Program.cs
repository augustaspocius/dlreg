using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FB2SQL
{
    class Program
    {
        static void Main(string[] args)
        {
            DBContext fbcontext = new DBContext(Properties.Settings.Default.FBConnString);
            DBContext sqlcontext = new DBContext(Properties.Settings.Default.SQLConnString);

            try
            {
                DataTable fbusers = fbcontext.ReadFromDBToDataTable(@"SELECT 
                    ID, 
                    USERNAME, 
                    FIRSTNAME, 
                    LASTNAME, 
                    DEPARTMENTID, 
                    PERSONELNR 
                FROM users 
                WHERE STATEID = 1
                ORDER BY ID");
                //DataTable fbusers = fbcontext.ReadFromDBToDataTable("SELECT * FROM users WHERE STATEID = 1 ORDER BY ID");
                DataTable sqlusers = sqlcontext.ReadFromDBToDataTable("SELECT * FROM workers");

                foreach (DataRow row in fbusers.Rows)
                {
                    DataRow dr = sqlusers.AsEnumerable().SingleOrDefault(r => r.Field<int>("ID") == (int)row["ID"]);
                    if (dr != null)
                    {
                        if (((string)row["USERNAME"] + row["ID"]) != (string)dr["USERNAME"] || row["FIRSTNAME"] != dr["NAME"] || row["LASTNAME"] != dr["LASTNAME"] || row["DEPARTMENTID"] != dr["DEPARTMENTID"] || row["PERSONELNR"] != dr["WORKPLACE"])
                        {
                            string userupdatesql = @"UPDATE workers SET USERNAME=?, FULLNAME=?, NAME=?, LASTNAME=?, DEPARTMENTID=?, WORKPLACE=?  WHERE ID=?";
                            sqlcontext.ExecuteNonQuery(userupdatesql,
                                (string)row["USERNAME"] + row["ID"],
                                row["FIRSTNAME"] + " " + row["LASTNAME"],
                                row["FIRSTNAME"],
                                row["LASTNAME"],
                                row["DEPARTMENTID"],
                                row["PERSONELNR"],
                                row["ID"]);
                        }
                    }
                    else
                    {
                        string userinsertsql = @"INSERT INTO workers (ID, USERNAME, FULLNAME, NAME, LASTNAME, DEPARTMENTID, WORKPLACE) 
                                            VALUES (?, ?, ?, ?, ?, ?, ?)";
                        sqlcontext.ExecuteNonQuery(userinsertsql,
                            row["ID"],
                            (string)row["USERNAME"] + row["ID"],
                            row["FIRSTNAME"] + " " + row["LASTNAME"],
                            row["FIRSTNAME"],
                            row["LASTNAME"],
                            row["DEPARTMENTID"],
                            row["PERSONELNR"]);
                    }

                    //Insert monthreg if user is active and this month's monthreg is missing
                    string currentmonthid = DateTime.Now.ToString("yyyyMM");
                    int rowid = sqlcontext.ReadFirstFieldAsInt(@"SELECT COALESCE(ROWID, -1) 
                                                            FROM monthreg 
                                                            WHERE monthid=? AND workerid=?"
                                                                , currentmonthid, row["ID"]);
                    if (rowid == -1) //-1 - no monthreg for this user, insert
                    {
                        string monthreginsertsql = "INSERT INTO monthreg (MONTHID, WORKERID) VALUES (?, ?)";
                        sqlcontext.ExecuteNonQuery(monthreginsertsql, currentmonthid, row["ID"]);
                    }
                }


                int maxid = sqlcontext.ReadFirstFieldAsInt("SELECT COALESCE(MAX(ID), -1) FROM devicereg");

                DataTable attendants = fbcontext.ReadFromDBToDataTable("SELECT * FROM attendant WHERE ID > ? ORDER BY ID", maxid);
                string devicereginsert =
                    @"INSERT INTO devicereg (ID, WORKERID, DEVICEID, TIME, INOUT) VALUES (?, ?, ?, ?, ?)";
                foreach (DataRow row in attendants.Rows)
                {
                    sqlcontext.ExecuteNonQuery(devicereginsert, row["ID"], row["USERID"], row["DEVICEID"], row["WHEN"], row["INOUT"]);
                }

                HttpClient client = new HttpClient();
                var values = new Dictionary<string, string> { };
                var content = new FormUrlEncodedContent(values);
                var response = client.PostAsync(Properties.Settings.Default.DLRegAPI + "monthregs?lastid=" + maxid, content);
                if (response.Result.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    sqlcontext.ExecuteNonQuery("DELETE FROM devicereg WHERE ID > ?", maxid);
                    throw new Exception(response.Result.StatusCode.ToString()+ ": ");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
