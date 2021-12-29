using System;
using System.Collections.Generic;
using System.Text;

namespace TopSappAPIClient.Models {
    public class DocumentosReceberRequest {
        public int IdUsuario { get; set; }
        public string sessao { get; set; }
        public string identifcador { get; set; }
    }
}
