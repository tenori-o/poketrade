using PokeTrade.Domain.Enums;
using System;
using System.Collections.Generic;

namespace PokeTrade.Domain.Entities
{
    public class Trade
    {
        public int Id { get; set; }
        public string PokemonsP1 { get; set; }
        public int BaseExpP1 { get; set; }
        public string PokemonsP2 { get; set; }
        public int BaseExpP2 { get; set; }
        public TradeStatus Status { get; set; }
    }
}
