using System.Collections.Generic;

namespace PokeTrade.Domain.ViewModel
{
    public class PlayerViewModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public IEnumerable<PokemonViewModel> Pokemons { get; set; }
    }
}
