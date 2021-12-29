using ManyHelpers.API;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TopSappAPIClient.Helpers;
using TopSappAPIClient.Models;

namespace TopSappAPIClient {
    public class TopSappClient {
        private string _baseUrl;

        private CosumingHelper _api;

        public TopSappClient(string baseUrl) {
            _baseUrl = baseUrl;
            _api = new CosumingHelper(_baseUrl)
                            .AddcontentType();
        }

        public async Task<LoginResult> LoginAsync(string usuario, string senha, string identificador) {
            var formContent = new FormUrlEncodedContent(new[]
                                        {
                                            new KeyValuePair<string, string>("usuario", usuario),
                                            new KeyValuePair<string, string>("senha", senha),
                                            new KeyValuePair<string, string>("identificador", identificador)
                                        });

            (LoginResult result, string statusCode, string message) = await _api.PostWithFormDataAsync<LoginResult>("Login", formContent);

            Debug.WriteLine($"Login statusCode: {statusCode}");

            return result;
        }

        public async Task<List<Dado>> DocumentosAReceberAsync(int idUsuario, string sessao, string identificador, DateTime vencInicial = default, DateTime vencFinal = default) {
            if (vencInicial == default) {
                vencInicial = DateTime.Now.AddDays(-99999);
            }

            if (vencFinal == default) {
                vencFinal = DateTime.Now.AddDays(99999);
            }

            var formContent = new FormUrlEncodedContent(new[]
                                        {
                                            new KeyValuePair<string, string>("idUsuario", idUsuario .ToString()),
                                            new KeyValuePair<string, string>("sessao", sessao),
                                            new KeyValuePair<string, string>("identificador", identificador)
                                            //new KeyValuePair<string, string>("vencimentoInicial ", vencInicial.ToString("dd/MM/yyyy")),
                                            //new KeyValuePair<string, string>("vencimentoFinal", vencFinal.ToString("dd/MM/yyyy"))
                                        });

            
            (DocumentosReceberResult result, string statusCode, string message) = await _api.PostWithFormDataAsync<DocumentosReceberResult>("ObterDocReceber", formContent);
 

            Debug.WriteLine($"DocumentosAReceber statusCode: {statusCode}");

            return result.dados;
        }

        public async Task<List<DadoClienteServico>> CllienteServicoAsync(int idUsuario, string sessao, string identificador) {
            var formContent = new FormUrlEncodedContent(new[]
                                        {
                                            new KeyValuePair<string, string>("idUsuario", idUsuario .ToString()),
                                            new KeyValuePair<string, string>("sessao", sessao),
                                            new KeyValuePair<string, string>("identificador", identificador)
                                        });


            (ClienteServico result, string statusCode, string message) = await _api.PostWithFormDataAsync<ClienteServico>("ObterClientesServicos", formContent);


            Debug.WriteLine($"DocumentosAReceber statusCode: {statusCode}");

            return result.dados;
        }

        public async Task<List<Dado>> DocBase64Async(int idUsuario, string sessao, string identificador, string cpf, int idFatura) {
            var formContent = new FormUrlEncodedContent(new[]
                                        {
                                            new KeyValuePair<string, string>("idUsuario", idUsuario .ToString()),
                                            new KeyValuePair<string, string>("sessao", sessao),
                                            new KeyValuePair<string, string>("identificador", identificador),
                                            new KeyValuePair<string, string>("idfatura", idFatura .ToString()),
                                            new KeyValuePair<string, string>("cpf", cpf)
                                        });

            (DocumentosReceberResult result, string statusCode, string message) = await _api.PostWithFormDataAsync<DocumentosReceberResult>("ObterDocReceberBase64", formContent);

            Debug.WriteLine($"DocumentosAReceber statusCode: {statusCode}");

            return result.dados;
        }


        public async Task<List<DadoCliente>> ClientesAsync(int idUsuario, string sessao, string identificador, int idCliente = 0) {
            var formContent = new FormUrlEncodedContent(new[]
                                        {
                                            new KeyValuePair<string, string>("idUsuario", idUsuario .ToString()),
                                            new KeyValuePair<string, string>("sessao", sessao),
                                            new KeyValuePair<string, string>("identificador", identificador)
                                        });

            if (idCliente > 0) {
                formContent = new FormUrlEncodedContent(new[]
                                        {
                                            new KeyValuePair<string, string>("idUsuario", idUsuario .ToString()),
                                            new KeyValuePair<string, string>("sessao", sessao),
                                            new KeyValuePair<string, string>("identificador", identificador),
                                            new KeyValuePair<string, string>("idCliente ", idCliente .ToString()),
                                            new KeyValuePair<string, string>("limiteInicio", "1"),
                                            new KeyValuePair<string, string>("limiteRegistros", "1")
                                        });
            }

            (ClientesResult result, string statusCode, string message) = await _api.PostWithFormDataAsync<ClientesResult>("ObterClientes", formContent);

            Debug.WriteLine($"ObterClientes  statusCode: {statusCode}");

            //var desk = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            //var file = $"{desk}\\JsonResponse.json";

            //System.IO.File.WriteAllText(file, message);

            return result.dados;
        }

        public async Task<Fatura> DadosFaturaAsync(int idUsuario, string sessao, string identificador, int idCliente, int idFatura) {
            var fatura = default(Fatura);

            try {
                var formContent = new FormUrlEncodedContent(new[]
             {
                                            new KeyValuePair<string, string>("idUsuario", idUsuario .ToString()),
                                            new KeyValuePair<string, string>("sessao", sessao),
                                            new KeyValuePair<string, string>("identificador", identificador),
                                            new KeyValuePair<string, string>("idCliente", idCliente .ToString()),
                                            new KeyValuePair<string, string>("idFatura", idFatura.ToString())
                                        });

                (DadosDocumentoReceberResult result, string statusCode, string message) = await _api.PostWithFormDataAsync<DadosDocumentoReceberResult>("ObterDocReceberDadosFatura", formContent);

                Debug.WriteLine($"DadosFatura  statusCode: {statusCode}");

                fatura = result?.fatura;
            } catch (Exception e) {
                Console.WriteLine($"Algo deu errado! {e.Message}");
            }

            return fatura;

        }
    }
}
