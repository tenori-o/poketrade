using AutoMapper;
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
		private readonly IMapper _mapper;

		public TradeRepository(IConfiguration configuration, IMapper mapper) : base(configuration)
        {
			_mapper = mapper;
		}

        public IEnumerable<Trade> GetHistory()
        {
            var sql = @"select * from trade";

			return Query<Trade>(sql); ;
		}

		public Task<int> Insert(Trade trade)
        {
			var sql = @"insert into trade(PokemonsP1, PokemonsP2, BaseExpP1, BaseExpP2, Status) values(@pokep1, @pokep2, @baseexpp1, @baseexpp2, @status);";

			var param = new
			{
				pokep1 = trade.PokemonsP1,
				pokep2 = trade.PokemonsP2,
				baseexpp1 = trade.BaseExpP1,
				baseexpp2 = trade.BaseExpP2,
				status = trade.Status
			};

			return ExecuteAsync(sql, param);
        }
    }
}
