using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using System.Data;
//using System.Data.SQLite;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplicationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<UsersModel> Get()
        {



          return   Execute("Select * From Users");
          
            /*
            return new[]
        {
            new UsersModel { UserID = 1 ,UserName="Jon",UserAddress="House 1 Street 1",UserProfileLink="/Profile1"},
            new UsersModel { UserID = 2 ,UserName="Robert",UserAddress="House 2 Street 2",UserProfileLink="/Profile2"},
            new UsersModel { UserID = 3,UserName="Maria",UserAddress="House 3 Street 3",UserProfileLink="/Profile3" }
        };
            
            */


        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

       


        // POST api/<UsersController>
        [HttpPost]
        public string Post([FromBody] UsersModel users)
        {

            const string query = "INSERT INTO Users(ID,UserID,UserName,UserAddress,UserProfileLink) VALUES(@ID,@UserID,@UserName,@UserAddress,@UserProfileLink)";

            //here we are setting the parameter values that will be actually 
            //replaced in the query in Execute method
            var args = new Dictionary<string, object>
                {
                    {"@ID", users.UserID},
                    {"@UserID", users.UserID},
                    {"@UserName", users.UserName},
                    {"@UserAddress", users.UserAddress},
                    {"@UserProfileLink", users.UserProfileLink}

                };
            if (ExecuteWrite(query, args) >0)
            {
                return "Insert Successfully";
            }
            else
            {
                return "Got an Error";
            }
            



        }

        private int ExecuteWrite(string query, Dictionary<string, object> args)
        {
            int numberOfRowsAffected;

            //setup the connection to the database
            using (var con = new SqliteConnection("Data Source=MICRODB.db"))
            {
                con.Open();

                //open a new command
                using (var cmd = new SqliteCommand(query, con))
                {
                    //set the arguments given in the query
                    foreach (var pair in args)
                    {
                        cmd.Parameters.AddWithValue(pair.Key, pair.Value);
                    }

                    //execute the query and get the number of row affected
                    numberOfRowsAffected = cmd.ExecuteNonQuery();
                }
                con.Close();

                return numberOfRowsAffected;
            }
        }
        
        private List<UsersModel> Execute(string query)
        {

            // List<UsersModel> user = new List<UsersModel>();
            var users = new List<UsersModel>();

            using (var con = new SqliteConnection("Data Source=MICRODB.db"))
            {
                con.Open();
                using (var cmd = new SqliteCommand(query, con))
                {
                    
                    /*
                    foreach (KeyValuePair<string, object> entry in args)
                    {
                        cmd.Parameters.AddWithValue(entry.Key, entry.Value);
                    }
                    */

                    SqliteDataReader sqReader = cmd.ExecuteReader();
                   
                    try
                    {
                        // Always call Read before accessing data.
                        while (sqReader.Read())
                        {
                            Console.WriteLine(sqReader.GetInt32(1).ToString() + " " +
                            sqReader.GetString(2) + " " + sqReader.GetString(3));
                            users.Add(new UsersModel { UserID = sqReader.GetInt32(1), UserName = sqReader.GetString(2), UserAddress = sqReader.GetString(3), UserProfileLink = sqReader.GetString(4) });
                           
                        }
                    }
                    finally
                    {
                        // always call Close when done reading.
                        sqReader.Close();

                        // Close the connection when done with it.
                        con.Close();
                    }

                  


                }
            }

            return users;
        }

        
        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
