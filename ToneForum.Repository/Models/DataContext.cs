using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ToneForum.Repository.Models
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> dbContextOptions) : base(dbContextOptions)
        {
            // _dbContextOptions = dbContextOptions;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<CollectionList> CollectionLists { get; set; }
        public DbSet<WantList> WantLists { get; set; }
        public DbSet<Band> Bands { get; set; }
        public DbSet<Release> Releases { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Type> Types { get; set; }
        public DbSet<Format> Formats { get; set; }
        //public DbSet<CollectionListReleases> CollectionListReleases { get; set; }
        //public DbSet<WantListRelease> WantListReleases { get; set; }
        //public DbSet<ReleaseGenre> ReleaseGenres { get; set; }
        //public DbSet<ReleaseFormatJoin> ReleaseFormatsJoin { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //1:1 Users and CollectionLists
            //modelBuilder.Entity<Users>()
            //    .HasOne(u => u.CollectionList_Id)
            //    .WithOne(c => c.User)
            //    .HasForeignKey<CollectionLists>(c => c.User_Id);
            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.User_Id).HasColumnName("User_Id");
            });

            // M:M CollectionLists and Releases
            //modelBuilder.Entity<CollectionListReleases>()
            //    .HasKey(clr => new { clr.CollectionList_Id, clr.Release_Id });

            //modelBuilder.Entity<CollectionListReleases>()
            //    .HasOne(clr => clr.CollectionList)
            //    .WithMany(cl => cl.CollectionListReleases)
            //    .HasForeignKey(clr => clr.CollectionList_Id);

            //modelBuilder.Entity<CollectionListReleases>()
            //    .HasOne(clr => clr.Release)
            //    .WithMany(r => r.CollectionListReleases)
            //    .HasForeignKey(clr => clr.Release_Id);

            // 1:1 Users and WantLists
            //modelBuilder.Entity<Users>()
            //    .HasOne(w => w.WantList_Id)
            //    .WithOne(c => c.User)
            //    .HasForeignKey<WantLists>(c => c.User_Id);

            // M:M WantLists and Releases
            //modelBuilder.Entity<WantListRelease>()
            //    .HasKey(wlr => new { wlr.WantList_Id, wlr.Release_Id });

            //modelBuilder.Entity<WantListRelease>()
            //    .HasOne(wlr => wlr.WantList)
            //    .WithMany(wl => wl.WantListReleases)
            //    .HasForeignKey(wlr => wlr.WantList_Id);

            //modelBuilder.Entity<WantListRelease>()
            //    .HasOne(wlr => wlr.Release)
            //    .WithMany(r => r.WantListReleases)
            //    .HasForeignKey(wlr => wlr.Release_Id);

            //// M:M Releases and Genres
            //modelBuilder.Entity<ReleaseGenre>()
            //    .HasKey(rg => new { rg.Release_Id, rg.Genre_Id });

            //modelBuilder.Entity<ReleaseGenre>()
            //    .HasOne(rg => rg.Release)
            //    .WithMany(r => r.ReleaseGenres)
            //    .HasForeignKey(rg => rg.Release_Id);

            //modelBuilder.Entity<ReleaseGenre>()
            //    .HasOne(rg => rg.Genre)
            //    .WithMany(g => g.ReleaseGenres)
            //    .HasForeignKey(rg => rg.Genre_Id);

            // M:M Releases and ReleaseFormats
            //modelBuilder.Entity<ReleaseFormatJoin>()
            //    .HasKey(rf => new { rf.Release_Id, rf.Format_Id });

            //modelBuilder.Entity<ReleaseFormatJoin>()
            //    .HasOne(rf => rf.Release)
            //    .WithMany(r => r.ReleaseFormatsJoin)
            //    .HasForeignKey(rf => rf.Release_Id);

            //modelBuilder.Entity<ReleaseFormatJoin>()
            //    .HasOne(rf => rf.ReleaseFormats)
            //    .WithMany(f => f.ReleaseFormat)
            //    .HasForeignKey(rf => rf.Format_Id);

            // 1:M Releases and ReleaseTypes
            //modelBuilder.Entity<Release>()
            //    .HasOne(r => r.Type)
            //    .WithMany(rt => rt.Releases)
            //    .HasForeignKey(r => r.Type_Id);


        }

    }

}
