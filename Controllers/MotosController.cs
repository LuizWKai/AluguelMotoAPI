
using AluguelMotos.DataBase;
using AluguelMotos.Models;
using AluguelMotos.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace AluguelMotos.Controller
{
    [ApiController]
    [Route("/motos")]
    public class MotosController : ControllerBase
    {
        private readonly IRepositorioMotos _repositorioMotos;

        public MotosController(IRepositorioMotos repositorioMotos)
        {
            _repositorioMotos = repositorioMotos ?? throw new ArgumentNullException(nameof(repositorioMotos));
        }

        [HttpPost]
        public IActionResult Add(MotosViewModel motosView)
        {
            try
            {
                var motoAdd = new Motos(
                    motosView.identificador,
                    motosView.ano,
                    motosView.modelo,
                    motosView.placa
                );

                _repositorioMotos.Add(motoAdd);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mesagem = "Dados inválidos", ex.Message });
            }

            return Ok();
        }
        [HttpGet]
        public IActionResult GetMotos(string placa)
        {
            try
            {
                var motoByPlaca = _repositorioMotos.GetMotoByPlaca(placa);
                if (motoByPlaca == null)
                    return NotFound(new { mensagem = "Moto não encontrada" });

                return Ok(motoByPlaca);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }
        [HttpPut]
        [Route("{id}/placa")]
        public IActionResult ModiPlaca([FromRoute] int id, [FromBody] MudarPlacaMoto mudarPlacaMoto)
        {
            try
            {
                var placaMoto = _repositorioMotos.GetByIdMotos(id);
                if (placaMoto == null)
                {
                    return NotFound(new { mensagem = "Moto não encontrada" });
                }
                _repositorioMotos.ModificaPlaca(id, mudarPlacaMoto.placa);

                return Ok( new { mensagem = "Placa modificada com sucesso"});
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult MotoById(int id)
        {
            try
            {
                var idMoto = _repositorioMotos.GetMotoById(id);
                if (idMoto == null)
                {
                    return NotFound(new { mensagem = "Moto não encontrada" });
                }
                return Ok(idMoto);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult RemoveMotoById(int id)
        {
            try
            {
                var idMoto = _repositorioMotos.GetMotoById(id);
                if (idMoto == null)
                {
                    return NotFound(new { mensagem = "Moto não encontrada" });

                }

                _repositorioMotos.RemoveMoto(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }
    }
}

