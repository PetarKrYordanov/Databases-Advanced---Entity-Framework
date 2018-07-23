namespace P03_FootballBetting.Data
{
    using Microsoft.EntityFrameworkCore;
    using P03_FootballBetting.Data.Models;
    public class FootballBettingContext : DbContext
    {
        public FootballBettingContext()
        {

        }
        public FootballBettingContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Team> Teams { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Town> Towns { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<PlayerStatistic> PlayerStatistics { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Bet> Bets { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            base.OnConfiguring(builder);
            if (!builder.IsConfigured)
            {
                builder.UseSqlServer(Configuration.connectionString);
            }
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.HasMany(e => e.Bets)
                    .WithOne(d => d.User)
                    .HasForeignKey(d => d.UserId);
            });

            builder.Entity<Bet>(entity =>
            {
                entity.HasKey(e => e.BetId);
            });

            builder.Entity<Game>(entity =>
            {
                entity.HasKey(e => e.GameId);

                entity.HasMany(e => e.Bets)
                    .WithOne(d => d.Game)
                    .HasForeignKey(d => d.GameId);

                entity.HasMany(e => e.PlayerStatistics)
                        .WithOne(d => d.Game)
                        .HasForeignKey(d => d.GameId);
            });

            builder.Entity<PlayerStatistic>(entity =>
            {
                entity.HasKey(e => new { e.PlayerId, e.GameId });
            });

            builder.Entity<Team>(entity =>
            {
                entity.HasKey(e => e.TeamId);

                entity.HasMany(e => e.HomeGames)
                    .WithOne(d => d.HomeTeam)
                    .HasForeignKey(d => d.HomeTeamId);

                entity.HasMany(e => e.AwayGames)
                    .WithOne(d => d.AwayTeam)
                    .HasForeignKey(d => d.AwayTeamId)
                     .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasMany(e => e.Players)
                    .WithOne(d => d.Team)
                    .HasForeignKey(d => d.TeamId)
                     .OnDelete(DeleteBehavior.ClientSetNull);

                entity.Property(e => e.Initials).HasColumnType("Char(3)");


            });

            builder.Entity<Player>(entity =>
            {
                entity.HasKey(e => e.PlayerId);

                entity.HasMany(e => e.PlayerStatistics)
                    .WithOne(d => d.Player)
                    .HasForeignKey(d => d.PlayerId);
            });

            builder.Entity<Color>(entity =>
            {
                entity.HasKey(e => e.ColorId);

                entity.HasMany(e => e.PrimaryKitTeams)
                    .WithOne(d => d.PrimaryKitColor)
                    .HasForeignKey(d => d.PrimaryKitColorId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasMany(e => e.SecondaryKitTeams)
                    .WithOne(d => d.SecondaryKitColor)
                    .HasForeignKey(d => d.SecondaryKitColorId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

            });

            builder.Entity<Position>(entity =>
            {
                entity.HasKey(e => e.PositionId);

                entity.HasMany(d => d.Players)
                    .WithOne(e => e.Position)
                    .HasForeignKey(e => e.PositionId);
            });

            builder.Entity<Town>(entity =>
            {
                entity.HasKey(e => e.TownId);

                entity.HasMany(e => e.Teams)
                    .WithOne(d => d.Town)
                    .HasForeignKey(d => d.TownId);
            });

            builder.Entity<Country>(entity =>
            {
                entity.HasKey(e => e.CountryId);

                entity.HasMany(e => e.Towns)
                    .WithOne(d => d.Country)
                    .HasForeignKey(d => d.CountryId);
            });
        }
    }
}
