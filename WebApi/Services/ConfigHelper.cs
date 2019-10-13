using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Services
{
    public class ConfigHelper
    {
        public static IConfiguration Configuration { get; set; }
        private static string _SqlServerConfig = "";

        static ConfigHelper()
        {
            //ReloadOnChange = true 当appsettings.json被修改时重新加载            
            Configuration = new ConfigurationBuilder()
            .Add(new JsonConfigurationSource { Path = "appsettings.json", ReloadOnChange = true })
            .Build();
        }

      
        /// <summary>
        /// sqlserver连接地址
        /// </summary>
        public static string SqlServerConfig
        {
            get
            {
               // _SqlServerConfig = "Data Source=.;Initial Catalog=AdminCore;Persist Security Info=True;User ID=sa;Password=8023";
                if (string.IsNullOrEmpty(_SqlServerConfig))
                {
                    _SqlServerConfig = Configuration.GetConnectionString("SqlServerConnection");
                }

                return _SqlServerConfig;
            }
        }
    }
}
