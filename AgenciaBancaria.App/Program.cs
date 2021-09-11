using AgenciaBancaria.Dominio;
using System;

namespace AgenciaBancaria.App
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Endereco endereco = new Endereco("José J.", "54321", "Carpina", "PE");
                Cliente cliente = new Cliente("Paulo", "123456", "654321", endereco);

                ContaCorrente contaBancaria = new ContaCorrente(cliente, 100);

                Console.WriteLine("Conta " + contaBancaria.Situacao+ ": " + contaBancaria.NumeroConta + "-" + contaBancaria.DigitoVerificador) ;

                string senha = "A1234567";
                contaBancaria.Abrir(senha);

                Console.WriteLine("Conta " + contaBancaria.Situacao + ": " + contaBancaria.NumeroConta + "-" + contaBancaria.DigitoVerificador);

                contaBancaria.Sacar(10, senha);

                Console.WriteLine("Saldo: " + contaBancaria.Saldo);
            } 
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
