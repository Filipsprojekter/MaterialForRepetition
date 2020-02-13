using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MockExam3WebApi.Models;

namespace MockExam3WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeassurementsController : ControllerBase
    {
        #region SQL connection og command opsætning
        public SqlConnection conn = new SqlConnection();
        public SqlCommand Command;
    #endregion

        #region Variabler for liste og objekt og connectionstring
        List<Meassurement> outputList = new List<Meassurement>();
        public Meassurement meassurement;
        public string dbConnectionstring =
            "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = Measurements; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";

        #endregion

        //Bruges når udkommenterede versioner bruges
        //public static string output;

        // GET: api/Meassurements

        [HttpGet]
        public List<Meassurement> GetAll()
        {
            conn.ConnectionString = dbConnectionstring;
            conn.Open();
            string sqlCommand = "SELECT * FROM Meassurement";
            Command = new SqlCommand(sqlCommand, conn);
            SqlDataReader rdr = Command.ExecuteReader();
           
            // Laver et objekt ved at parse til de rigtige typer, fra de rigtige indexer af getvalue
            while (rdr.Read())
            {
                 outputList.Add(new Meassurement(Int32.Parse(rdr.GetValue(0)+""),
                     Int32.Parse(rdr.GetValue(1)+""),
                     Int32.Parse(rdr.GetValue(2)+""),
                     Int32.Parse(rdr.GetValue(3)+""),
                     DateTime.Parse(rdr.GetValue(4)+"")));
            }
            return outputList;
            #region Udkommenterede version
            // Laver objektet på en lidt lang måde, måske nemmere at læse
            //while (rdr.Read())
            //{
            //    int id = Int32.Parse(rdr.GetValue(0) + "");
            //    int pressure = Int32.Parse(rdr.GetValue(1)+"");
            //    int humidity = Int32.Parse(rdr.GetValue(2) + "");
            //    int temperature = Int32.Parse(rdr.GetValue(3) + "");
            //    DateTime date = DateTime.Parse(rdr.GetValue(4)+"");


            //    outputList.Add(new Meassurement(id,pressure,humidity,temperature,date));
            //}

            // Laver returobjektet som en streng, virker ikke optimalt da dette ikke laves til et json objekt, og derfor ikke
            // kan bruges ordentligt i Typescript
            //while (rdr.Read())
            //{
            //    output = rdr.GetValue(0) + " " +
            //             rdr.GetValue(1) + " " +
            //             rdr.GetValue(2) + " " +
            //             rdr.GetValue(3) + " " +
            //             rdr.GetValue(4);
            //    outputList.Add(output);
            //}
            //
            #endregion
        }

        // GET: api/Meassurements/5
        [HttpGet]
        [Route("{id}")]
        public Meassurement GetById(int id)
        {
            conn.ConnectionString = dbConnectionstring;
            conn.Open();
            string sqlCommand = $"SELECT * FROM Meassurement WHERE Id = {id}";
            Command = new SqlCommand(sqlCommand, conn);
            SqlDataReader rdr = Command.ExecuteReader();
          
            while (rdr.Read())
            {
                meassurement = new Meassurement(Int32.Parse(rdr.GetValue(0) + ""), Int32.Parse(rdr.GetValue(1) + ""), Int32.Parse(rdr.GetValue(2) + ""), Int32.Parse(rdr.GetValue(3) + ""), DateTime.Parse(rdr.GetValue(4) + ""));
            }

            return meassurement;

            #region udkommenterede versioner 2
            // Laver outputtet som en string, kan ikke bruges hvis det skal sættes sammen med typescript
            //while(rdr.Read())
            //{

            //        output = rdr.GetValue(0) + " " +
            //        rdr.GetValue(1) + " " +
            //        rdr.GetValue(2) + " " +
            //        rdr.GetValue(3) + " " +
            //        rdr.GetValue(4);
            //}
            #endregion
        }

        // POST: api/Meassurements
        [HttpPost]
        public void Post([FromBody] Meassurement meassurement)
        {
            conn.ConnectionString = dbConnectionstring;
            conn.Open();
            string sqlCommand = $"INSERT INTO Meassurement VALUES({meassurement.Pressure},{meassurement.Humidity}," +
                                $"{meassurement.Temperature},{meassurement.TimeStamp})";
            Command = new SqlCommand(sqlCommand, conn);
            Command.ExecuteNonQuery();
        }

        // PUT: api/Meassurements/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            conn.ConnectionString = dbConnectionstring;
            conn.Open();
            string sqlCommand = $"DELETE FROM Meassurement WHERE Id = {id}";
            Command = new SqlCommand(sqlCommand, conn);
            Command.ExecuteNonQuery();
        }
    }
}
