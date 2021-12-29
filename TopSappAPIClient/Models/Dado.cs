using System;
using System.Collections.Generic;
using System.Text;

namespace TopSappAPIClient.Models {
    public class Dado {
        public string id { get; set; }
        public string datacadastro { get; set; }
        public string valor { get; set; }
        public string vencimento { get; set; }
        public string pago { get; set; }
        public string datapagto { get; set; }
        public string valorpago { get; set; }
        public string pagoem { get; set; }
        public string historico { get; set; }
        public string numero_fatura { get; set; }
        public string periodo_inicio { get; set; }
        public string periodo_fim { get; set; }
        public string cod_portador { get; set; }
        public string portador { get; set; }
        public string cod_documento { get; set; }
        public string documento { get; set; }
        public string cod_plano_contas { get; set; }
        public string plano_contas { get; set; }
        public string codigo_cliente { get; set; }
        public string codigo_servico { get; set; }
        public string nome { get; set; }
        public string endereco { get; set; }
        public string numero { get; set; }
        public string bairro { get; set; }
        public string cep { get; set; }
        public string cidade { get; set; }
        public string uf { get; set; }
        public string celular { get; set; }
        public string telefone { get; set; }
        public string fatura_instrucoes { get; set; }
        public string fatura_observacoes { get; set; }
        public string desmembrar_scm_sva { get; set; }
        public string situacao { get; set; }
    }
}
