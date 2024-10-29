namespace SharedLibrary.Models;

public partial class Anime
{
    public int Id { get; set; }

    public string? AnimeTitle { get; set; }

    public int? SeasonCount { get; set; }

    public virtual ICollection<Season> Seasons { get; set; } = new List<Season>();
}
