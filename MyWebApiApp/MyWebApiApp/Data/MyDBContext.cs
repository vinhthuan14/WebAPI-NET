﻿using Microsoft.EntityFrameworkCore;

namespace MyWebApiApp.Data
{
    public class MyDBContext : DbContext
    {
        public MyDBContext(DbContextOptions options): base(options)
        {

        }
        #region DbSet
        public DbSet<HangHoa> HangHoas { get; set; }
        #endregion
    }
}
