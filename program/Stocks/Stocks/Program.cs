using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stocks
{
    class Program
    {
        static void Main(string[] args)
        {
            var lineNumber = 0;
            using (SqlConnection conn = new SqlConnection(@"data source=DESKTOP-JCR4R6U;initial catalog=Dataset;trusted_connection=true"))
            {
                conn.Open();
                using (StreamReader reader = new StreamReader(@"C:\Users\Wolfy\Desktop\Duomenu analitika\Projektas\data_set\FINAL_FROM_DF.csv"))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        if (lineNumber != 0)
                          {

                            var values = line.Split(',');

                            var SQL = "INSERT INTO Dataset.dbo.Stocks VALUES ('" + values[0] + "','" + values[1] + "','" + values[2] + "','" + values[3] + "','" + values[4] + "','" + values[5] + "','" + values[6] + "','" + values[7] + "','" + values[8] + "')";

                            var cmd = new SqlCommand();
                            cmd.CommandText = SQL;
                            cmd.CommandType = System.Data.CommandType.Text;
                            cmd.Connection = conn;
                            cmd.ExecuteNonQuery();
                        }
                        lineNumber++;
                        
                    }
                }
                conn.Close();
            }
            Console.WriteLine("Done");
        }
    }
}
