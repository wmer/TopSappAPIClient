using System;
using System.Collections.Generic;
using System.Text;

namespace TopSappAPIClient.Models {
    public class ClientesResult {
        public bool resultado { get; set; }
        public List<DadoCliente> dados { get; set; }
    }
}
