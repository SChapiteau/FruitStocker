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

        [HttpGet]
        [Route("GetQuotationForCommand")]
        public async Task<QuoteCommandV1Result> GetQuotationForCommand(string fruitLotName, int quantity)
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
                    FinalPrice = (fruitLot.Price *1.05M),
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

        [HttpGet]
        [Route("/GetQuotationForCommandV3")]
        public async Task<QuoteCommandV1Result> GetQuotationForCommandV3(string fruitLotName, int quantity, int clientId)
        {
            // On peux acheter sur plusieurs Lots

            // Prix change en fonction du type de client { Association, SuperMarché, Primeur }"

            // Pour les association le prix est toujours à 0 mais on déclenche un credit d'impots

            // Les association ne peuvent prendre que des fruit périmé

            // Les primeur ne peuvent prendre que des fruit dont les date est a +7jour

            // Si le stock est a + de 100, le prix est réduit de 5%

            // Si le stock est à moins de 10, le prix est augmenté de 10%

            // Le stock est calculé en fonction des produit disponible pour le client

            // Si le client a fait plus 5 commande dans le moins il a droit a 2% de remise

            // Si le client accepte des produit a +2jour de la date de pérempition il a droit a 3% de remise sur ses lot



            //Nouvell fonctionnalité
            //On veux rajouter un nouveau client "Low Cost" qui ne peu prendre que des fruit date + 3jour


            return null;
        }

    }
}