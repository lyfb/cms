﻿using System.Collections.Concurrent;
using Datory;
using SiteServer.Abstractions;
using SiteServer.CMS.Caching;

namespace SiteServer.CMS.Repositories
{
    public partial class ContentRepository
    {
        private static readonly ConcurrentDictionary<string, Repository<Content>> TableNameRepositories = new ConcurrentDictionary<string, Repository<Content>>();

        private Repository<Content> GetRepository(string tableName)
        {
            var key = $"{_db.ConnectionString}:{tableName}";
            if (TableNameRepositories.TryGetValue(key, out var repository))
            {
                return repository;
            }

            repository = new Repository<Content>(_db, tableName, CacheManager.Cache);

            TableNameRepositories[key] = repository;
            return repository;
        }
    }
}