using System;
using System.Collections.Generic;
using System.Text;

namespace TopSappAPIClient.Models {
    public class BaseCobranca {
        public string CodigoCliente { get; set; }
        public string CPFCNPJ { get; set; }
        public string Nome { get; set; }
        public string Celular { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public string Documento { get; set; }
        public string Valor { get; set; }
        public DateTime Vencimento { get; set; }
        public string LinhaDigitavel { get; set; }
        public string Link { get; set; }
    }
}
