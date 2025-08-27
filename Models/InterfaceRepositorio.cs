using AluguelMotos.Models;

/* A interface de um repositório define o contrato que a 
 implementação do repositório deve seguir. Ou seja, ela declara quais métodos 
 o repositório deve ter */

namespace AluguelMotos.DataBase
{
    public interface IRepositorioEntregadores
    {
        void Add(EntregadoresUser entregadoresuser);

        List<EntregadoresUser> Get();

        EntregadoresUser? GetById(int id);

        void UpdateImg(int id, string imagem_cnh);
    }
    public interface IRepositorioMotos
    {
        void Add(Motos motos);
        Motos GetMotoByPlaca(string placa);

        Motos? GetByIdMotos(int id);

        void ModificaPlaca(int id, string placa);

        Motos GetMotoById(int id);

        void RemoveMoto(int id);

    }
}