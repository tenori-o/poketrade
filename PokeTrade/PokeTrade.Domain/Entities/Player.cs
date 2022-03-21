using System;
using System.Collections.Generic;
using System.Text;

namespace PokeTrade.Domain.Entities
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public IEnumerable<Pokemon> Pokemons { get; set; }

        public Player()
        {
            Pokemons = new List<Pokemon>();
        }
    }
}
