using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OficinaMeurer.Domain.ViewModel
{
    public class ClienteViewModel
    {
        public long? Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Marca { get; set; }
        [Required]
        public string Modelo { get; set; }
        [Required]
        public string Cor { get; set; }
        [Required]
        [RegularExpression("[A-Z]{3}[0-9][0-9A-Z][0-9]{2}",ErrorMessage="Placa inválida")]
        public string Placa { get; set; }
        [Required]
        [Range(1900,9999,ErrorMessage = "Ano inválido")]
        public int Ano { get; set; }
        public string Observacoes { get; set; }

    }
}
