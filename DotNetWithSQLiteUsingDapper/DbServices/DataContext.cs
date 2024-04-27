using Dapper;
using DotNetWithSQLiteUsingDapper.Queries;
using Microsoft.Data.Sqlite;
using System.Data;
using System.Transactions;

namespace DotNetWithSQLiteUsingDapper.DbServices
{
    public class DataContext
    {
        private readonly SqliteConnection _connection;

        public DataContext(string con)
        {
            _connection = new SqliteConnection(con);
        }
        public SqliteConnection CreateConnection()
        {
            return new SqliteConnection(_connection.ConnectionString);
        }

        public async Task Init()
        {
            // create database tables if they don't exist
            await _initUsers();

            async Task _initUsers()
            {
                var sql = BlogQuery.CreateBlogTable;
                await _connection.ExecuteAsync(sql);
            }
        }

        public async Task<bool> InitializeDBAsync()
        {

            var createTable = BlogQuery.CreateBlogTable;
            var insertQuery = BlogQuery.Insert;
            _connection.Open();
            using var transaction = _connection.BeginTransaction();
            try
            {
                await _connection.ExecuteAsync(BlogQuery.CreateBlogTable, transaction: transaction);

                // Check if the Customer table exists
                var tableExists = await _connection.QueryFirstOrDefaultAsync<int>(
                    "SELECT COUNT(*) FROM sqlite_master WHERE type='table' AND name='Customer';", transaction: transaction);

                if (tableExists > 0)
                {
                    // Table exists and populated, no need to seed database again
                    return true;
                }

                await _connection.ExecuteAsync(BlogQuery.Insert, transaction: transaction);

                // Commit the transaction if everything is successful
                transaction.Commit();
                _connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                // An error occurred, rollback the transaction
                transaction.Rollback();
                _connection.Close();
                return false;
            }
        }
    }
}
