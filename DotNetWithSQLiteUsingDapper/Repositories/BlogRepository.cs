using DotNetWithSQLiteUsingDapper.DbServices;
using DotNetWithSQLiteUsingDapper.Model;
using Dapper;
using System.Linq.Expressions;

namespace DotNetWithSQLiteUsingDapper.Repositories
{
    public interface IBlogRepository
    {
        Task<IEnumerable<BlogModel>> GetAll();
        //Task<BlogModel> GetById(int id);
        //Task<BlogModel> GetByEmail(string email);
        //Task Create(BlogModel user);
        //Task Update(BlogModel user);
        //Task Delete(int id);
    }

    public class BlogRepository : IBlogRepository
    {
        private DataContext _context;

        public BlogRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<BlogModel>> GetAll()
        {
            //using var connection = _context.CreateConnection();
            //    var sql = """
            //    SELECT * FROM Users
            //""";
            //    return await connection.QueryAsync<BlogModel>(sql);
            throw new NotImplementedException();
        }
    }
}
