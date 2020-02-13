using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RestCoinService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoinController : ControllerBase
    {
        public List<Coin> coinlist = new List<Coin>() {new Coin(1,"Gold DK 1640", 2500, "Mike"),new Coin(2,"Gold NL 1764",5000,"Anbo"),new Coin(3,"Gold FR1644",35000,"Hammer"),new Coin(4,"Gold FR 1644",0,"Auction"),new Coin(5,"Silver GR 333",2500,"Mike") };
        // GET: api/Coin
        [HttpGet]
        public IList<Coin> GetCoins()
        {
            return coinlist;
        }

        // GET: api/Coin/5
        [HttpGet]
        [Route ("{id}")]
        public Coin GetOneCoin(int id)
        {
            return coinlist.Find(i => i.Id == id);
        }

        // POST: api/Coin
        [HttpPost]
        public void AddCoin([FromBody] Coin value)
        {
            coinlist.Add(value);
        }

        // PUT: api/Coin/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
