using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteNetMoveis.Models
{
    public class Imovel
    {
        public int Id { get; set; }
        public string TipoImovel { get; set; }
        public double ValorVendaImovel { get; set; }
        public double ValorLocacaoImovel { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }
    }
}
