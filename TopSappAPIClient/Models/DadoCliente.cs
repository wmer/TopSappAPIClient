using System;
using System.Collections.Generic;
using System.Text;

namespace TopSappAPIClient.Models {
    public class DadoCliente {
        public string id { get; set; }
        public string nome { get; set; }
        public string fantasia { get; set; }
        public string pessoa { get; set; }
        public string cpfcnpj { get; set; }
        public string rg { get; set; }
        public string inscricao_estadual { get; set; }
        public string inscricao_municipal { get; set; }
        public string classe_fiscal { get; set; }
        public string sexo { get; set; }
        public string data_nascimento { get; set; }
        public string endereco { get; set; }
        public string numero { get; set; }
        public string complemento { get; set; }
        public string bairro { get; set; }
        public string cep { get; set; }
        public string id_cidade { get; set; }
        public string cidade { get; set; }
        public string cidade_identificacao { get; set; }
        public string cidade_codigo_ibge { get; set; }
        public string uf { get; set; }
        public int id_status { get; set; }
        public string status { get; set; }
        public string email { get; set; }
        public string telefone { get; set; }
        public string celular { get; set; }
        public string representante { get; set; }
        public string representantecargo { get; set; }
        public string representantecpf { get; set; }
        public string representanterg { get; set; }
        public string servicos_bases { get; set; }
        public string senhacentral { get; set; }
        public string desconto { get; set; }
        public string acrescimo { get; set; }
        public string data_cadastro { get; set; }
        public string data_bloqueio { get; set; }
        public string data_desativacao { get; set; }
    }
}
