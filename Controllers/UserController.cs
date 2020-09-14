using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShopManagement.DTOs;
using ShopManagement.Generics.Controller;
using ShopManagement.Generics.Repository;
using ShopManagement.models;

namespace ShopManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : BaseController<User, UserDTO>
    {
        public UserController(IBaseRepository<User> repo, IMapper mapper) : base(repo, mapper) { }
    }
}