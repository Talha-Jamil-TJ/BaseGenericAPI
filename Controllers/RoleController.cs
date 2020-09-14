using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopManagement.DTOs;
using ShopManagement.Generics.Controller;
using ShopManagement.Generics.Repository;
using ShopManagement.models;

namespace ShopManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : BaseController<Role, RoleDTO>
    {
        private readonly IBaseRepository<Role> _repo;
        private readonly IMapper _mapper;

        public RoleController(IBaseRepository<Role> repo, IMapper mapper) : base(repo, mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        [AllowAnonymous]
        public override async Task<IActionResult> Get()
        {
            var entityList = await _repo.ToListAsync();

            var entityDtoList = _mapper.Map<IList<RoleDTO>>(entityList);

            return Ok(entityDtoList);
        }  
    }
}