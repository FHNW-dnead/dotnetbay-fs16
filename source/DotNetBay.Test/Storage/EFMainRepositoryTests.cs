﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetBay.Data.EF;
using DotNetBay.Data.EF.Migrations;
using DotNetBay.Interfaces;
using NUnit.Framework;

namespace DotNetBay.Test.Storage
{
    [Category("Database")]
    class EFMainRepositoryTests : MainRepositoryTestBase
    {
        public EFMainRepositoryTests()
        {
            // ROLA - This is a hack to ensure that Entity Framework SQL Provider is copied across to the output folder.
            // As it is installed in the GAC, Copy Local does not work. It is required for probing.
            // Fixed "Provider not loaded" error
            var ensureDLLIsCopied = SqlProviderServices.Instance;

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MainDbContext, Configuration>());
        }

        protected override IRepositoryFactory CreateFactory()
        {
            return new EFMainRepositoryFactory();
        }
    }

    public class EFMainRepositoryFactory : IRepositoryFactory
    {
        private List<EFMainRepository> repos = new List<EFMainRepository>();

        public void Dispose()
        {
            foreach (var repo in this.repos)
            {
                repo.Database.Delete();
            }
        }

        public IMainRepository CreateMainRepository()
        {
            var repo = new EFMainRepository();

            if (!this.repos.Any())
            {
                repo.Database.Delete();
            }

            this.repos.Add(repo);

            return repo;
        }
    }

}
