using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Dto;

namespace WebApi.Services
{
    public class DBHelper: DbContext
    {
        /// <summary>
        /// 用户信息
        /// </summary>
        public DbSet<Users> Users { get; set; }

        /// <summary>
        /// 读取SqlServer地址
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfigHelper.SqlServerConfig);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
