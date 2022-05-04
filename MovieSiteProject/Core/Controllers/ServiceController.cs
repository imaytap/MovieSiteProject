using Microsoft.AspNetCore.Mvc;
using MovieSiteProject.Core.Entities.Abstract;
using MovieSiteProject.Core.Services;

namespace MovieSiteProject.Core.Controllers
{
    public class ServiceController<TEntity, TId> : ArtController, IServiceController<TEntity, TId>
           where TEntity : class, IEntity, new()
    {
        private readonly IServiceRepository<TEntity, TId> _serviceRepository;

        public ServiceController(IServiceRepository<TEntity, TId> serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        [HttpPost("[action]")]
        public virtual async Task<IActionResult> Add(TEntity entity)
        {
            var result = _serviceRepository.Add(entity);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPost("[action]")]
        public virtual async Task<IActionResult> Delete(TEntity entity)
        {
            var result = _serviceRepository.Delete(entity);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPost("[action]")]
        public virtual async Task<IActionResult> Update(TEntity entity)
        {
            var result = _serviceRepository.Update(entity);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("[action]")]
        public virtual async Task<IActionResult> GetById(TId id)
        {
            var result = _serviceRepository.GetById(id);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("[action]")]
        public virtual async Task<IActionResult> GetAll()
        {
            var result = _serviceRepository.GetAll();
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }
    }
    public class ServiceController<TEntity, TDeleteRequest, TId> : ArtController, IServiceController<TEntity, TDeleteRequest, TId>
        where TEntity : class, IEntity, new()
        where TDeleteRequest : class, IDeleteRequest<TId>, new()
    {
        private readonly IServiceRepository<TEntity, TDeleteRequest, TId> _serviceRepository;

        public ServiceController(IServiceRepository<TEntity, TDeleteRequest, TId> serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        [HttpPost("[action]")]
        public virtual async Task<IActionResult> Add(TEntity entity)
        {
            var result = _serviceRepository.Add(entity);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPost("[action]")]
        public virtual async Task<IActionResult> Delete(TDeleteRequest entity)
        {
            var result = _serviceRepository.Delete(entity);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPost("[action]")]
        public virtual async Task<IActionResult> Update(TEntity entity)
        {
            var result = _serviceRepository.Update(entity);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("[action]")]
        public virtual async Task<IActionResult> GetById(TId id)
        {
            var result = _serviceRepository.GetById(id);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("[action]")]
        public virtual async Task<IActionResult> GetAll()
        {
            var result = _serviceRepository.GetAll();
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }
    }
    public class ServiceController<TEntity, TAddRequest, TDeleteRequest, TId> : ArtController, IServiceController<TEntity, TAddRequest, TDeleteRequest, TId>
        where TEntity : class, IEntity, new()
        where TAddRequest : class, IRequest, new()
        where TDeleteRequest : class, IDeleteRequest<TId>, new()
    {
        private readonly IServiceRepository<TEntity, TAddRequest, TDeleteRequest, TId> _serviceRepository;

        public ServiceController(IServiceRepository<TEntity, TAddRequest, TDeleteRequest, TId> serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        [HttpPost("[action]")]
        public virtual async Task<IActionResult> Add(TAddRequest entity)
        {
            var result = _serviceRepository.Add(entity);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPost("[action]")]
        public virtual async Task<IActionResult> Delete(TDeleteRequest entity)
        {
            var result = _serviceRepository.Delete(entity);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPost("[action]")]
        public virtual async Task<IActionResult> Update(TEntity entity)
        {
            var result = _serviceRepository.Update(entity);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("[action]")]
        public virtual async Task<IActionResult> GetById(TId id)
        {
            var result = _serviceRepository.GetById(id);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("[action]")]
        public virtual async Task<IActionResult> GetAll()
        {
            var result = _serviceRepository.GetAll();
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }
    }
    public class ServiceController<TEntity, TAddRequest, TUpdateRequest, TDeleteRequest, TId> : ArtController, IServiceController<TEntity, TAddRequest, TUpdateRequest, TDeleteRequest, TId>
        where TEntity : class, IEntity, new()
        where TAddRequest : class, IRequest, new()
        where TUpdateRequest : class, IRequest, new()
        where TDeleteRequest : class, IDeleteRequest<TId>, new()
    {
        private readonly IServiceRepository<TEntity, TAddRequest, TUpdateRequest, TDeleteRequest, TId> _serviceRepository;

        public ServiceController(IServiceRepository<TEntity, TAddRequest, TUpdateRequest, TDeleteRequest, TId> serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        [HttpPost("[action]")]
        public virtual async Task<IActionResult> Add(TAddRequest entity)
        {
            var result = _serviceRepository.Add(entity);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPost("[action]")]
        public virtual async Task<IActionResult> Delete(TDeleteRequest entity)
        {
            var result = _serviceRepository.Delete(entity);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPost("[action]")]
        public virtual async Task<IActionResult> Update(TUpdateRequest entity)
        {
            var result = _serviceRepository.Update(entity);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("[action]")]
        public virtual async Task<IActionResult> GetById(TId id)
        {
            var result = _serviceRepository.GetById(id);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("[action]")]
        public virtual async Task<IActionResult> GetAll()
        {
            var result = _serviceRepository.GetAll();
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
