using DotNetWithSQLiteUsingDapper.Model;

namespace DotNetWithSQLiteUsingDapper.Services
{
    public interface IBlogService
    {
        Task<IEnumerable<BlogModel>> GetAll();
        //Task<BlogModel> GetById(int id);
        //Task Create(CreateRequest model);
        //Task Update(int id, UpdateRequest model);
        //Task Delete(int id);
    }
    public class BlogService : IBlogService
    {

        public BlogService()
        {
        }
        public async Task<IEnumerable<BlogModel>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
