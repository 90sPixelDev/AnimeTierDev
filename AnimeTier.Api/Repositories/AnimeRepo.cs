using AnimeTier.Api.Interfaces;
using SharedLibrary.Context;
using SharedLibrary.Models;

namespace AnimeTier.Api.Repositories
{
    public class AnimeRepo : IAnimeRepository
    {
        public AnimeTierListContext _context;

        public AnimeRepo(AnimeTierListContext context)
        {
            _context = context;
        }

        public ICollection<Anime> GetAnimes()
        {
            return _context.Animes.ToList();
        }

        public Anime GetAnimeById(int id)
        {
            return _context.Animes.First(a => a.Id == id);
        }

        public Anime GetAnimeByName(string title)
        {
            return _context.Animes.First(a => a.AnimeTitle == title);
        }

        public bool AddAnime(Anime anime)
        {
            _context.Add(anime);
            return Save();
        }

        public bool DeleteAnimeById(int id)
        {
            _context.Animes.Remove(GetAnimeById(id));
            return Save();
        }

        public Anime UpdateAnime(Anime anime)
        {
            _context.Animes.Update(anime);
            _context.SaveChanges();
            return anime;
        }

        public bool Save()
        {
            var isChanged = _context.SaveChanges();
            return isChanged > 0 ? true  : false;
        }

        public bool DoesAnimeExist(int id)
        {
            return _context.Animes.Any(a => a.Id == id);
        }
    }
}
