using PokeTrade.Domain.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PokeTrade.Application.IService
{
    public interface ITradeService
    {
        bool MakeTrade(TradeViewModel tradeVM);
        IEnumerable<TradeViewModel> GetHistory();
    }
}
