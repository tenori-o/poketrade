using System;
using System.Collections.Generic;

namespace PokeTrade.Domain.ViewModel
{
    public class TradeViewModel
    {
        public string[] PokemonsP1 { get; set; }
        public int BaseExperienceP1 { get; set; }
        public string[] PokemonsP2 { get; set; }
        public int BaseExperienceP2 { get; set; }
        public string Status { get; set; }
    }
}
