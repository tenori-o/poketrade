using PokeTrade.Domain.Dtos;
using PokeTrade.Domain.ViewModel;
using System.Collections.Generic;

namespace PokeTrade.Application.IService
{
    public interface ITradeService
    {
        bool MakeTrade(TradeViewModel tradeVM);
        IEnumerable<TradeViewModel> GetHistory();
    }
}
