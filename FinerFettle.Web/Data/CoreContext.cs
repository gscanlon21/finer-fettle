﻿using FinerFettle.Web.Models.Newsletter;
using FinerFettle.Web.Models.User;
using FinerFettle.Web.Models.Exercise;
using Microsoft.EntityFrameworkCore;
using FinerFettle.Web.Models.Footnotes;

namespace FinerFettle.Web.Data
{
    public class CoreContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Exercise> Exercises { get; set; } = null!;
        public DbSet<Newsletter> Newsletters { get; set; } = null!;
        public DbSet<Footnote> Footnotes { get; set; } = null!;

        public CoreContext() : base() { }

        public CoreContext(DbContextOptions<CoreContext> context) : base(context) { }
    }
}
