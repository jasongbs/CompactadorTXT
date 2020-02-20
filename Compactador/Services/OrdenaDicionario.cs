using System;
using System.Collections.Generic;
using System.Text;

namespace Compactador.Services
{
    class OrdenaDicionario
    {

        /*--- Método de Ordenação do vetor de string------------------------------------------------------*/

        static void Selecao(string[] palavra)
        {
            int i, j, min;
            string varAux;
            for (i = 0; i < palavra.Length - 1; i++)
            {
                min = i;
                for (j = i + 1; j < palavra.Length; j++)
                {
                    // Utilizando o CompareTo para comparar as string do vetor
                    // resultado -1 significa que cidades[j] < cidades[min]
                    if (palavra[j].CompareTo(palavra[min]) == -1)
                    {
                        min = j;
                    }
                }
                varAux = palavra[min];
                palavra[min] = palavra[i];
                palavra[i] = varAux;
            }


        }
    }
}