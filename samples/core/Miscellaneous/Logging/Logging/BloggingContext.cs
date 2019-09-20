﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EFLogging
{
    public class BloggingContext : DbContext
    {
        #region DefineLoggerFactory
        public static readonly ILoggerFactory MyLoggerFactory
            = LoggerFactory.Create(builder => { builder.AddConsole(); });
        #endregion

        public DbSet<Blog> Blogs { get; set; }

        #region RegisterLoggerFactory
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
                .UseLoggerFactory(MyLoggerFactory) // Warning: Do not create a new ILoggerFactory instance each time
                .UseSqlServer(
                    @"Server=(localdb)\mssqllocaldb;Database=EFLogging;Trusted_Connection=True;ConnectRetryCount=0");
        #endregion
    }
}
