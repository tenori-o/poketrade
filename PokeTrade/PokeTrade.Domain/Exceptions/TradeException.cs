using System;
using System.Collections.Generic;
using System.Text;

namespace PokeTrade.Domain.Exceptions
{
    public class TradeException : Exception 
    {
        public TradeException(string message) : base (message) { }
    }
}
