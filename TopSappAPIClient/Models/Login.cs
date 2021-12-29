using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TopSappAPIClient.Models {
    public class Login {
        [JsonProperty("usuario")]
        public string Usuario { get; set; }
        [JsonProperty("senha")]
        public string Senha { get; set; }
        [JsonProperty("identificador")]
        public string Identificador { get; set; }
    }
}
