using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using App1_ConsultarCep.Servico.Modelo;
using Newtonsoft.Json;

namespace App1_ConsultarCep.Servico
{
    public class ViaCEPServico
    {
        private static string EnderecoURL = "https://viacep.com.br/ws/{0}/json/";

        public static Endereco BuscarEnderecoViaCEP(string CEP)
        {
            string NovoEnderecoURL = string.Format(EnderecoURL, CEP);

            WebClient wc = new WebClient();
            string Conteudo = wc.DownloadString(NovoEnderecoURL);

            Endereco end = JsonConvert.DeserializeObject<Endereco>(Conteudo);

            if (end.Cep == null) return null;

            return end;
        }
    }
}
