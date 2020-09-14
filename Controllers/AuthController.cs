using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShopManagement.DTOs;
using ShopManagement.models;
using ShopManagement.Repositories.Interfaces;

namespace ShopManagement.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        private readonly IMapper _mapper;
        private readonly IRoleRepository _roleRepo;

        public AuthController(IAuthRepository repo, IRoleRepository roleRepo, IMapper mapper)
        {
            _repo = repo;
            _roleRepo = roleRepo;
            _mapper = mapper;
        }

        [HttpPost("register", Name = "RegisteredUser")]
        public async Task<IActionResult> Register(UserForRegisterDTO userForRegisterDto)
        {
            userForRegisterDto.UserName = userForRegisterDto.UserName.ToLower();

            if (await _repo.UserExists(userForRegisterDto.UserName))
                return BadRequest("Username already exists");

            var thisRole = await _roleRepo.Get(userForRegisterDto.RoleId);

            if (thisRole == null) return NotFound("Role not found");

            var userToCreate = new User {UserName = userForRegisterDto.UserName, RoleId = userForRegisterDto.RoleId};

            var createdUser = await _repo.Register(userToCreate, userForRegisterDto.Password);

            // var userToReturn = _mapper.Map<UserDTO>(createdUser);

            var token = _repo.GetToken(createdUser);

            return CreatedAtRoute("RegisteredUser", new {id = createdUser.Id}, new {token});
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDTO userForLoginDto)
        {
            var userFromRepo = await _repo.Login(userForLoginDto.UserName.ToLower(), userForLoginDto.Password);

            if (userFromRepo == null) return Unauthorized("Login Failed");

            var token = _repo.GetToken(userFromRepo);

            return Ok(new {token});
        }
    }
}