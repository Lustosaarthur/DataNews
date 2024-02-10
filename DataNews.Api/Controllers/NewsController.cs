using DataNews.Api.Entities;
using DataNews.Api.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DataNews.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        public readonly DataNewsDbContext _context;
        public NewsController(DataNewsDbContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            var allNews = _context.News.Where(d => !d.IsDeleted).ToList();

            return Ok(allNews);
        }
        
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetById(Guid id)
        {
            var news = _context.News.FirstOrDefault(d => d.Id == id);
            if (news == null)
                return NotFound();
            return Ok(news);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Add(NewsEntities news)
        {
            news.IsDeleted = false;
            _context.News.Add(news);
            _context.SaveChanges();
            return Created();
        }
        [HttpGet("by-category/{category}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetByCategory(string category)
        {
            var news = _context.News.Where(d => !d.IsDeleted).FirstOrDefault(d => d.Category == category);
            if (news == null)
                return NotFound();
            return Ok(news);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Update(Guid id, NewsEntities newsData)
        {
            var news = _context.News.FirstOrDefault(d => d.Id == id);
            if (news == null)
                return NotFound();

            news.Update(newsData.Name, newsData.Description, newsData.Author, newsData.PublicateDate);
            _context.Update(news);
            _context.SaveChanges();
            return Ok();
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]

        public IActionResult Delete(Guid id)
        {
            var news = _context.News.SingleOrDefault(d => d.Id == id);
            if (news == null)
                return NotFound();
            news.Delete();
           _context.SaveChanges();
            return NoContent();
        }
    }
}
