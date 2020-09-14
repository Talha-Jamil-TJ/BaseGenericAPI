using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopManagement.Generics.Repository;

namespace ShopManagement.Generics.Controller
{
    [Authorize]
    public class BaseController<T, TDto> : ControllerBase, IBaseController<TDto>
        where T : EntityBase
        where TDto : EntityBaseDTO
    {
        private readonly IMapper _mapper;
        private readonly IBaseRepository<T> _repo;
        private static string EntityName => typeof(T).Name;

        public BaseController(IBaseRepository<T> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public virtual async Task<IActionResult> Get()
        {
            var entityList = await _repo.ToListAsync();

            var entityDtoList = _mapper.Map<IList<TDto>>(entityList);

            return Ok(entityDtoList);
        }

        [HttpGet("{id}")]
        public virtual async Task<IActionResult> Get(int id)
        {
            var entity = await _repo.GetAsync(x => x.Id == id);

            var entityDto = _mapper.Map<TDto>(entity);

            return Ok(entityDto);
        }

        [HttpPost]
        public virtual async Task<IActionResult> Create(TDto entityDto)
        {
            var entity = _mapper.Map<T>(entityDto);

            await _repo.Add(entity);

            if (await _repo.SaveAsync())
                return CreatedAtRoute("", new {id = entity.Id}, entity);

            return BadRequest($"{EntityName} Creation Unsuccessful");
        }

        [HttpPut]
        public virtual async Task<IActionResult> Update(TDto entityDto)
        {
            var entity = _mapper.Map<T>(entityDto);

            var thisEntity = await _repo.GetAsync(x => x.Id == entity.Id);

            if (thisEntity != null && await _repo.SaveAsync()) return NoContent();

            return NotFound($"{EntityName} Not Found");
        }

        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> Delete(int id)
        {
            var thisEntity = await _repo.GetAsync(x => x.Id == id);

            if (thisEntity == null) return NotFound($"{EntityName} Not Found");

            _repo.Delete(thisEntity);

            if (await _repo.SaveAsync()) return NoContent();

            return BadRequest("Delete unsuccessful");
        }
    }
}