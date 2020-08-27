using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using NudgeMVC.Models;

namespace NudgeMVC.Data {
    public class NudgeContext : DbContext {
        
        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlite("Filename=Data/NudgeDB.db");
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Note> Notes { get; set; }
    }
}