using NudgeMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace NudgeMVC.Data {
    public class NudgeContext : DbContext {
        public NudgeContext(DbContextOptions<NudgeContext> options) : base(options) {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Note> Notes { get; set; }
    }
}