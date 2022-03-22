using PokeTrade.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PokeTrade.Domain.IRepository
{
    public interface ITradeRepository
    {
        IEnumerable<Trade> GetHistory();
        Task<int> Insert(Trade trade);
    }
}
