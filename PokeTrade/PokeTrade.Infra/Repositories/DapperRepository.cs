using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using PokeTrade.Domain.IRepository;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace PokeTrade.Infrastructure.Repository
{
    public class DapperRepository<T> : IGenericDapperRepository<T> where T : class
    {
        private readonly IConfiguration _configuration;
        private string ConnectionString;

        public DapperRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            ConnectionString = _configuration.GetSection("ConnectionString").Value;
        }

        public int Execute(string sql, object param = null, IDbTransaction transaction = null, int commandTimeout = 30, CommandType? commandType = null)
        {
            using (var connection = new NpgsqlConnection(ConnectionString))
            {
                connection.Open();
                return connection.Execute(sql, param, transaction, commandTimeout, commandType);
            }
        }

        public Task<int> ExecuteAsync(string sql, object param = null, IDbTransaction transaction = null, int commandTimeout = 30, CommandType? commandType = null)
        {
            using (var connection = new NpgsqlConnection(ConnectionString))
            {
                connection.Open();
                return connection.ExecuteAsync(sql, param, transaction, commandTimeout, commandType);
            }
        }

        public IEnumerable<T> Query<T>(string sql, object param = null, IDbTransaction transaction = null, bool buffered = true, int commandTimeout = 30, CommandType? commandType = null)
        {
            using (var connection = new NpgsqlConnection(ConnectionString))
            {
                connection.Open();
                return connection.Query<T>(sql, param, transaction, buffered, commandTimeout);
            }
        }
        public T QueryFirst<T>(string sql, object param = null, IDbTransaction transaction = null, int commandTimeout = 30, CommandType? commandType = null)
        {
            using (var connection = new NpgsqlConnection(ConnectionString))
            {
                connection.Open();
                return connection.QueryFirst<T>(sql, param, transaction, commandTimeout);
            }
        }

        public Task<IEnumerable<T>> QueryAsync<T>(string sql, object param = null, IDbTransaction transaction = null, int commandTimeout = 30, CommandType? commandType = null)
        {
            using (var connection = new NpgsqlConnection(ConnectionString))
            {
                connection.Open();
                return connection.QueryAsync<T>(sql, param, transaction, commandTimeout, commandType);
            }
        }

        public Task<T> QueryFirstAsync<T>(string sql, object param = null, IDbTransaction transaction = null, int commandTimeout = 30, CommandType? commandType = null)
        {
            using (var connection = new NpgsqlConnection(ConnectionString))
            {
                connection.Open();
                return connection.QueryFirstAsync<T>(sql, param, transaction, commandTimeout, commandType);
            }
        }
    }
}
