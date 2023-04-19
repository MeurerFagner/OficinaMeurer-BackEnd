using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OficinaMeurer.Domain.Entidades
{
    public class Cliente: EntidadeBase
    {
        public string Nome { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Cor { get; set; }
        public string Placa { get; set; }
        public int Ano { get; set; }
        public string? Observacoes { get; set; }

        public virtual ICollection<OrdemDeServico> OrdemDeServicos { get; set; }
    }
}
