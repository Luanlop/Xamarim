using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App1_ConsultarCep.Servico.Modelo;
using App1_ConsultarCep.Servico;

namespace App1_ConsultarCep
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BOTAO.Clicked += BuscarCep;
        }

        private void BuscarCep(object sender, EventArgs args)
        {          
            //TODO - Validaçoes.
            string Cep = CEP.Text.Trim();

            if (isvalidCep(Cep))
            {
                try
                {
                    Endereco end = ViaCEPServico.BuscarEnderecoViaCEP(Cep);
                    if (end != null)
                    {
                        RESULTADO.Text = string.Format("Endereço:{2} de {3} {0},{1} ", end.Localidade, end.Uf, end.Logradouro, end.Bairro);
                    }
                    else
                    {
                        DisplayAlert("ERRO", "O endereço não foi encontrado para o CEP informado: " + Cep, "OK");
                    }
                }
                catch(Exception e)
                {
                    DisplayAlert("ERRO CRITICO", e.Message, "OK");
                }    
            }           
        }

        private bool isvalidCep(string Cep)
        {
            bool valido = true;

            if (Cep.Length != 8)
            {
                DisplayAlert("ERRO", "CEP invalido! O CEP deve conter 8 caracteres.", "OK");

                valido = false;
            }

            int NOVOCEP = 0;
            if(!int.TryParse(Cep, out NOVOCEP))
            {
                DisplayAlert("ERRO", "CEP invalido! O CEP deve ter apenas numeros", "OK");

                valido = false;
            }

            return valido;

             
        }
    }
}
