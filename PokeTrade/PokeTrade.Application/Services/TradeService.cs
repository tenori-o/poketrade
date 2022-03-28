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

            if (tradeVM.PokemonsP1.Length < 1 || tradeVM.PokemonsP1.Length > 6)
            {
                throw new TradeException("Player 1 must informe between 1 and 6 pokemons");
            }

            if (tradeVM.PokemonsP2.Length < 1 || tradeVM.PokemonsP2.Length > 6)
            {
                throw new TradeException("Player 2 must informe between 1 and 6 pokemons");
            }

            if (trade.BaseExpP1 < trade.BaseExpP2)
            {
                var baseDiff = trade.BaseExpP2 * 0.85;

                if (trade.BaseExpP1 > baseDiff)
                {
                    SetFairTrade(trade);
                } else
                {
                    SetUnfairTrade(trade, $"Unfair trading. The base exp ({trade.BaseExpP1}) value from player 1 pokemons, is too low for trading player 2 pokemons with base exp ({trade.BaseExpP2}).");
                }
            } else
            {
                var baseDiff = trade.BaseExpP1 * 0.85;

                if (trade.BaseExpP2 > baseDiff)
                {
                    SetFairTrade(trade);
                }
                else
                {
                    SetUnfairTrade(trade, $"Unfair trading. The base exp ({trade.BaseExpP2}) value from player 2 pokemons, is too low for trading player 1 pokemons with base exp ({trade.BaseExpP1}).");
                }
            }

            return true;
        }

        public IEnumerable<TradeViewModel> GetHistory()
        {
            var tradeList = _tradeRepository.GetHistory();
            var result =  _mapper.Map<IEnumerable<Trade>, IEnumerable<TradeViewModel>> (tradeList);

            return result;
        }

        private void SetFairTrade(Trade trade)
        {
            trade.Status = TradeStatus.FAIR;
            _tradeRepository.Insert(trade);
        }

        private void SetUnfairTrade(Trade trade, string message)
        {
            trade.Status = TradeStatus.UNFAIR;
            _tradeRepository.Insert(trade);

            throw new TradeException(message);
        }

    }
}
