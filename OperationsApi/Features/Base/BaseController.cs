using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using OperationsApi.Infrastructure.Models;
using OperationsApi.Infrastructure.Extensions;

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
        public async Task<PaginatedResult<TModel>> GetAllAsync([FromQuery] QueryParameters parameters = null)
        {
            var entities = (parameters.IsEmpty()
                ? service.GetAllQueryable() 
                : service.GetAllQueryable().Skip((parameters.PageNumber - 1) * parameters.PageSize).Take(parameters.PageSize))
                .ToList();
            var mappedResult = await MapEntitiesToModelsAsync(entities);
            var result = new PaginatedResult<TModel>
            {
                Items = mappedResult,
                TotalCount = mappedResult.Count()
            };
            return result;
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
