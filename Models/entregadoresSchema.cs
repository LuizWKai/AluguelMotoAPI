
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AluguelMotos.Models
{
    [Table("entregadoresuser")]
    public class EntregadoresUser
    {
        [Key]
        public int id { get; private set; }
        public string identificador { get; private set; } = "entregador123";
        public string nome { get; private set; } = "João da Silva";
        public string cnpj { get; private set; } = "12345678901234";

        public DateTime data_nascimento { get; private set; } = DateTime.Parse("1990-01-01");
        public string numero_cnh { get; private set; } = "12345678900";

        public string tipo_cnh { get; private set; } = "A";
        public string imagem_cnh { get; private set; } = "base64string";

        public EntregadoresUser(
            string identificador,
            string nome,
            string cnpj,
            DateTime data_nascimento,
            string numero_cnh,
            string tipo_cnh,
            string imagem_cnh
        )
        {
            this.identificador = identificador ?? throw new ArgumentNullException(nameof(identificador));
            this.nome = nome ?? throw new ArgumentNullException(nameof(nome));
            this.cnpj = cnpj ?? throw new ArgumentNullException(nameof(cnpj));
            this.data_nascimento = data_nascimento;
            this.numero_cnh = numero_cnh ?? throw new ArgumentNullException(nameof(numero_cnh));
            this.tipo_cnh = tipo_cnh ?? throw new ArgumentNullException(nameof(tipo_cnh));
            this.imagem_cnh = imagem_cnh;
        }

        public void UpdateImgCnh(
            string imagem_cnh
        )
        {
            this.imagem_cnh = imagem_cnh ?? throw new ArgumentNullException(nameof(imagem_cnh));
        }
    }
}