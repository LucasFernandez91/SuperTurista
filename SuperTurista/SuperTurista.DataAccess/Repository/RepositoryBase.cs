using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using SuperTurista.Core.Helpers;
using SuperTurista.Core.Interfaces;
using System.Linq.Expressions;
using System.Text;
using System.Collections.ObjectModel;

namespace SuperTurista.DataAccess.Repository
{
    public interface IRepositoryBase<T> where T : class, IEntityBase
    {
        Task SaveChanges();
        IQueryable<T> ConstructQuery<TOrder>(
            Expression<Func<T, bool>> filterExp = null,
            Expression<Func<T, object>> orderExp = null,
            bool descendingOrder = false,
            int? page = null,
            int? take = null,
            params Expression<Func<T, object>>[] includes);
        Task<bool> Exists(long id);
        Task<bool> Exists(Expression<Func<T, bool>> identityFilter = null);
        Task<int> GetTotalResultsQueryAsync(Expression<Func<T, bool>> filter);
        Task<IEnumerable<T>> ExecuteOrderedQueryAsync<TResult>(
            Expression<Func<T, bool>> filter = null,
            Expression<Func<T, object>> orderBy = null,
            bool descendingOrder = false,
            int? page = null,
            int? take = null,
            params Expression<Func<T, object>>[] includes);
        Task<IEnumerable<T>> ExecuteQueryAsync(
            Expression<Func<T, bool>> filter = null,
            params Expression<Func<T, object>>[] includes);
        Task<IEnumerable<TResult>> ExecuteOrderedSelectableQueryAsync<TResult>(
            Expression<Func<T, TResult>> select,
            Expression<Func<T, bool>> filter = null,
            Expression<Func<T, object>> orderBy = null,
            bool descendingOrder = false,
            int? page = null,
            int? take = null,
            params Expression<Func<T, object>>[] includes);
        Task<IEnumerable<TResult>> ExecuteSelectableQueryAsync<TResult>(
            Expression<Func<T, TResult>> select,
            Expression<Func<T, bool>> filter = null,
            params Expression<Func<T, object>>[] includes);
        Task<IQueryable<T>> CreateQueryable(
            Expression<Func<T, bool>> filter = null,
            params Expression<Func<T, object>>[] includes);
    }
    public class RepositoryBase<T> where T : class, IEntityBase
    {
        private readonly JwtHelper _jwtHelper;
        private IQueryable<T> _querySet;
        protected readonly DbSet<T> _dbSet;
        protected readonly ChangeTracker _changeTracker;
        protected readonly DbContext _dbContext;
        public RepositoryBase(
            DbContext context,
            JwtHelper jwtHelper)
        {
            _jwtHelper = jwtHelper;
            _dbContext = context;
            _querySet = _dbContext.Set<T>();
            context.ChangeTracker.LazyLoadingEnabled = false;
            context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

            _dbSet = context.Set<T>();
            _changeTracker = context.ChangeTracker;
            _changeTracker.LazyLoadingEnabled = false;
            _changeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        protected virtual EntityEntry<T> AddBase(T entity)
        {
            var entry = _dbSet.Attach(entity);
            entry.State = EntityState.Added;

            var loggedUser = _jwtHelper.GetTokenInfo();

            if (entity is IEntityBase)
            {
                if (loggedUser != null)
                {
                    ((IEntityBase)entity).CreationUser = loggedUser?.UserName;
                    ((IEntityBase)entity).ModifiedUser = loggedUser?.UserName;
                }
                else
                {
                    ((IEntityBase)entity).CreationUser = "admin";
                    ((IEntityBase)entity).ModifiedUser = "admin";
                }
                ((IEntityBase)entity).CreationDate = DateTime.Now;
                ((IEntityBase)entity).LastModified = DateTime.Now;
            }

            return entry;
        }

        protected virtual EntityEntry<T> UpdateBase(T entity)
        {
            var local = _dbContext.Set<T>()
                        .Local
                        .FirstOrDefault(e => e.Id.Equals(entity.Id));

            if (local != null)
                _dbContext.Entry(local).State = EntityState.Detached;

            _dbContext.Entry(entity).State = EntityState.Modified;

            var entry = _dbContext.Entry(entity);
            var loggedUser = _jwtHelper.GetTokenInfo();

            if (entity is IEntityBase)
            {
                if (loggedUser != null)
                    ((IEntityBase)entity).ModifiedUser = loggedUser?.UserName;
                ((IEntityBase)entity).LastModified = DateTime.Now;
            }

            return entry;
        }

        protected virtual EntityEntry<T> RemoveBase(T entity)
        {
            var entry = _dbSet.Attach(entity);
            if (entry.State == EntityState.Added)
            {
                entry.State = EntityState.Detached;
            }
            else
            {
                entry.State = EntityState.Deleted;
            }
            return entry;
        }

        public async Task SaveChanges()
        {
            await _dbContext.SaveChangesAsync();
        }
        public void DetachAllEntities()
        {
            var changedEntriesCopy = _changeTracker.Entries()
                .Where(e => e.State == EntityState.Added ||
                            e.State == EntityState.Modified ||
                            e.State == EntityState.Deleted)
                .ToList();

            foreach (var entry in changedEntriesCopy)
                entry.State = EntityState.Detached;
        }

        private string HandleMethodCallExpression(ReadOnlyCollection<Expression> args)
        {
            var stack = new Stack<string>();
            do
            {
                if (args[1] is LambdaExpression)
                {
                    var lamb = args[1] as LambdaExpression;
                    if (lamb.Body is MemberExpression)
                    {
                        stack.Push((lamb.Body as MemberExpression).Member.Name);
                    }
                }
                var call = args[0] as MethodCallExpression;
                args = call.Arguments;
            } while (args[0] is MethodCallExpression);

            if (args[0] is MemberExpression)
            {
                if (args[1] is LambdaExpression)
                {
                    var lamb = args[1] as LambdaExpression;
                    if (lamb.Body is MemberExpression)
                    {
                        stack.Push((lamb.Body as MemberExpression).Member.Name);
                    }
                }

                stack.Push((args[0] as MemberExpression).Member.Name);
            }

            var include = new StringBuilder(stack.First());
            foreach (var item in stack.Skip(1))
            {
                include.Append(".");
                include.Append(item);
            }
            return include.ToString();
        }

        private StringBuilder HandleNestedMemberAccessExpression(MemberExpression main, StringBuilder builder)
        {
            var stacko = new Stack<string>();
            while (main.Expression is MemberExpression)
            {
                stacko.Push(main.Member.Name);
                main = main.Expression as MemberExpression;
            }

            builder.Append(main.Member.Name + ".");

            if (stacko.Any())
            {
                builder.Append(stacko.Pop());
                foreach (var item in stacko)
                {
                    builder.Append(".");
                    builder.Append(item);
                }
                builder.Append(".");
            }

            return builder;
        }

        private string HandleMemberAccessExpression(ReadOnlyCollection<Expression> args)
        {
            var builder = new StringBuilder();
            var main = args[0] as MemberExpression;
            builder = HandleNestedMemberAccessExpression(main, builder);

            for (int i = 1; i < args.Count; i++)
            {
                var arg = args[i] as LambdaExpression;
                if (arg.Body is MethodCallExpression)
                {
                    var bodyArgs = (arg.Body as MethodCallExpression).Arguments;
                    var include = bodyArgs[0] is MemberExpression
                        ? HandleMemberAccessExpression(bodyArgs)
                        : HandleMethodCallExpression(bodyArgs);
                    builder.Append(include + (i == args.Count - 1 ? "" : "."));
                    continue;
                }
                var member = arg.Body as MemberExpression;
                builder = HandleNestedMemberAccessExpression(member, builder);

                if (i == args.Count - 1) builder.Remove(builder.Length - 1, 1);
            }

            return builder.ToString();
        }

        private IQueryable<T> DeconstructIncludes(IQueryable<T> query, Expression<Func<T, object>> exp)
        {
            if (exp.Body is MethodCallExpression)
            {
                var args = (exp.Body as MethodCallExpression).Arguments;
                if (args.Count == 1) return query.Include(exp);
                else if (args[0] is MethodCallExpression)
                {
                    var include = HandleMethodCallExpression(args);
                    return query.Include(include);
                }
                else
                {
                    var builder = new StringBuilder();
                    var main = args[0] as MemberExpression;
                    builder = HandleNestedMemberAccessExpression(main, builder);

                    for (int i = 1; i < args.Count; i++)
                    {
                        var arg = args[i] as LambdaExpression;
                        if (arg.Body is MethodCallExpression)
                        {
                            var bodyArgs = (arg.Body as MethodCallExpression).Arguments;
                            var include = bodyArgs[0] is MemberExpression
                                ? HandleMemberAccessExpression(bodyArgs)
                                : HandleMethodCallExpression(bodyArgs);
                            builder.Append(include + (i == args.Count - 1 ? "" : "."));
                            continue;
                        }
                        var member = arg.Body as MemberExpression;
                        builder = HandleNestedMemberAccessExpression(member, builder);

                        if (i == args.Count - 1) builder.Remove(builder.Length - 1, 1);
                    }
                    return query.Include(builder.ToString());
                }
            }
            else if (exp.Body is MemberExpression)
            {
                return query.Include(exp);
            }
            else throw new ArgumentException("The include expression could not be parsed as either a lambda expression or a method call expression");
        }

        private IQueryable<T> AggregateIncludes(IQueryable<T> queryConstruct, Expression<Func<T, object>>[] includes) => includes.Aggregate(queryConstruct, (query, include) => DeconstructIncludes(query, include));

        public IQueryable<T> ConstructQuery<TOrder>(
            Expression<Func<T, bool>> filterExp = null,
            Expression<Func<T, object>> orderExp = null,
            bool descendingOrder = false,
            int? page = null,
            int? take = null,
            params Expression<Func<T, object>>[] includes)
        {
            var query = _querySet;
            query = filterExp != null ? query.Where(filterExp) : query;

            if (includes != null && includes.Any())
            {
                query = AggregateIncludes(query, includes);
            }

            if (orderExp != null)
            {
                query = descendingOrder ? query.OrderByDescending(orderExp) : query.OrderBy(orderExp);
            }

            return query;
        }

        public async Task<bool> Exists(long id)
        {
            var query = _querySet;
            return await query.AnyAsync(f => f.Id.Equals(id));
        }

        public async Task<bool> Exists(Expression<Func<T, bool>> identityFilter)
        {
            if (identityFilter == null) throw new ArgumentNullException("Por favor especifique el filtro a aplicar");

            var query = _querySet;
            return await query.AnyAsync(identityFilter);
        }

        public async Task<int> GetTotalResultsQueryAsync(Expression<Func<T, bool>> filter = null)
        {
            var query = ConstructQuery<long>(filter);
            return await query?.CountAsync();
        }

        public async Task<IEnumerable<T>> ExecuteOrderedQueryAsync<TResult>(
            Expression<Func<T, bool>> filter = null,
            Expression<Func<T, object>> orderBy = null,
            bool descendingOrder = false,
            int? page = null,
            int? take = null,
            params Expression<Func<T, object>>[] includes)
        {
            var query = ConstructQuery<T>(filter, orderBy, descendingOrder, page, take, includes);
            var result = query?.ToList();
            if (page.HasValue && page.Value >= 0)
                result = result.Skip(page.Value).ToList();

            if (take.HasValue && take.Value > 0)
                result = result.Take(take.Value).ToList();

            return result;
        }

        public async Task<IEnumerable<T>> ExecuteQueryAsync(
            Expression<Func<T, bool>> filter = null,
            params Expression<Func<T, object>>[] includes)
        {
            var query = ConstructQuery<long>(filter, null, false, null, null, includes);
            return query?.ToList();
        }

        public async Task<IEnumerable<TResult>> ExecuteOrderedSelectableQueryAsync<TResult>(
            Expression<Func<T, TResult>> select,
            Expression<Func<T, bool>> filter = null,
            Expression<Func<T, object>> orderBy = null,
            bool descendingOrder = false,
            int? page = null,
            int? take = null,
            params Expression<Func<T, object>>[] includes)
        {
            if (select == null) throw new Exception("Debe especificar los campos a obtener de la DB");

            var query = ConstructQuery<T>(filter, orderBy, descendingOrder, page, take, includes)?.Select(select);
            var result = query?.ToList();
            if (page.HasValue && page.Value >= 0)
                result = result.Skip(page.Value).ToList();

            if (take.HasValue && take.Value > 0)
                result = result.Take(take.Value).ToList();

            return result;
        }

        public async Task<IEnumerable<TResult>> ExecuteSelectableQueryAsync<TResult>(
            Expression<Func<T, TResult>> select,
            Expression<Func<T, bool>> filter = null,
            params Expression<Func<T, object>>[] includes)
        {
            if (select == null) throw new Exception("Debe especificar los campos a obtener de la DB");

            var query = ConstructQuery<long>(filter, null, false, null, null, includes)?.Select(select);
            return query?.ToList();
        }

        public async Task<IQueryable<T>> CreateQueryable(
            Expression<Func<T, bool>> filter = null,
            params Expression<Func<T, object>>[] includes)
        {
            var query = ConstructQuery<long>(filter, null, false, null, null, includes);
            return query;
        }
    }
}
