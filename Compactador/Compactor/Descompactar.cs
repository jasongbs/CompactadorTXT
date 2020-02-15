using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Compactador.Compactor
{
    class Descompactar
    {
        public void Descompacta(string text, string descompactado)
        {
         try
            {
                string compactado = File.ReadAllText(text, Encoding.UTF8);
                string textFinal = "";
                string[] separadorDicTex = compactado.Split("|");//Separador Dicionário e Texto compactado
                string[] dicionario = separadorDicTex[0].Split(" ");//Separado Dicionario
                string[] txtComprimido = separadorDicTex[1].Split(" ");//Separador Texto Compactado

                compactado = null;
                separadorDicTex = null;
                foreach (var id in txtComprimido)//Inicia a descompactação
                {
                    if (id != "")//Garante que não vai trazer lixo 
                        if (dicionario[int.Parse(id)].Contains("´"))
                        {
                           textFinal = string.Concat(textFinal + "\r\n" + dicionario[int.Parse(id)]);
                        }
                        else
                        textFinal = string.Concat(textFinal + " " + dicionario[int.Parse(id)]);
                }
           
            File.WriteAllText(descompactado, textFinal.Replace("´", ""));//Cria arquivo com o texto descompactado
            Console.WriteLine("\n    -- DESCOMPACTADO COM SUCESSO! --");
            }
            catch (Exception)
            {
                Console.WriteLine("         ARQUIVO INCOMPATIVEL!");
            }

        }

    }
}
