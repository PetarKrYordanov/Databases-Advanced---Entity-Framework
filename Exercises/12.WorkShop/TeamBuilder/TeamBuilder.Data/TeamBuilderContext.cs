using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using TeamBuilder.Models;
using TeamBuilder.Data.Configuration;

namespace TeamBuilder.Data
{
    public class TeamBuilderContext : DbContext
    {
        public TeamBuilderContext(DbContextOptions options):base(options)
        {

        }
        public TeamBuilderContext()
        {

        }

        public DbSet<Team>  Teams{ get; set; }
        public DbSet<UserTeam> UserTeams { get; set; }
        public DbSet<EventTeam> EventTeams { get; set; }
        public DbSet<Invitation> Invitations { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder.UseLazyLoadingProxies(true);
                builder.UseSqlServer(ConnectionConfiguration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new EventsConfigurationn());
            builder.ApplyConfiguration(new EventTeamsConfiguration());
            builder.ApplyConfiguration(new TeamConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new UserTeamsConfiguration()); 
        }
    }
}
