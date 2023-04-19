using Microsoft.AspNetCore.Mvc;
using OficinaMeurer.Domain.Interfaces.Aplication;
using OficinaMeurer.Domain.ViewModel;

namespace OficinaMeurer.API.Controllers
{
    [Route("api/cliente")]
    [ApiController]
    public class ClienteController: ControllerBase
    {
        private readonly IClienteApp _clienteApp;

        public ClienteController(IClienteApp clienteApp)
        {
            _clienteApp = clienteApp;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var clientes = await _clienteApp.GetAll();

                return Ok(clientes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet,Route("{id}")]
        public async Task<IActionResult> Get([FromRoute]long id)
        {

            try
            {
                var cliente = await _clienteApp.Get(id);

                if (cliente == null)
                    return NotFound("Cliente não encontrado");

                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Salvar([FromBody]ClienteViewModel cliente)
        {
            try
            {
                await _clienteApp.Salvar(cliente);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}
