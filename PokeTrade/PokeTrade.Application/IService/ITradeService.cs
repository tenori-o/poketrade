using PokeTrade.Domain.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PokeTrade.Application.IService
{
    public interface ITradeService
    {
        Task<bool> MakeTrade(TradeViewModel trade);
        Task<IEnumerable<TradeViewModel>> GetHistoryByPlayer(PlayerViewModel player);
    }
}
