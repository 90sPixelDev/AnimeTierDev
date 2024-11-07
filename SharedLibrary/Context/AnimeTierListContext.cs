using Microsoft.EntityFrameworkCore;
using SharedLibrary.Models;

namespace SharedLibrary.Context;

public partial class AnimeTierListContext : DbContext
{
    public AnimeTierListContext()
    {
    }

    public AnimeTierListContext(DbContextOptions<AnimeTierListContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Anime> Animes { get; set; }

    public virtual DbSet<Season> Seasons { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Anime>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Anime__3213E83F44C20DAF");

            entity.ToTable("Anime");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AnimeTitle)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("anime_title");
            entity.Property(e => e.SeasonCount).HasColumnName("season_count");
        });

        modelBuilder.Entity<Season>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__seasons__3213E83FEB623AB8");

            entity.ToTable("seasons");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AnimeId).HasColumnName("animeId");
            entity.Property(e => e.IsEnding).HasColumnName("is_ending");
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("title");

            entity.HasOne(d => d.Anime).WithMany(p => p.Seasons)
                .HasForeignKey(d => d.AnimeId)
                .HasConstraintName("FK_seasonsAnime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
