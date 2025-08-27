using AluguelMotos.Models;

// intermedia a comunicação entre a View (UI) e o Model (dados)

namespace AluguelMotos.ViewModel
{
    public class EntregadoresViewModel
    {
        public required string identificador { get; set; }
        public required string nome { get; set; }
        public required string cnpj { get; set; }

        public required DateTime data_nascimento { get; set; }
        public required string numero_cnh { get; set; }

        public required string tipo_cnh { get; set; }
        public required string imagem_cnh { get; set; }

    }
    public class UploadCnhViewModel
    {
        public required string imagem_cnh { get; set; }
    }

}