using Microsoft.EntityFrameworkCore;
using ZONOupdate.EntityClasses;

namespace ZONOupdate.Database
{
    /// <summary>
    /// Класс контекста базы данных.
    /// </summary>
    public partial class DatabaseContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<ProductType> ProductTypes { get; set; }
        public virtual DbSet<Manufacturer> Manufacturers { get; set; }
        public virtual DbSet<EntityClasses.Color> Colors { get; set; }
        public virtual DbSet<Favorite> Favorites { get; set; }
        public virtual DbSet<UserCollection> UserCollections { get; set; }
        public virtual DbSet<RecommendationInCollection> RecommendationInCollections { get; set; }
        public virtual DbSet<Recommendation> Recommendations { get; set; }
        public virtual DbSet<Mark> Marks {  get; set; }
        public virtual DbSet<RecommendationSetting> RecommendationSettings { get; set; }
        public virtual DbSet<LikedProduct> LikedProducts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("Data Source=../../../Database/database.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Recommendation>(entity =>
            {
                entity.ToTable("Recommendations");
                entity.HasKey("RecommendationId");
            });

            modelBuilder.Entity<Favorite>(entity =>
            {
                entity.ToTable("Favorites");
                entity.HasKey("FavoriteID");
            });

            modelBuilder.Entity<UserCollection>(entity =>
            {
                entity.ToTable("UserCollections");
                entity.HasKey("CollectionID");
            });

            modelBuilder.Entity<RecommendationInCollection>(entity =>
            {
                entity.ToTable("RecommendationInCollections");
                entity.HasKey("RecommendationInCollectionsID");
            });

            modelBuilder.Entity<Mark>(entity =>
            {
                entity.ToTable("Marks");
                entity.HasKey("MarkID");
            });
            modelBuilder.Entity<RecommendationSetting>(entity =>
            {
                entity.ToTable("RecommendationSettings");
                entity.HasKey("RecommendationSettingID");
            });
            modelBuilder.Entity<LikedProduct>(entity =>
            {
                entity.ToTable("LikedProducts");
                entity.HasKey("LikedProductID");
            });
        }
    }
}