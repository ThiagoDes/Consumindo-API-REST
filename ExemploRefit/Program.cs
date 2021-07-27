using Refit;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExemploRefit
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                var cepClient = RestService.For<ICepApiService>("https://viacep.com.br");

                Console.WriteLine("Seja bem vindo!");
                Console.WriteLine("Informe seu Cep:");

                String cepInformado = Console.ReadLine().ToString();
                cepInformado = Regex.Replace(cepInformado, "[^0-9a-zA-Z]+", "");
                Console.WriteLine("Consultando informações do CEP: " + cepInformado);

                var address = await cepClient.GetAddressAsync(cepInformado);

                Console.WriteLine($"\nLogradouro: {address.Logradouro}, \nBairro: {address.Bairro}, \nCidade: {address.Localidade}");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro na consulta de cep: " + ex.Message);
            }
        }
    }
}
