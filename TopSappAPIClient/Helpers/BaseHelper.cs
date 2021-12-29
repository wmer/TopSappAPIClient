using ManyHelpers.Collection;
using ManyHelpers.Strings;
using Newtonsoft.Json;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopSappAPIClient.Models;

namespace TopSappAPIClient.Helpers {
    public class BaseHelper {
        public static IEnumerable<BaseCobranca> CreateBase(List<DadoCliente> clientes, List<Dado> docs, string centralLink) {
            var uri = new Uri(centralLink);
            var link = uri.GetComponents(UriComponents.AbsoluteUri & ~UriComponents.Port,
                               UriFormat.UriEscaped);

            if (!link.EndsWith("/")) {
                link = $"{link}/";
            }

            return from cliente in clientes
                   join doc in docs on StringHelper.GetOnlyPositiveNumbers(cliente.id.ToString()) equals StringHelper.GetOnlyPositiveNumbers(doc.codigo_cliente.ToString())
                   select new BaseCobranca {
                       CodigoCliente = doc.codigo_cliente.ToString(),
                       CPFCNPJ = cliente?.cpfcnpj,
                       Nome = cliente?.nome,
                       Celular = cliente?.celular,
                       Telefone = cliente?.telefone,
                       Email = cliente?.email,
                       Status = cliente?.status,
                       Documento = doc.id.ToString(),
                       Valor = doc.valor.Replace(".", ","),
                       Vencimento = DateTime.TryParse(doc.vencimento, out DateTime dataVencimento) ? dataVencimento : new DateTime(),
                       LinhaDigitavel = "",
                       Link = $"{link}BoletosListar/fatura/{StringHelper.GetOnlyPositiveNumbers(cliente.cpfcnpj)}/{doc.id}/pdf",
                       Cidade = cliente?.cidade
                   };
        }

        private static void AdicionarLinhaDigitavel(string apiHost, string user, string senha, string identificador, IEnumerable<TopSappAPIClient.Models.BaseCobranca> baseCobranca) {
            var i = 0;

            Console.WriteLine("");
            Console.WriteLine($"Buscando linha digitável de {baseCobranca.Count()} Faturas");

            Console.WriteLine("");

            var obj = new object();

            var splitedBase = baseCobranca.SplitList(baseCobranca.Count() / 5);
            Task[] taskArray = new Task[splitedBase.Count()];

            var t = 0;

            foreach (var baseCob in splitedBase) {
                taskArray[t] = Task.Factory.StartNew(async () => {
                    var api = new TopSappClient(apiHost);
                    var login = await api.LoginAsync(user, senha, identificador);

                    foreach (var fat in baseCob) {
                        try {
                            var detalhesFat = await api.DadosFaturaAsync(login.id_usuario, login.sessao, identificador, int.Parse(fat.CodigoCliente), int.Parse(fat.Documento));
                            fat.LinhaDigitavel = detalhesFat?.linha_digitavel;
                            Console.WriteLine($"Linha digitável: {fat.LinhaDigitavel} - Link: {fat.Link}");
                        } catch (Exception e) {
                            Console.WriteLine("");
                            Console.WriteLine($"Um erro aconteceu: {e.Message}");
                        }

                        i++;

                        Console.WriteLine($"Buscando, {i} de {baseCobranca.Count()}...");

                    }
                });

                t++;
            }

            Task.WaitAll(taskArray);

            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

        public static void CreateFile(IEnumerable<TopSappAPIClient.Models.BaseCobranca> result, string fileName) {
            try {
                Console.WriteLine($"Salvando {fileName}...");

                var json = JsonConvert.SerializeObject(result, Formatting.Indented);
                DataTable dt = (DataTable)JsonConvert.DeserializeObject(json, (typeof(DataTable)));

                using (ExcelPackage pck = new ExcelPackage(new FileInfo(fileName))) {
                    ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Base_API");
                    ws.Cells["A1"].LoadFromDataTable(dt, true);
                    ws.Column(9).Style.Numberformat.Format = "dd/MM/yyyy";
                    ws.Cells["A1:L1"].AutoFilter = true;
                    pck.Save();
                }


                Console.WriteLine($"{fileName} foi salvo!!");
            } catch (Exception e) {
                Console.WriteLine($"Um erro ocorreu: {e.Message}");
            }
        }
    }
}
