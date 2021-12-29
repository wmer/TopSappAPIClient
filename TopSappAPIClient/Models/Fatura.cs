using System;
using System.Collections.Generic;
using System.Text;

namespace TopSappAPIClient.Models {
    public class Fatura {
        public string id { get; set; }
        public string vencimento { get; set; }
        public string valor { get; set; }
        public string vencimento_atualizado { get; set; }
        public string valor_atualizado { get; set; }
        public string nosso_numero { get; set; }
        public string linha_digitavel { get; set; }
        public string url { get; set; }
    }
}
