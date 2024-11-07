using AnimeTier.Api.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Context;

namespace AnimeTier.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimeController : ControllerBase
    {
        private readonly AnimeTierListContext _context;
        private readonly IAnimeRepository _animeRepo;

        public AnimeController (AnimeTierListContext context, IAnimeRepository animeRepo)
        {
            _context = context; 
            _animeRepo = animeRepo;
        }

        [HttpGet]
        [Route("GetAllAnime")]
        public async Task<ActionResult> GetAllAnime(CancellationToken ct)
        {
            var data = _animeRepo.GetAnimes();
            return Ok(await Task.FromResult(data));
        }
    }
}
