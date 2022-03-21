using PokeTrade.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PokeTrade.Domain.IRepository
{
    public interface ITradeRepository
    {
        Task<Trade> Get(int id);
        Task<IEnumerable<Trade>> GetAll(int id);
        Task<int> Update(Trade trade);
        Task<int> Delete(int id);
    }
}
