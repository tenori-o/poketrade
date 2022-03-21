using AutoMapper;
using PokeTrade.Application.IService;
using PokeTrade.Domain.Entities;
using PokeTrade.Domain.Exceptions;
using PokeTrade.Domain.IRepository;
using PokeTrade.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public Task<bool> MakeTrade(TradeViewModel tradeVM)
        {
            // Verificar se a soma do baseExperience dos 2 jogadores é similar e considerar a troca justa ou não
            int sumBaseExpPlayer1 = tradeVM.Player1.Pokemons.Sum(item => item.BaseExperience);
            int sumBaseExpPlayer2 = tradeVM.Player2.Pokemons.Sum(item => item.BaseExperience);

            if (sumBaseExpPlayer1 != sumBaseExpPlayer2)
            {
                throw new TradeException("Trade not fair");
            }

            var trade = _mapper.Map<Trade>(tradeVM);

            // insere informação dos players

            // insere informação dos pokemons

            // insere informação do trade

            // insere informação dos itens de trade

            return null;
        }
        
        public Task<IEnumerable<TradeViewModel>> GetHistoryByPlayer(PlayerViewModel player)
        {
            throw new NotImplementedException();
        }
    }
}
