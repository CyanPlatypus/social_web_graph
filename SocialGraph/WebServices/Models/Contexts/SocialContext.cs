using System.Data.Entity;

namespace WebServices.Models.Contexts
{
    public class SocialContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Friendship> Friendships { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Hobby> Hobbies { get; set; }

        public SocialContext() : base("SocialContext")
        {
         
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Friendship>()
                .HasRequired(f => f.User)
                .WithMany()
                .HasForeignKey(f => f.FriendId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Friendship>()
                .HasRequired(f=>f.User)
                .WithMany(u => u.Friends)
                .HasForeignKey(a=>a.UserId)
                .WillCascadeOnDelete(false);


            modelBuilder.Entity<User>()
                .HasMany(u => u.Hobbies)
                .WithMany()
                .Map(uh =>
                {
                    uh.MapLeftKey("UserId");
                    uh.MapRightKey("HobbyId");
                    uh.ToTable("UserHobby");
                });

            //modelBuilder.Entity<User>().HasMany(m => m.Friends).WithMany().Map(m =>
            //    {
            //        m.MapLeftKey("UserId");
            //        m.MapRightKey("FriendId");
            //        m.ToTable("Friendship");
            //    }
            //);
        }
    }
}