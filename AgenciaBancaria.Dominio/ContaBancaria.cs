using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AgenciaBancaria.Dominio
{
    public abstract class ContaBancaria
    {
        public ContaBancaria(Cliente cliente)
        {
            Random random = new Random();
            NumeroConta = random.Next(50000, 100000);
            
            DigitoVerificador = random.Next(0, 9);
            
            Situacao = SituacaoConta.Criada;

            Cliente = cliente ?? throw new Exception("Cliente deve ser informado");
        }

        public void Abrir(string senha) 
        {
            SetaSenha(senha);

            Situacao = SituacaoConta.Aberta;
            DataAbertura = DateTime.Now;
        }

        private void SetaSenha(string senha)
        {
            senha = senha.ValidaStringVazia();
            //Minimum eight characters, at least one letter and one number:
            if (!Regex.IsMatch(senha, @"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$"))
            {
                throw new Exception("A senha deve conter pelo menos 8 dígitos sendo pele menos 1 letra e um número");
            }

            Senha = senha;

        }

        public virtual void Sacar(decimal valor, string senha)
        {
            if (Senha != senha)
            {
                throw new Exception("Senha inválida.");
            }

            if (Saldo < valor)
            {
                throw new Exception("Saldo insuficiente.");
            }
                Saldo -= valor;
        }

        public int NumeroConta { get; init; } //Init indica que eu só posso alterar a propriedade somente na iniciação do objeto, ou seja, no construtor
        public int DigitoVerificador { get; init; }
        public decimal Saldo { get; protected set; }
        public DateTime? DataAbertura { get; private set; }
        public DateTime? DataEncerramento { get; private set; }
        public SituacaoConta Situacao { get; private set; }
        public string Senha { get; private set; }
        public Cliente Cliente { get; init; }

    }
}
