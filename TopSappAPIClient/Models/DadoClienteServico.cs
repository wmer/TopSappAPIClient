using System;
using System.Collections.Generic;
using System.Text;

namespace TopSappAPIClient.Models {
    public class DadoClienteServico {
        public string id_servico { get; set; }
        public string id_cliente { get; set; }
        public string id_base { get; set; }
        public string @base { get; set; }
        public string id_ap { get; set; }
        public string id_porta { get; set; }
        public string id_perfil { get; set; }
        public string serial { get; set; }
        public string tecnologia { get; set; }
        public string vencimento_ultimo_contrato { get; set; }
        public string dhcp_username { get; set; }
        public string dhcp_client_id { get; set; }
        public string dhcp_agent_circuit_id { get; set; }
        public object dhcp_liberar { get; set; }
        public string servico { get; set; }
        public string descricao { get; set; }
        public string servico_download { get; set; }
        public string servico_upload { get; set; }
        public string servico_franquia { get; set; }
        public string servico_valor { get; set; }
        public string servico_acrescimo { get; set; }
        public string servico_desconto { get; set; }
        public string servico_total { get; set; }
        public string usuario { get; set; }
        public string senha { get; set; }
        public string tipo { get; set; }
        public string id_status { get; set; }
        public string status { get; set; }
        public string ip { get; set; }
        public string mac { get; set; }
        public string mac_list { get; set; }
        public string mac_list_liberar { get; set; }
        public string vencimento { get; set; }
        public string periodo_inicio { get; set; }
        public string periodo_fim { get; set; }
        public string periodo_acesso_download { get; set; }
        public string periodo_acesso_upload { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string data_cadastro { get; set; }
        public string data_ativacao { get; set; }
        public string data_bloqueio { get; set; }
        public string data_desativacao { get; set; }
        public string instalacao_endereco { get; set; }
        public string instalacao_numero { get; set; }
        public string instalacao_bairro { get; set; }
        public string instalacao_cidade { get; set; }
       // public string instalacao_complemento { get; set; }
        public string instalacao_uf { get; set; }
        public string instalacao_cep { get; set; }
        public string instalacao_nome { get; set; }
        public string instalacao_contato { get; set; }
        public string instalacao_contato1 { get; set; }
        public string conexao { get; set; }
        public string topmaps_id_projeto { get; set; }
        public string topmaps_id_ligacao { get; set; }
        public string topmaps_id_porta { get; set; }
    }
}
