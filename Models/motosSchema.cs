using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AluguelMotos.Models
{
    [Table("motos")]
    public class Motos
    {
        [Key]
        public int id { get; private set; }
        public string identificador { get; private set; } = "moto123";

        public int ano { get; private set; }

        public string modelo { get; private set; }

        public string placa { get; private set; }

        public Motos(
        string identificador,
        int ano,
        string modelo,
        string placa
        )
        {
            this.identificador = identificador ?? throw new ArgumentNullException(nameof(identificador));
            this.ano = ano;
            this.modelo = modelo ?? throw new ArgumentNullException(nameof(modelo));
            this.placa = placa ?? throw new ArgumentException(nameof(placa));
        }

        public void ModificaPlacaMoto(
            string placa
        )
        {
            this.placa = placa ?? throw new ArgumentException(nameof(placa));
        }

    }
}