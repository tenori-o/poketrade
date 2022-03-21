using System;
using System.Collections.Generic;
using System.Text;

namespace PokeTrade.Domain.Entities
{
    public class Pokemon
    {
        public int Id { get; set; }
        public int IdPokeAPI { get; set; }
        public string Name { get; set; }
        public int BaseExperience { get; set; }
    }
}
