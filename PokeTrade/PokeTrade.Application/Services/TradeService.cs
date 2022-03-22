using AutoMapper;
using PokeTrade.Application.IService;
using PokeTrade.Domain.Dtos;
using PokeTrade.Domain.Entities;
using PokeTrade.Domain.Enums;
using PokeTrade.Domain.Exceptions;
using PokeTrade.Domain.IRepository;
using PokeTrade.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace PokeTrade.Application.Services
{
    public class TradeService : ITradeService
    {
        private readonly ITradeRepository _tradeRepository;
        private readonly IMapper _mapper;

        public TradeService(ITradeRepository tradeRepository, IMapper mapper)
        {
            _tradeRepository = tradeRepository;
            _mapper = mapper;
        }

        public bool MakeTrade(TradeViewModel tradeVM)
        {
            // Verificar se a soma do baseExperience dos 2 jogadores é similar e considerar a troca justa ou não
            var trade = _mapper.Map<Trade>(tradeVM);

            if (tradeVM.BaseExperienceP1 != tradeVM.BaseExperienceP2)
            {
                tradeVM.Status = TradeStatus.UNFAIR.ToString();
                _tradeRepository.Insert(trade);

                throw new TradeException("Unfair trade");
            }

            tradeVM.Status = TradeStatus.FAIR.ToString();
            _tradeRepository.Insert(trade);

            return true;
        }
        
        public IEnumerable<TradeViewModel> GetHistory()
        {
            var tradeList = _tradeRepository.GetHistory();
            var result =  _mapper.Map<IEnumerable<Trade>, IEnumerable<TradeViewModel>> (tradeList);

            return result;
        }

    }
}
