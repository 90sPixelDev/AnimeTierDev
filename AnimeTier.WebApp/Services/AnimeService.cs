using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using SharedLibrary.Context;
using SharedLibrary.Models;

namespace AnimeTier.WebApp.Services
{
    public class AnimeService
    {
        private readonly AnimeTierListContext _context;

        public AnimeService(AnimeTierListContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Anime>> GetAnimesAsync()
        {
            return await _context.Animes.ToListAsync();
        }
    }
}
