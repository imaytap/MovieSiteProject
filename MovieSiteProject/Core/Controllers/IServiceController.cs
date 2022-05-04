using Microsoft.AspNetCore.Mvc;
using MovieSiteProject.Core.Entities.Abstract;
using MovieSiteProject.Core.Services;

namespace MovieSiteProject.Core.Controllers
{
    public interface IServiceController<TEntity, TId>
        where TEntity : class, IEntity, new()
    {
        Task<IActionResult> Add(TEntity entity);
        Task<IActionResult> Delete(TEntity entity);
        Task<IActionResult> Update(TEntity entity);
        Task<IActionResult> GetById(TId id);
        Task<IActionResult> GetAll();
    }
    public interface IServiceController<TEntity, TDeleteRequest, TId>
        where TEntity : class, IEntity, new()
        where TDeleteRequest : class, IDeleteRequest<TId>, new()
    {
        Task<IActionResult> Add(TEntity entity);
        Task<IActionResult> Delete(TDeleteRequest entity);
        Task<IActionResult> Update(TEntity entity);
        Task<IActionResult> GetById(TId id);
        Task<IActionResult> GetAll();
    }
    public interface IServiceController<TEntity, TAddRequest, TDeleteRequest, TId>
        where TEntity : class, IEntity, new()
        where TAddRequest : class, IRequest, new()
        where TDeleteRequest : class, IDeleteRequest<TId>, new()
    {
        Task<IActionResult> Add(TAddRequest entity);
        Task<IActionResult> Delete(TDeleteRequest entity);
        Task<IActionResult> Update(TEntity entity);
        Task<IActionResult> GetById(TId id);
        Task<IActionResult> GetAll();
    }
    public interface IServiceController<TEntity, TAddRequest, TUpdateRequest, TDeleteRequest, TId>
        where TEntity : class, IEntity, new()
        where TAddRequest : class, IRequest, new()
        where TUpdateRequest : class, IRequest, new()
        where TDeleteRequest : class, IDeleteRequest<TId>, new()
    {
        Task<IActionResult> Add(TAddRequest entity);
        Task<IActionResult> Delete(TDeleteRequest entity);
        Task<IActionResult> Update(TUpdateRequest entity);
        Task<IActionResult> GetById(TId id);
        Task<IActionResult> GetAll();
    }
}
