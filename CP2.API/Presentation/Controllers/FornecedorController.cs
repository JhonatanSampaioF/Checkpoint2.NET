using CP2.API.Application.Interfaces;
using CP2.API.Application.Dtos;
using CP2.API.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Swashbuckle.AspNetCore.Annotations;



namespace CP2.API.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedorController : ControllerBase
    {
        private readonly IFornecedorApplicationService _applicationService;

        public FornecedorController(IFornecedorApplicationService applicationService)
        {
            _applicationService = applicationService;
        }


        [HttpGet]
        [SwaggerOperation(Summary = "Lista todos os fornecedores", Description = "Este endpoint retorna uma lista completa de todos os fornecedores cadastrados.")]
        [Produces<IEnumerable<FornecedorEntity>>]
        public IActionResult Get()
        {
            var objModel = _applicationService.ObterTodosFornecedores();

            if (objModel is not null)
                return Ok(objModel);

            return BadRequest("Não foi possivel obter os dados");
        }


        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Busca um fornecedor", Description = "Este endpoint retorna um fornecedor específico pelo id.")]
        [Produces<FornecedorEntity>]
        public IActionResult GetPorId(int id)
        {
            var objModel = _applicationService.ObterFornecedorporId(id);

            if (objModel is not null)
                return Ok(objModel);

            return BadRequest("Não foi possivel obter os dados");
        }


        [HttpPost]
        [SwaggerOperation(Summary = "Salva um novo fornecedor", Description = "Este endpoint cadastra um novo fornecedor.")]
        [Produces<FornecedorEntity>]
        public IActionResult Post([FromBody] FornecedorDto entity)
        {
            try
            {
                var objModel = _applicationService.SalvarDadosFornecedor(entity);

                if (objModel is not null)
                    return Ok(objModel);

                return BadRequest("Não foi possivel salvar os dados");
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Error = ex.Message,
                    status = HttpStatusCode.BadRequest,
                });
            }
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Edita um fornecedor", Description = "Este endpoint edita um fornecedor pelo id.")]
        [Produces<FornecedorEntity>]
        public IActionResult Put(int id, [FromBody] FornecedorDto entity)
        {
            try
            {
                var objModel = _applicationService.EditarDadosFornecedor(id, entity);

                if (objModel is not null)
                    return Ok(objModel);

                return BadRequest("Não foi possivel salvar os dados");
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Error = ex.Message,
                    status = HttpStatusCode.BadRequest,
                });
            }
        }


        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Deleta um fornecedor", Description = "Este endpoint deleta um fornecedor cadastrado pelo id.")]
        [Produces<FornecedorEntity>]
        public IActionResult Delete(int id)
        {
            var objModel = _applicationService.DeletarDadosFornecedor(id);

            if (objModel is not null)
                return Ok(objModel);

            return BadRequest("Não foi possivel deletar os dados");
        }
    }
}
