using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopManagement.DTOs;

namespace ShopManagement.Generics.Controller
{
    public interface IBaseController<in TDto> where TDto : EntityBaseDTO
    {
        public Task<IActionResult> Get();

        public Task<IActionResult> Get(int id);

        public Task<IActionResult> Create(TDto entityDto);

        public Task<IActionResult> Update(TDto entityDto);

        public Task<IActionResult> Delete(int id);
    }
}