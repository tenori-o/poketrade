using AutoMapper;
using PokeTrade.Domain.Entities;
using PokeTrade.Domain.ViewModel;

namespace PokeTrade.Application.AutoMapper
{
    public class AutoMapperSetup : Profile
    {
        public AutoMapperSetup()
        {
            #region ViewModel to Domain
            CreateMap<TradeViewModel, Trade>();
            CreateMap<PlayerViewModel, Player>();
            CreateMap<PokemonViewModel, Pokemon>();
            #endregion

            #region Domain to ViewModel
            CreateMap<Trade, TradeViewModel>();
            CreateMap<Player, PlayerViewModel>();
            CreateMap<Pokemon, PokemonViewModel>();
            #endregion
        }

    }
}
