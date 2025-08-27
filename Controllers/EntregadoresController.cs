using AluguelMotos.DataBase;
using Microsoft.AspNetCore.Mvc;
using AluguelMotos.ViewModel;
using AluguelMotos.Models;

namespace AluguelMotos.Controllers
{
    [ApiController]
    [Route("/entregadores")]
    public class EntregadoresController : ControllerBase
    {
        // INJEÇÃO DE DEPENDÊNCIA
        private readonly IRepositorioEntregadores _repositorioEntregadores;

        public EntregadoresController(IRepositorioEntregadores repositorioEntregadores)
        {
            _repositorioEntregadores = repositorioEntregadores ?? throw new ArgumentNullException(nameof(repositorioEntregadores));
        }

        [HttpPost]
        public IActionResult Add(EntregadoresViewModel entregadoresView)
        {
            try
            {
                var entregador = new EntregadoresUser(
                entregadoresView.identificador,
                entregadoresView.nome,
                entregadoresView.cnpj,
                entregadoresView.data_nascimento,
                entregadoresView.numero_cnh,
                entregadoresView.tipo_cnh,
                entregadoresView.imagem_cnh
                );

                _repositorioEntregadores.Add(entregador);

            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Dados inválidos", ex.Message });
            }

            return Ok();
        }

        [HttpPost]
        [Route("{id}/cnh")]
        public IActionResult UpdateCnh(int id, UploadCnhViewModel uploadCnhView)
        {

            try
            {
                var entregador = _repositorioEntregadores.GetById(id);
                if (entregador == null)
                    return NotFound(new { mensagem = "Dados inválidos" });

                byte[] imagemBytes;
                try
                {
                    imagemBytes = Convert.FromBase64String(uploadCnhView.imagem_cnh);
                }
                catch
                {
                    return BadRequest(new { mensagem = "Dados inválidos" });
                }

                var pasta = Path.Combine(Directory.GetCurrentDirectory(), "Storage");
                Directory.CreateDirectory(pasta);

                var nomeArquivo = $"{Guid.NewGuid()}.jpg";
                var caminhoArquivo = Path.Combine(pasta, nomeArquivo);

                System.IO.File.WriteAllBytes(caminhoArquivo, imagemBytes);
                _repositorioEntregadores.UpdateImg(id, nomeArquivo);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }

        }

    }
}