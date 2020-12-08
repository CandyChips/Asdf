using System;
using System.Linq;
using System.Threading.Channels;
using System.Threading.Tasks;
using Asdf.Social.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Asdf.Social.Services.Contexts
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Chanel> Channels { get; set; }
        public DbSet<ChanelMessage> ChanelMessages { get; set; }
        public DbSet<ChanelMessageItem> ChanelMessageItems { get; set; }
        public DbSet<ChanelMessageRate> ChanelMessageRates { get; set; }
        public DbSet<ChannelSubscribtion> ChannelSubscribtions { get; set; }
        public DbSet<FileOfChanelMessage> FileOfChanelMessages { get; set; }
        public DbSet<FileOfPost> FileOfPosts { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupPost> GroupPosts { get; set; }
        public DbSet<GroupPostItem> GroupPostItems { get; set; }
        public DbSet<GroupPostRate> GroupPostRates { get; set; }
        public DbSet<GroupSubscribtion> GroupSubscribtions { get; set; }
        public DbSet<TextOfMessage> TextOfMessage { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
            Update();
        }

        public void Update()
        {
            Channels.Load();
            ChanelMessages.Load();
            ChanelMessageItems.Load();
            ChanelMessageRates.Load();
            ChannelSubscribtions.Load();
            FileOfChanelMessages.Load();
            FileOfPosts.Load();
            Groups.Load();
            GroupPosts.Load();
            GroupPostItems.Load();
            GroupPostRates.Load();
            GroupSubscribtions.Load();
            TextOfMessage.Load();
        }
    }
}