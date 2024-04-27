using DotNetWithSQLiteUsingDapper.Model;
using DotNetWithSQLiteUsingDapper.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetWithSQLiteUsingDapper.Controllers
{
    [Route("api/blog")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private IBlogService _blogService;
        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var blogs = await _blogService.GetAll();
            return Ok(blogs);
        }

        [HttpPost]
        public async Task<ResponseModel> Create(BlogRequestModel requestModel)
        {
            ResponseModel model = new ResponseModel();
            model = await _blogService.Create(requestModel);
            return model;
        }

        [HttpPut("{id}")]
        public async Task<ResponseModel> Update(int id, BlogUpdateModel requestModel)
        {
            ResponseModel model = new ResponseModel();
            model = await _blogService.Update(id, requestModel);
            return model;
        }
    }
}
