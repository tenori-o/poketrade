using System;
using System.Collections.Generic;
using System.Text;

namespace PokeTrade.Domain
{
    public class TradeDto
    {
        public int IdTrade { get; set; }
        public DateTime InitDate { get; set; }
        public DateTime CloseDate { get; set; }
        public int Status { get; set; }
        public int IdPlayer { get; set; }
        public string PlayerName { get; set; }
        public string Email { get; set; }
        public int IdPokemon { get; set; }
        public int IdPokeApi { get; set; }
        public string PokemonName { get; set; }
        public int BaseExperience { get; set; }
    }
}
