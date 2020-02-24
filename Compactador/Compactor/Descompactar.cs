using System;
using System.IO;
using System.Text;
using Compactador.Services;

namespace Compactador.Compactor
{
    class Descompactar
    {
        public void Descompacta(string text, string descompactado)
        {
            string compactado = "";
        // try
        //    {
                //string path = new DirDicionario().PathDirData();
                compactado = File.ReadAllText(text, Encoding.UTF8);
               string dirDicionario = File.ReadAllText(new DirDicionario().PathDirData(), Encoding.UTF8);

                string textFinal = "";
                string[] dicionario = dirDicionario.Split(" ");//Separado Dicionario
                string[] txtComprimido = compactado.Split(" ");//Separador Texto Compactado

                foreach (var id in txtComprimido)//Inicia a descompactação
                {
                    if (id != "")//Garante que não vai trazer lixo 
                    {
                    try
                    {
                        if ((dicionario[int.Parse(id)]).Contains("´"))

                            textFinal = string.Concat(textFinal + "\r\n" + dicionario[int.Parse(id)]);

                        else
                            textFinal = string.Concat(textFinal + " " + dicionario[int.Parse(id)]);
                    }
                    catch (Exception)
                    {
                        if (id.Contains("´"))
                            textFinal = string.Concat(textFinal + "\r\n" +id);
                        else
                            textFinal = string.Concat(textFinal + " " + id);
                    }
                    }
                }
           
            File.WriteAllText(descompactado, textFinal.Replace("´", ""));//Cria arquivo com o texto descompactado
            Console.WriteLine("\n    -- DESCOMPACTADO COM SUCESSO! --");
            }
           /* catch (Exception)
            {
                File.WriteAllText(descompactado, compactado);
                Console.WriteLine("         FORMATO INCOMPATIVEL!\n" +
                                  "     Realizada Conversão Genérica",Encoding.UTF8);
            }*/

        }

    }

