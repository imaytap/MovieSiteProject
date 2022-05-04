using MovieSiteProject.Core.Entities.Abstract;
using MovieSiteProject.Core.Utilities.Results;
using IResult = MovieSiteProject.Core.Utilities.Results.IResult;

namespace MovieSiteProject.Core.Services
{
    public interface IServiceRepository<TEntity, TId>
        where TEntity : class, IEntity, new()
    {
        IDataResult<TEntity> Add(TEntity entity);

        IResult Delete(TEntity entity);

        IDataResult<TEntity> Update(TEntity entity);

        IDataResult<List<TEntity>> GetAll();

        IDataResult<TEntity> GetById(TId id);
    }

    public interface IServiceRepository<TEntity, TDeleteRequest, TId>
        where TEntity : class, IEntity, new()
        where TDeleteRequest : class, IDeleteRequest<TId>, new()
    {
        IDataResult<TEntity> Add(TEntity entity);

        IResult Delete(TDeleteRequest entity);

        IDataResult<TEntity> Update(TEntity entity);

        IDataResult<List<TEntity>> GetAll();

        IDataResult<TEntity> GetById(TId id);
    }

    public interface IServiceRepository<TEntity, TAddRequest, TDeleteRequest, TId>
        where TEntity : class, IEntity, new()
        where TAddRequest : class, IRequest, new()
        where TDeleteRequest : class, IDeleteRequest<TId>, new()
    {
        IDataResult<TEntity> Add(TAddRequest entity);

        IResult Delete(TDeleteRequest entity);

        IDataResult<TEntity> Update(TEntity entity);

        IDataResult<List<TEntity>> GetAll();

        IDataResult<TEntity> GetById(TId id);
    }

    public interface IServiceRepository<TEntity, TAddRequest, TUpdateRequest, TDeleteRequest, TId>
        where TEntity : class, IEntity, new()
        where TAddRequest : class, IRequest, new()
        where TUpdateRequest : class, IRequest, new()
        where TDeleteRequest : class, IDeleteRequest<TId>, new()
    {
        IDataResult<TEntity> Add(TAddRequest entity);

        IResult Delete(TDeleteRequest entity);

        IDataResult<TEntity> Update(TUpdateRequest entity);

        IDataResult<List<TEntity>> GetAll();

        IDataResult<TEntity> GetById(TId id);
    }
}
