using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FruitStockerAPI.ResultModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FruitStockerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandeController : ControllerBase
    {

        private readonly FruitStockerContext _context;

        public CommandeController(FruitStockerContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<QuoteCommandV1Result> QuoteCommandV1(string fruitLotName, int quantity)
        {
            var fruitLot = _context.FruitLots.Where(f => f.ExpirationDate >= DateTime.Now )
                                            .Where(f => f.Name == fruitLotName )
                                            .Where(f=> f.QuantityLeft >= quantity)
                                            .OrderBy(f => f.ExpirationDate)
                                            .FirstOrDefault();

            if (fruitLot != null)
            {
                return new QuoteCommandV1Result()
                {
                    Type = QuoteCommandV1ResultType.SUCCES,
                    FinalPrice = fruitLot.Price,
                    FruitLotId = fruitLot.Id,
                };
            }
            else
            {
                return new QuoteCommandV1Result()
                {
                    Type = QuoteCommandV1ResultType.NO_AVAILABLE_FRUIT_LOT_FOUND,                  
                };
            }
        }

    }
}