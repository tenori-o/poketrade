using AutoMapper;
using Microsoft.Extensions.Configuration;
using PokeTrade.Domain.Entities;
using PokeTrade.Domain.IRepository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PokeTrade.Infrastructure.Repository
{
    public class TradeRepository : DapperRepository<Trade>, ITradeRepository
    {
		private readonly IMapper _mapper;

		public TradeRepository(IMapper mapper)
        {
			_mapper = mapper;
		}

        public IEnumerable<Trade> GetHistory()
        {
            var sql = @"select * from trade";

			return Query(sql); ;
		}

		public int Insert(Trade trade)
        {
            try
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
                var result = ExecuteAsync(sql, param);
                return result.Result;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Exception while reading from stream"))
                {
                    return 0;
                }
                throw ex;
            }
        }
    }
}
