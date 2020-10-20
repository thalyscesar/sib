using Microsoft.AspNetCore.Mvc;
using Sib.Cadastros.Application.Models;
using Sib.Cadastros.Application.Services;
using Sib.Cadastros.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Sib.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpresaController: ControllerBase
    {
        private readonly IEmpresaAppService _empresaAppService;

        public EmpresaController(IEmpresaAppService empresaAppService)
        {
            _empresaAppService = empresaAppService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EmpresaModel model)
        {
            try
            {
                var id = await _empresaAppService.Adicionar(model);
                if (id > 0)
                    return Created(new Uri(Request.Path, UriKind.Relative), new { id });
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }

            return null;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var models = await _empresaAppService.ObterTodos();
            return Ok(models);
        }

        [HttpGet("{cnpj}")]
        public async Task<IActionResult> Get(string cnpj)
        {
            var empresaModel = await _empresaAppService.ObterPeloCnpj(cnpj);
            if (empresaModel == null) return NotFound();
            return Ok(empresaModel);
        }
    }
}
