using System;
using System.Globalization;

namespace Questao1
{
    class ContaBancaria
    {
        private int Numero { get; set; }
        private string Titular { get; set; }
        private double Saldo { get; set; }

        private const double TaxaSaque = 3.5;

        public ContaBancaria(int numero, string titular, double depositoInicial = 0)
        {
            this.Numero = numero;
            this.Titular = titular;
            this.Saldo = depositoInicial;
        }

        public void Deposito(double quantiaDeposito)
        {
            this.Saldo += quantiaDeposito;
        }

        public void Saque(double quantiaSaque)
        {
            this.Saldo = (this.Saldo - quantiaSaque) - TaxaSaque;
        }

        

        public override string ToString()
        {
            return "Conta " + this.Numero + " , Titular: " + this.Titular + " , Saldo: $ " + this.Saldo.ToString("F");
        }
    }

}
