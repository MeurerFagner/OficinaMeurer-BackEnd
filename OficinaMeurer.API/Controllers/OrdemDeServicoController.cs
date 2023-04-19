using Microsoft.AspNetCore.Mvc;
using OficinaMeurer.Domain.Interfaces.Aplication;
using OficinaMeurer.Domain.ViewModel;

namespace OficinaMeurer.API.Controllers
{
    [Route("api/ordem-de-servico")]
    public class OrdemDeServicoController : BaseController
    {
        private readonly IOrdemDeServicoApp _ordemDeServicoApp;

        public OrdemDeServicoController(IOrdemDeServicoApp ordemDeServicoApp)
        {
            _ordemDeServicoApp = ordemDeServicoApp;
        }

        [HttpGet,Route("{id}")]
        public async Task<IActionResult> Get([FromRoute] long id)
        {
            try
            {
                var os = await _ordemDeServicoApp.Get(id);

                if (os == null)
                    return NotFound("O.S. não Encontrada");

                return Ok(os);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet,Route("finalizadas")]
        public async Task<IActionResult> ObterOSFinalizadas()
        {
            try
            {
                var os = await _ordemDeServicoApp.ObterOSFinalizadas();

                return Ok(os);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
        [HttpGet,Route("iniciadas")]
        public async Task<IActionResult> ObterOSIniciadas()
        {

            try
            {
                var os = await _ordemDeServicoApp.ObterOSIniciadas();

                return Ok(os);

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
        [HttpGet,Route("nao-iniciadas")]
        public async Task<IActionResult> ObterOSNaoIniciadas()
        {
            try
            {
                var os = await _ordemDeServicoApp.ObterOSNaoIniciadas();

                return Ok(os);

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
        [HttpPost]
        public async Task<IActionResult> IncluirOS([FromBody]IncluirOSViewModel osInput)
        {
            try
            {
                await _ordemDeServicoApp.IncluirOS(osInput);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
        [HttpPost, Route("iniciar/{idOs}/{idResponsavel}")]
        public async Task<IActionResult> IniciarOS([FromRoute]long idOs, [FromRoute] long idResponsavel)
        {
            try
            {
                await _ordemDeServicoApp.IniciarOS(idOs,idResponsavel);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
        [HttpPost, Route("editar")]
        public async Task<IActionResult> EditarOS([FromBody]EditarOSViewModel osInput)
        {
            try
            {
                await _ordemDeServicoApp.EditarOS(osInput);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
        [HttpPost, Route("finalizar/{idOs}")]
        public async Task<IActionResult> FinalizarOS([FromRoute] long idOs)
        {
            try
            {
                await _ordemDeServicoApp.FinalizarOS(idOs);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

    }
}
