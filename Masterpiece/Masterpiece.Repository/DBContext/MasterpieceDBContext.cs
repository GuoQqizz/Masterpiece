﻿using Masterpiece.Domain.Entity;
using System.Data.Entity;

namespace Masterpiece.Repository.DBContext
{
    public class MasterpieceDBContext : DbContext
    {
        public DbSet<Product> Users { get; set; }

        public MasterpieceDBContext(): base("AbhsCrmToCDBContext")
        {
            Database.SetInitializer<MasterpieceDBContext>(null);
            this.Configuration.AutoDetectChangesEnabled = false;
            this.Configuration.ValidateOnSaveEnabled = false;
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //string assembleFileName = Assembly.GetExecutingAssembly().CodeBase.Replace("AbhsCrmToC.Data.DLL", "AbhsCrmToC.Mapping.DLL").Replace("file:///", "");
            //Assembly asm = Assembly.LoadFile(assembleFileName);

            //var typesToRegister = asm.GetTypes()
            //.Where(type => !String.IsNullOrEmpty(type.Namespace))
            //.Where(type => type.BaseType != null
            //&& type.BaseType.IsGenericType
            //&& type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));

            //foreach (var type in typesToRegister)
            //{
            //    dynamic configurationInstance = Activator.CreateInstance(type);
            //    modelBuilder.Configurations.Add(configurationInstance);
            //}
            //base.OnModelCreating(modelBuilder);
        }
    }
}