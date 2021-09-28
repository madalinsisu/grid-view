using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace OperationsApi.Features.Base
{
    [Route("[controller]")]
    [ApiController]
    public abstract class BaseController<TService, TEntity, TModel>: ControllerBase
        where TService : BaseService<TEntity>
        where TEntity : class, new()
        where TModel : class, new()
    {
        protected readonly TService service;
        protected readonly IMapper mapper;

        public BaseController(TService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<TModel>> GetAllAsync()
        {
            var entities = service.GetAllQueryable().ToList();
            return await MapEntitiesToModelsAsync(entities);
        }

        protected virtual Task<IEnumerable<TModel>> MapEntitiesToModelsAsync(IEnumerable<TEntity> entities)
        {
            return Task.FromResult(mapper.Map<IEnumerable<TModel>>(entities));
        }

        protected virtual Task<TModel> MapEntityToModelAsync(TEntity entity)
        {
            return Task.FromResult(mapper.Map<TModel>(entity));
        }

        protected virtual Task<TEntity> MapModelToEntityAsync(TModel model, TEntity entity = null)
        {
            if (entity != null)
            {
                return Task.FromResult(mapper.Map(model, entity));
            }

            return Task.FromResult(mapper.Map<TEntity>(model));
        }
    }
}
