using AutoMapper;
using PokeTrade.Domain;
using PokeTrade.Domain.Entities;
using PokeTrade.Domain.Enums;
using PokeTrade.Domain.ViewModel;
using System;

namespace PokeTrade.Application.AutoMapper
{
    public class AutoMapperSetup : Profile
    {
        public AutoMapperSetup()
        {
            #region ViewModel to Domain
            CreateMap<TradeViewModel, Trade>()
                .ForMember(x => x.PokemonsP1, y => y.MapFrom(vm => string.Join(",", vm.PokemonsP1)))
                .ForMember(x => x.PokemonsP2, y => y.MapFrom(vm => string.Join(",", vm.PokemonsP2)))
                .ForMember(x => x.BaseExpP1, y => y.MapFrom(vm => vm.BaseExperienceP1))
                .ForMember(x => x.BaseExpP2, y => y.MapFrom(vm => vm.BaseExperienceP2))
                .ForMember(x => x.Status, y => y.MapFrom(vm => Enum.Parse(typeof(TradeStatus), vm.Status)));
            #endregion

            #region Domain to ViewModel
            CreateMap<Trade, TradeViewModel>()
                .ForMember(x => x.PokemonsP1, y => y.MapFrom(tr => tr.PokemonsP1.Split(", ", System.StringSplitOptions.None)))
            .ForMember(x => x.PokemonsP2, y => y.MapFrom(tr => tr.PokemonsP2.Split(", ", System.StringSplitOptions.None)))
            .ForMember(x => x.BaseExperienceP1, y => y.MapFrom(vm => vm.BaseExpP1))
                .ForMember(x => x.BaseExperienceP2, y => y.MapFrom(vm => vm.BaseExpP2))
                .ForMember(x => x.Status, y => y.MapFrom(vm => vm.Status.ToString()));
            #endregion
        }

    }
}
