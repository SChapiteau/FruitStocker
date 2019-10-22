using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FruitStockerAPI.ResultModel
{
    public class QuoteCommandV1Result
    {
        public QuoteCommandV1ResultType Type { get; set; }

        public decimal FinalPrice { get; set; }

        public int FruitLotId { get; set; }
    }

    public enum QuoteCommandV1ResultType
    {
        SUCCES,
        NO_AVAILABLE_FRUIT_LOT_FOUND,
    }

}
