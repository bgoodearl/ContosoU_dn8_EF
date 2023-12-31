﻿using CU.Application.Data.Common.Interfaces;
using CU.Infrastructure.Interfaces;

namespace CU.Infrastructure.Persistence
{
    public class SchoolDbContextFactory : ISchoolDbContextFactory
    {
        protected string NameOrConnectionString { get; }

        public SchoolDbContextFactory(string nameOrConnectionString)
        {
            NameOrConnectionString = nameOrConnectionString ?? throw new ArgumentNullException(nameof(nameOrConnectionString));
        }

        public ISchoolDbContext GetSchoolDbContext()
        {
            return new SchoolDbContext(NameOrConnectionString);
        }
    }
}
