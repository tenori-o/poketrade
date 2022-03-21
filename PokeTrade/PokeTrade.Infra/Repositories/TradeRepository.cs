using Microsoft.Extensions.Configuration;
using PokeTrade.Domain.Entities;
using PokeTrade.Domain.IRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PokeTrade.Infrastructure.Repository
{
    public class TradeRepository : DapperRepository<Trade>, ITradeRepository
    {
        private readonly IConfiguration _configuration;

        public TradeRepository(IConfiguration configuration) : base(configuration) { }

        public Task<Trade> Get(int id)
        {
            var sql = @"SELECT * FROM Trade";
            return QueryFirstAsync<Trade>(sql);
        }

        public Task<IEnumerable<Trade>> GetAll(int id)
        {
            var sql = @"SELECT TOP 1 * FROM Trade";
            return QueryAsync<Trade>(sql);
        }

        public Task<int> Update(Trade trade)
        {
            var sql = @"Update Trade
            SET InitDate = @initDate,
                CloseDate = @closeDate,
                Status = @status
            WHERE Id = @id";

            var param = new
            {
                id = trade.Id,
                initDate = trade.InitDate,
                closeDate = trade.CloseDate,
                status = trade.Status
            };

            return ExecuteAsync(sql, param);
        }

        public Task<int> Delete(int id)
        {
            var sql = @"DELETE FROM trade WHERE Id = @id";

            var param = new
            {
                id = id
            };

            return ExecuteAsync(sql, param);
        }

    }
}
