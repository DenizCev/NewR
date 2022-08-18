using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplicationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        // GET: api/<MessagesController>
        [HttpGet]


        public IEnumerable<MessagesModel> Get()
        {
            return new[]
        {
            new MessagesModel { MessageID=1,MessageHeadline="Hello World",MessageText="Welcome to asp.net" ,UserID=1},
            new MessagesModel { MessageID=2,MessageHeadline="Breaking News",MessageText="Nasa is preparing 18 separate missions in 2022" ,UserID=2},
            new MessagesModel { MessageID=3,MessageHeadline="England Woman",MessageText="England Women make history as Kelly’s extra-time goal seals Euros glory" ,UserID=3},

        };
        }

        // GET api/<MessagesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MessagesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<MessagesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MessagesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
