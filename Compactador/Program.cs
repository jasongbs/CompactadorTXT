using System;
using System.Text;
using Compactador.Compactor;


namespace Compactador
{
    class Program
    {
        static void Main(string[] args)
        {

            int escolha;
            string texto = @"E:\Users\Jason\Área de Trabalho/Compactador.txt";
            string compactado = @"E:\Users\Jason\Área de Trabalho/Compactado.unifaj";
            string descompactado = @"E:\Users\Jason\Área de Trabalho/Descompactado.txt";


            var compactar = new Compactar();
            var descompactar = new Descompactar();
            var ordenaDicionario = new OrdenaDicionario();
            do
            {
                Console.WriteLine(" COMPACTAÇÃO E DESCOMPACTAÇÃO DE ARQUIVOS", Encoding.UTF7);
                Console.WriteLine("=========================================");
                Console.WriteLine("1 - COMPACTAR ARQUIVO");
                Console.WriteLine("2 - DESCOMPACTAR ARQUIVO");
                Console.WriteLine("3 - ENSINAR");
                Console.WriteLine("0 - SAIR");
                Console.WriteLine("=========================================");
                escolha = int.Parse(Console.ReadLine());

                if (escolha == 1)
                {
                    compactar.Compacta(texto,compactado);
                  
                    Console.ReadLine();
                    Console.Clear();
             
                }
                else if (escolha == 2)
                {
                    descompactar.Descompacta(compactado, descompactado);
                    Console.ReadLine();
                    Console.Clear();
                }
                else if (escolha == 3)
                {
                    ordenaDicionario.Compacta(texto, compactado);
                    Console.ReadLine();
                    Console.Clear();
                }
                else if(escolha == 0)
                {
                    Console.WriteLine("Saindo...");
                }
                else
                    Console.WriteLine("OPÇÃO INVÁLIDA", Encoding.UTF7);
         
            } while (escolha != 0);
        }
    }
}
