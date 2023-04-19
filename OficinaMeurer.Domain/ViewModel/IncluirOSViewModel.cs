using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OficinaMeurer.Domain.ViewModel
{
    public class IncluirOSViewModel
    {
        public long? Id { get; set; }
        public long IdCliente { get; set; }
        public string Solicitacao { get; set; }
        public string? Observacao { get; set; }

        public IEnumerable<ServicoViewModel> ServicosOS { get; set; }
        public IEnumerable<ProdutoViewModel> ProdutosOS { get; set; }
    }
}
