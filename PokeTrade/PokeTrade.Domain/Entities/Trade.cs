using PokeTrade.Domain.Enums;
using System;
using System.Collections.Generic;

namespace PokeTrade.Domain.Entities
{
    public class Trade
    {
        public int Id { get; set; }
        public DateTime InitDate { get; set; }
        public DateTime CloseDate { get; set; }
        public TradeStatus Status { get; set; }
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
    }
}
