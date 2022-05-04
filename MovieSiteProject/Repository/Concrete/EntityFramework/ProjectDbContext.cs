using Microsoft.EntityFrameworkCore;
using MovieSiteProject.Core.Entities.Concrete;
using MovieSiteProject.Entities;

namespace MovieSiteProject.Repository.Concrete.EntityFramework
{
    public class ProjectDbContext : DbContext
    {
        public DbSet<Language> Languages { get; set; }
        public DbSet<TranslateKey> TranslateKeys { get; set; }
        public DbSet<Translate> Translates { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieActor> MovieActors { get; set; }
        public DbSet<MovieCategory> MovieCategories { get; set; }
        public DbSet<MovieTag> MovieTags { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<XUser> XUsers { get; set; }

        public ProjectDbContext(DbContextOptions<ProjectDbContext> options) : base(options)
        {
        }
    }
}
