using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoX.ProjetoTeste
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Informe o valor do crédito:");
                decimal valor = Convert.ToDecimal(Console.ReadLine());

                Console.WriteLine("Infome o tipo de crédito:");
                TipoCredito tipoCredito = (TipoCredito)Convert.ToDecimal(Console.ReadLine());

                Console.WriteLine("Infome o número de parcelas:");
                int qtdeParcelas = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Infome a data do primeiro vencimento:");
                DateTime dataPrimeiroVencimento = Convert.ToDateTime(Console.ReadLine());

                var credito = new Credito(valor, tipoCredito, qtdeParcelas, dataPrimeiroVencimento);

                Console.WriteLine("Crédito aprovado");
                Console.WriteLine($"Valor total: { credito.ValorTotal }");
                Console.WriteLine($"Juros: { credito.ValorTotal - credito.Valor }");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Crédito reprovado");
                Console.WriteLine($"Motivo: { ex.Message }");
                Console.ReadKey();
            }
        }
    }    
 }



