using System;
using System.Collections.Generic;
using System.Text;

namespace PokeTrade.Domain.Dtos
{
    public class PokemonRootDto
    {
        public List<PokemonDto> results { get; set; }

        public PokemonRootDto()
        {
            results = new List<PokemonDto>();
        }
    }
}
