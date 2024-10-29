using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class Season
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public int? Rating { get; set; }

    public bool? IsEnding { get; set; }

    public int? AnimeId { get; set; }

    public virtual Anime? Anime { get; set; }
}
