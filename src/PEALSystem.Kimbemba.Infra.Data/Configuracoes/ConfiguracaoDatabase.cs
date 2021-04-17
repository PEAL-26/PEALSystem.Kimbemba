using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace PEALSystem.Kimbemba.Configuracoes
{
    public static class ConfiguracaoDatabase
    {
        public static void SQLServerConfiguration(this DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder == null) throw new ArgumentNullException(nameof(optionsBuilder));

            var configuration = new ConfigurationBuilder()
                                    .SetBasePath(Directory.GetCurrentDirectory())
                                    .AddJsonFile("appsettings.json")
                                    .Build();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("SQLServerConnection"));

        }

        public static void MySQLConfiguration(this DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder == null) throw new ArgumentNullException(nameof(optionsBuilder));

            var configuration = new ConfigurationBuilder()
                                    .SetBasePath(Directory.GetCurrentDirectory())
                                    .AddJsonFile("appsettings.json")
                                    .Build();

            optionsBuilder.UseMySql(configuration.GetConnectionString("MySQLConnection"));

        }
    }
}
