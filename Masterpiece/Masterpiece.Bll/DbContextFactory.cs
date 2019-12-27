using Masterpiece.Repository.DBContext;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Mapping;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure;

namespace Masterpiece.Bll
{
    public class DbContextFactory : IDisposable
    {
        private DbContextFactory dbContext;
        public DbContextFactory DBContext
        {
            set
            {
                dbContext = value;
            }
            get
            {
                if (dbContext == null)
                {
                    dbContext = new DbContextFactory();
                }
                return dbContext;
            }
        }

        private MasterpieceDBContextPart1 dbContextPart1;
        public MasterpieceDBContextPart1 DBContextPart1
        {
            set
            {
                dbContextPart1 = value;
            }
            get
            {
                if (dbContextPart1 == null)
                {
                    dbContextPart1 = new DbContextFactoryPart1();
                }
                return dbContextPart1;
            }
        }

        public static DbContextFactory CreateDbContext()
        {
            //AbhsChineseDBContext DBContext1 = new AbhsChineseDBContext();
            //var objectContext = ((IObjectContextAdapter)DBContext1).ObjectContext;
            //var mappingCollection = (StorageMappingItemCollection)objectContext.MetadataWorkspace.GetItemCollection(DataSpace.CSSpace);
            //mappingCollection.GenerateViews(new List<EdmSchemaError>());
            return new DbContextFactory();
        }

        public static void Init()
        {
            AbhsCrmToCDBContext DBContext1 = new AbhsCrmToCDBContext();
            var objectContext = ((IObjectContextAdapter)DBContext1).ObjectContext;
            var mappingCollection = (StorageMappingItemCollection)objectContext.MetadataWorkspace.GetItemCollection(DataSpace.CSSpace);
            mappingCollection.GenerateViews(new List<EdmSchemaError>());
        }

        public void Dispose()
        {
            if (dbContext != null)
            {
                dbContext.Dispose();
            }
        }
    }
}