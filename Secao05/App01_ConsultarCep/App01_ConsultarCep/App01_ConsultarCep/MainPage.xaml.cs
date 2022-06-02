using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App01_ConsultarCep.Serviço.Modelo;
using App01_ConsultarCep.Serviço;

namespace App01_ConsultarCep
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
            string cep = CEP.Text.Trim();

            if (isValidCEP(cep)) {

                try
                {
                    Endereco end = ViaCepServicos.BuscarEnderecoViaCep(cep);
                    if (end != null)
                    {
                        RESULTADO.Text = string.Format("Endereço : {0}, {1},{2}", end.localidade, end.uf, end.logradouro);
                    }
                    else
                    {
                        DisplayAlert("ERRO", "O ENDERECO NAO FOI ENCONTRADO PARA O ENDERECO INFORMADO:" + cep, "OK");
                    }
                }
                catch (Exception e)
                {
                    DisplayAlert("ERRO CRITICO", e.Message, "OK");
                }
            }

        }

        private bool isValidCEP(string cep)
        {
            bool valido = true;

           if (cep.Length != 8)
            {
                DisplayAlert("ERRO", "CEP invalido ! O CEP deve conter 8 caracteres.", "ok");

                valido = false;
            }
            int NovoCEP = 0;

            if (int.TryParse(cep, out NovoCEP))
            {
                DisplayAlert("ERRO", "CEP invalido ! O Cep deve ser apena composto por numeros.", "ok");
                valido = false;
            }
            

            return valido;
    }
    }
}
