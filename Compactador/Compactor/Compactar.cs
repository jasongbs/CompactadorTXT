using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Compactador.Services;

namespace Compactador.Compactor
{
    class Compactar
    {
        public void Compacta(string text, string compactado)
        {
            string[] descompactado = File.ReadAllLines(text, Encoding.UTF7);

            string dirDicionario = File.ReadAllText(new DirDicionario().PathDirData(), Encoding.UTF8);
            string textonovo = "", textNovo = "", dicionario = "";

            string[] palavras = dirDicionario.Split(" ");

            var existe = new List<string> { };
            int posicao;

            //todas as palvras que existem no dicionario
            foreach (string palavra in palavras)
            {
                existe.Add(palavra);
            }

            //colocar os indicadores para pular linhas
            foreach (string line in descompactado)
            {
                textonovo += line + " ´ ";
            }

            //separar todas as palavras do texto
            string[] palavrasText = textonovo.Split(" ");
     
             foreach (string l in existe)
             dicionario = string.Concat(dicionario + l + " ");//atualiza o dicionário,

                foreach (string lline in palavrasText)
                {
                    if (existe.Equals("´"))
                    {
                        textNovo = string.Concat(textNovo + "\n ");
                    }
                if (existe.IndexOf(lline) >= 0)
                {
                    posicao = existe.IndexOf(lline);//verifica a posição da palavra
                    textNovo = string.Concat(textNovo + posicao + " ");//E insere a posição na area de texto compactado
                }
                else
                    textNovo = string.Concat(textNovo + lline + " ");//E insere a posição na area de texto compactado
                }
                //Cria arquivo txt com o texto compactado
                File.WriteAllText(compactado, textNovo);

                Console.WriteLine("\n    -- COMPACTADO COM SUCESSO! --"); 
        }

    } 
}
