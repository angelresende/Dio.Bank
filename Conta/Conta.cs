using System;

namespace Dio.Bank
{
    public class Conta
    {
        private TipoConta TipoConta {get; set;}
        private double Saldo {get; set;}
        private double Credito {get; set;}
        private string Nome {get; set;}

        public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
        {
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
        }
        public bool Sacar(double valorSaque)
        {
            //validação de saldo insuficiente
            if(this.Saldo - valorSaque <(this.Credito*-1)){
                Console.WriteLine("Saldo insuficiente!");
                return false;
            }

            this.Saldo -= valorSaque;

            Console.WriteLine("Saldo atual da conta {0} é {1}", this.Nome, this.Saldo);
            //{0} e {1} tipo um vetor de dados, irá considerar as informações posteriores.

            return true;
        }

        public void Depositar(double valorDeposito)
        {
            this.Saldo += valorDeposito;
            Console.WriteLine("Saldo atual da conta {0} é {1}", this.Nome, this.Saldo);
        }
        public void Transferir(double valorTransferencia, Conta ContaDestino)
        {
            //validação de saldo insuficiente
            if(this.Sacar(valorTransferencia)){
                ContaDestino.Depositar(valorTransferencia);
            }         
        }

        public override string ToString()
        {
            string retorno = " ";
            retorno+="Tipo de Conta: " + this.TipoConta + " | ";
            retorno+="Nome: " + this.Nome + " | ";
            retorno+="Saldo: " + this.Credito + " | ";
            retorno+="Crédito: " + this.Credito;
            return retorno;
        }
    }
}