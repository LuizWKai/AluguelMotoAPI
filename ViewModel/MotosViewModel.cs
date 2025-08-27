using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// intermedia a comunicação entre a View (UI) e o Model (dados)

namespace AluguelMotos.ViewModel
{
    public class MotosViewModel
    {
        public required string identificador { get; set; } = "moto123";

        public required int ano { get; set; }

        public required string modelo { get; set; }

        public required string placa { get; set; }
    }

    public class MudarPlacaMoto
    {
        public required string placa { get; set; }
    }

}