using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Linq;
using CitizenFX.Core;
using LegacyCore.Server.Entity;
using MySql.Data.Entity;

namespace LegacyCore.Server.Storage {

    /// <summary>
    /// A MySQL database context
    /// </summary>
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class DB : DbContext {

        /// <summary>
        /// MySQL connection url
        /// </summary>
        public static readonly string CONNECTION_URL = "data source=127.0.0.01;database=legacycore;user id=root;password=password;SslMode=none";

        /// <summary>
        /// All players
        /// </summary>
        public DbSet<LegacyPlayer> Players { get; set; }

        public DB() : base(CONNECTION_URL) {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DB, Configuration>());
        }

    }

    /// <summary>
    /// A database migration configuration
    /// </summary>
    internal sealed class Configuration : DbMigrationsConfiguration<DB> {

        public Configuration() {
            this.TargetDatabase = new DbConnectionInfo(DB.CONNECTION_URL, "MySql.Data.MySqlClient");
            this.AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DB context) {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            Debug.WriteLine("Migrated to latest version at " + DateTime.Now.ToString());
        }
    }
}