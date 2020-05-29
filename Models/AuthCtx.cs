using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace authf.Models
{
    public class AuthContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=./Databases/auth.db");
    }

    public class Account
    {
        public int AccountId { get; set; }
        public string Email { get; set; }
        public string Passhash { get; set; }
        public string JSON { get; set; }
        public ushort Guard { get; set; }
    }

    public enum Guard {
        UnApproved,
        LockedOut,
        Blocked,
        Mod,
        Assistant,
        Creator,
        Admin
    }
    
    public class Blog
    {
        public int BlogId { get; set; }
        public string Url { get; set; }

        public List<Post> Posts { get; } = new List<Post>();
    }

    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}