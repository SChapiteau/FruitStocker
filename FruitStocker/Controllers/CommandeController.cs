using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FruitStockerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandeController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CommandFruit(Guid fruitLot, string clientName, int quantity)
        {
            // Vériier si le lot n'est pas périmé

            // Vérifier si la quantité restante est suffisante

            // Créer la commande

            throw new NotImplementedException("Construction en cour");
        }

    }
}