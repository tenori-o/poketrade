using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace PokeTrade.Domain.IRepository
{
    public interface IGenericDapperRepository<T>
    {
        int Execute(string sql, object param = null, IDbTransaction transaction = null, int commandTimeout = 30, CommandType? commandType = null);
        Task<int> ExecuteAsync(string sql, object param = null, IDbTransaction transaction = null, int commandTimeout = 30, CommandType? commandType = null);
        IEnumerable<T> Query(string sql, object param = null, IDbTransaction transaction = null, bool buffered = true, int commandTimeout = 30, CommandType? commandType = null);
        Task<IEnumerable<T>> QueryAsync(string sql, object param = null, IDbTransaction transaction = null, int commandTimeout = 30, CommandType? commandType = null);
        T QueryFirst(string sql, object param = null, IDbTransaction transaction = null, int commandTimeout = 30, CommandType? commandType = null);
        Task<T> QueryFirstAsync(string sql, object param = null, IDbTransaction transaction = null, int commandTimeout = 30, CommandType? commandType = null);
    }
}
