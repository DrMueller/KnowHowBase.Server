using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Mmu.Khb.Domain.Infrastructure.ModelAbstractions;
using Mmu.Khb.Domain.Infrastructure.Specifications;
using Mmu.Khb.Domain.Services.Common.Repositories;
using Mmu.Khb.Domain.Services.Data.Common.Repositories.Handlers;
using MongoDB.Driver;

namespace Mmu.Khb.Domain.Services.Data.Common.Repositories
{
    public class Repository<T> : IRepository<T>
        where T : AggregateRoot
    {
        private readonly IMongoDbFilterDefinitionFactory<T> _filterFactory;
        private readonly IMongoDbAccess _mongoDbAccess;

        public Repository(IMongoDbAccess mongoDbAccess, IMongoDbFilterDefinitionFactory<T> filterFactory)
        {
            _mongoDbAccess = mongoDbAccess;
            _filterFactory = filterFactory;
        }

        public Task DeleteAsync(long id)
        {
            var collection = _mongoDbAccess.GetDatabaseCollection<T>();
            return collection.DeleteOneAsync(x => x.Id == id);
        }

        public Task<IReadOnlyCollection<T>> LoadAllAsync()
        {
            var result = LoadByExpressionAsync(x => true);
            return result;
        }

        public async Task<IReadOnlyCollection<T>> LoadAsync(ISpecification<T> spec)
        {
            var collection = _mongoDbAccess.GetDatabaseCollection<T>();

            var predicate = spec.ToExpression();
            var filter = _filterFactory.CreateFilterDefinition(predicate);
            var result = await collection.Find(filter).ToListAsync();
            return result;
        }

        public async Task<T> LoadByIdAsync(long id)
        {
            var entries = await LoadByExpressionAsync(x => x.Id == id);
            var result = entries.SingleOrDefault();
            return result;
        }

        public async Task<T> SaveAsync(T aggregateRoot)
        {
            var collection = _mongoDbAccess.GetDatabaseCollection<T>();
            var exists = await LoadByIdAsync(aggregateRoot.Id) != null;

            if (aggregateRoot.Id == 0 || !exists)
            {
                await collection.InsertOneAsync(aggregateRoot);
                return aggregateRoot;
            }


            var filter = _filterFactory.CreateFilterDefinition(x => x.Id == aggregateRoot.Id);
            var updateOptions = new FindOneAndReplaceOptions<T> { IsUpsert = false, ReturnDocument = ReturnDocument.After };
            var result = await collection.FindOneAndReplaceAsync(filter, aggregateRoot, updateOptions);
            return result;
        }

        private async Task<IReadOnlyCollection<T>> LoadByExpressionAsync(Expression<Func<T, bool>> predicate)
        {
            var collection = _mongoDbAccess.GetDatabaseCollection<T>();

            var filter = _filterFactory.CreateFilterDefinition(predicate);
            var result = await collection.Find(filter).ToListAsync();
            return result;
        }
    }
}