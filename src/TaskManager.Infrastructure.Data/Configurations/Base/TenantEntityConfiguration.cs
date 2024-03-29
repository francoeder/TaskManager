﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManager.Domain.Abstractions.Entities;
using TaskManager.Infrastructure.Http.Internal;

namespace TaskManager.Infrastructure.Data.Configurations.Base
{
    public abstract class TenantEntityConfiguration<TEntity> : EntityConfiguration<TEntity>
        where TEntity : class, ITenantEntity
    {
        private readonly HttpContextProvider _httpContextProvider;

        protected TenantEntityConfiguration(
            HttpContextProvider httpContextProvider)
        {
            _httpContextProvider = httpContextProvider;
        }

        public override void Configure(EntityTypeBuilder<TEntity> builder)
        {
            base.Configure(builder);

            builder.HasIndex(x => x.TenantId);

            builder.HasQueryFilter(t => t.TenantId == _httpContextProvider.GetTenantId());
        }
    }
}
