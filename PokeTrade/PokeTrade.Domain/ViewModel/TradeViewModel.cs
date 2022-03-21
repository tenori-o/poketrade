using System;

namespace PokeTrade.Domain.ViewModel
{
    public class TradeViewModel
    {
        public PlayerViewModel Player1 { get; set; }
        public PlayerViewModel Player2 { get; set; }
        public DateTime InitDate { get; set; }
        public DateTime CloseDate { get; set; }
        public string Status { get; set; }
    }
}
