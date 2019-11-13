using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoX.ProjetoTeste
{
    public class Credito
    {
        public Credito(decimal _valor, TipoCredito _tipoCredito, int _qtdeParcelas, DateTime _dataPrimeiroVencimento)
        {
            valor= _valor;
            tipoCredito = _tipoCredito;
            qtdeParcelas = _qtdeParcelas;
            dataPrimeiroVencimento = _dataPrimeiroVencimento;

            Validar();

            CalcularTotal();
        }

        private decimal valor;
        public decimal Valor
        {
            get { return valor; }
        }

        private TipoCredito tipoCredito;
        public TipoCredito TipoCredito
        {
            get { return tipoCredito; }
        }

        private int qtdeParcelas;
        public int QtdeParcelaso
        {
            get { return qtdeParcelas; }
        }

        private DateTime dataPrimeiroVencimento;
        public DateTime DataPrimeiroVencimento
        {
            get { return dataPrimeiroVencimento; }
        }

        private decimal valorTotal;
        public decimal ValorTotal
        {
            get { return valorTotal; }
        }


        private void CalcularTotal()
        {
            decimal taxa = 0;

            switch (tipoCredito)
            {
                case TipoCredito.creditoDireto:
                    taxa = 2 / 100;
                    break;


                case TipoCredito.creditoConsignado:
                    taxa = 2 / 100 ;
                    break;

                case TipoCredito.creditoPessoaJuridica:

                    taxa = 5 / 100 ;
                    break;

                case TipoCredito.creditoPessoaFisica:

                    taxa = 3 / 100 ;
                    break;

                case TipoCredito.creditoImobiliario:

                    taxa = 9 / 100 ;
                    break;
            }

            valorTotal = valor * (1 + taxa * qtdeParcelas);
        }

        private void Validar()
        {
            if (valor > 1000000)
            {
                throw new Exception("O valor ultrapassa o limite permitido");
            }
            if (qtdeParcelas < 5 || qtdeParcelas > 72)
            {
                throw new Exception("Número de parcelas inválidas");
            }
             if (tipoCredito == TipoCredito.creditoPessoaJuridica && valor < 15000)
            {
                throw new Exception("O valor mininimo a ser liberado é 15000");
            }
            if (dataPrimeiroVencimento < DateTime.Today.AddDays(15) || dataPrimeiroVencimento > DateTime.Today.AddDays(40))
            { 
                throw new Exception("A data do primeiro vencimento deve ser posterior a 15 dias e anterior a 40 dias a partir da data atual.");
            }
        }

    }
}
