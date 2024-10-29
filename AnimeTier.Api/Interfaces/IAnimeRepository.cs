
using SharedLibrary.Models;
using System.Numerics;

namespace AnimeTier.Api.Interfaces
{
    public interface IAnimeRepository
    {
        ICollection<Anime> GetAnimes();

        Anime GetAnimeById(int id);

        Anime GetAnimeByName(string name);

        bool  AddAnime(Anime anime);

        bool DeleteAnimeById(int id);

        Anime UpdateAnime(Anime anime);

    }
}
