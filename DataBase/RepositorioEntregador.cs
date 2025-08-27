using AluguelMotos.Models;
using AluguelMotos.DataBase;
using Microsoft.Extensions.Diagnostics.HealthChecks;

// Responsável por acessar o banco de dados


namespace AluguelMotos.Infraestrutura
{
    public class RepositorioEntregador : IRepositorioEntregadores
    {
        private readonly ConnectionContext _context = new ConnectionContext();
        public void Add(EntregadoresUser EntregadoresUser)
        {
            _context.EntregadoresUser.Add(EntregadoresUser);
            _context.SaveChanges();
        }

        public List<EntregadoresUser> Get()
        {
            return _context.EntregadoresUser.ToList();
        }

        public EntregadoresUser? GetById(int id)
        {
            return _context.EntregadoresUser.Find(id);
        }

        public void UpdateImg(int id, string imagem_cnh)
        {
            var entregador = _context.EntregadoresUser.Find(id);

            if (entregador == null)
            {
                throw new ArgumentException("Dados inválidos", nameof(id));
            }

            entregador?.UpdateImgCnh(imagem_cnh);
            _context.SaveChanges();

        }
    }
}