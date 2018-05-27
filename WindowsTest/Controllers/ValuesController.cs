using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;


namespace WindowsTest.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        IConfiguration _iconfiguration;
        MySqlConnection dbcon = new MySqlConnection("Database=windowsdemo;Data Source=db.windowsdemo.com;User Id=windowsdemo;Password=secrete;SslMode=none");

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            
            dbcon.Open();
            MySqlCommand command = dbcon.CreateCommand();
            command.CommandText = "select * from names";
            MySqlDataReader reader = command.ExecuteReader();
            ArrayList names = new ArrayList();
            {
                while (reader.Read())
                    names.Add(reader["name".ToString()]);
            }
            reader.Close();
            dbcon.Close();
            string[] returnArray = names.ToArray(typeof(string)) as string[];
            return returnArray;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            dbcon.Open();
            MySqlCommand command = dbcon.CreateCommand();
            command.CommandText = String.Format("select * from names where id = {0}", id);
            MySqlDataReader reader = command.ExecuteReader();
            ArrayList names = new ArrayList();
            {
                while (reader.Read())
                    names.Add(reader["name".ToString()]);
            }
            reader.Close();
            dbcon.Close();
            return names[0].ToString();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
            dbcon.Open();
            MySqlCommand command = dbcon.CreateCommand();
            command.CommandText = String.Format("insert into names (name) values (\"{0}\")", value);
            MySqlDataReader reader = command.ExecuteReader();
            ArrayList names = new ArrayList();
            {
                while (reader.Read())
                    names.Add(reader["name".ToString()]);
            }
            reader.Close();
            dbcon.Close();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
            dbcon.Open();
            MySqlCommand command = dbcon.CreateCommand();
            command.CommandText = String.Format("update names set name = \"{0}\" where id = {1}", value, id);
            MySqlDataReader reader = command.ExecuteReader();
            ArrayList names = new ArrayList();
            {
                while (reader.Read())
                    names.Add(reader["name".ToString()]);
            }
            reader.Close();
            dbcon.Close();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            dbcon.Open();
            MySqlCommand command = dbcon.CreateCommand();
            command.CommandText = String.Format("delete from names where id = {0}", id);
            MySqlDataReader reader = command.ExecuteReader();
            ArrayList names = new ArrayList();
            {
                while (reader.Read())
                    names.Add(reader["name".ToString()]);
            }
            reader.Close();
            dbcon.Close();
        }
    }
}
