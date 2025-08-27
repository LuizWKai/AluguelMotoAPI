using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AluguelMotos.Models;
using Microsoft.AspNetCore.Http.HttpResults;

// Responsável por acessar o banco de dados

namespace AluguelMotos.DataBase
{
    public class RepositorioMotos : IRepositorioMotos
    {
        private readonly ConnectionContext _context = new ConnectionContext();

        public void Add(Motos motos)
        {
            _context.Motos.Add(motos);
            _context.SaveChanges();
        }


        public Motos GetMotoByPlaca(string placa)
        {

            var placaMoto = _context.Motos.FirstOrDefault(m => m.placa == placa);
            if (placaMoto == null)
                throw new ArgumentException("Dados inválidos", nameof(placa));

            return placaMoto;
        }

        public void ModificaPlaca(int id, string placa)
        {
            var placaMoto = _context.Motos.Find(id);

            if (placaMoto == null)
                throw new ArgumentException("Dados inválidos", nameof(id));

            placaMoto?.ModificaPlacaMoto(placa);
            _context.SaveChanges();
        }
        public Motos? GetByIdMotos(int id)
        {
            return _context.Motos.Find(id);
        }

        public Motos GetMotoById(int id)
        {

            var motoId = _context.Motos.Find(id);
            if (motoId == null)
                throw new ArgumentException("Dados inválidos", nameof(motoId));

            return motoId;
        }
        public void RemoveMoto(int id)
        {
            var motoId = _context.Motos.Find(id);
            if (motoId == null)
                throw new ArgumentException("Dados inválidos", nameof(motoId));
            _context.Motos.Remove(motoId);
            _context.SaveChanges();
        }

    }
}