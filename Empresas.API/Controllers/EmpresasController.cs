using Empresas.API.Models;
using Empresas.Application.Services;
using Empresas.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Empresas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpresasController : ControllerBase
    {
        private readonly EmpresaService _empresaService;

        public EmpresasController(EmpresaService empresaService)
        {
            _empresaService = empresaService;
        }

        [HttpPost]
        public async Task<IActionResult> AddEmpresa([FromBody] EmpresaCreateDTO dto)
        {
            var empresa = new Empresa
            {
                Nome = dto.Nome,
                Porte = dto.Porte
            };

            await _empresaService.AddEmpresaAsync(empresa);
            return Ok(new { resultado = "Empresa criada com sucesso." });
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEmpresa([FromBody] EmpresaUpdateDTO dto)
        {
            var empresa = new Empresa
            {
                Id = dto.Id,
                Nome = dto.Nome,
                Porte = dto.Porte
            };

            await _empresaService.UpdateEmpresaAsync(empresa);
            return Ok(new { resultado = "Empresa atualizada com sucesso." });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpresa([FromRoute] int id)
        {
            var empresa = new Empresa
            {
                Id = id
            };

            await _empresaService.DeleteEmpresaAsync(empresa);
            return Ok(new { resultado = "Empresa excluída com sucesso." });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var empresa = await _empresaService.GetByIdAsync(id);
            if (empresa == null)
            {                
                return NotFound(new { resultado = "Empresa não encontrada." });
            }
            return Ok(empresa);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var empresas = await _empresaService.GetAllAsync();
            return Ok(empresas);
        }
    }
}
