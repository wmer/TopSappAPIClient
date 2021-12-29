using System;
using System.Collections.Generic;
using System.Text;

namespace TopSappAPIClient.Models {
    public class LoginResult {
        public bool resultado { get; set; }
        public string codigo { get; set; }
        public string msg { get; set; }
        public string sessao { get; set; }
        public int id_usuario { get; set; }
        public string nome_usuario { get; set; }
    }
}
