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
            /*Verifica se a palavra existe no dicionario, se não existir ele insere a mesma na area de dicionario
            e depois coloca a posicao do dicionário na area de textos compactados, caso contrario só coloca a posicao do dicionario.
            */

           /* foreach (string line in palavrasText)
            {
                if (existe.IndexOf(line) == -1)//verifica se a palavra não existe no dicionario
                {
                    if (palavras.Contains(line))
                    {

                    }
                    else
                        existe.Add(line);
                 }
            }*/
        
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

                //biblioteca
              //  string caminho = new DirDicionario().PathDirData();
                //modo 1
               // File.WriteAllText(caminho, dicionario);
                //modo 2
                /* StreamWriter s = File.AppendText(caminho);
                 s.WriteLine(dicionario);
                 s.Close();*/

                FileStream original = new FileStream(text, FileMode.Open);
                FileStream compacto = new FileStream(compactado, FileMode.Open);

                //Verifica se arquivo compactado é maior que o original
              /*  if (original.Length < compacto.Length)
                {
                    Console.WriteLine(" ARQUIVO JÁ É MUITO PEQUENO", Encoding.UTF7);
                    original.Close();
                    compacto.Close();
                    File.WriteAllText(compactado, textonovo);
                }
                else
                {*/
                    Console.WriteLine("\n    -- COMPACTADO COM SUCESSO! --");
                    original.Close();
                    compacto.Close();
               // }
            
        }

        private string Verifica(string line, List<string> existe, string textNovo)
        {
            int posicao;
            if (line.Contains(','))
            {
                string[] separa = line.Split(',');
                posicao = Posicao(separa[0], existe);
                //  posicao = separa.(separa[0]);//verifica a posição da palavra
                textNovo = string.Concat(textNovo + posicao + ", ");//E insere a posição na area de texto compactado
                return textNovo;

            }
            else if (line.Contains('.'))
            {
                string[] separa = line.Split('.');
                posicao = Posicao(separa[0], existe);
               // posicao = existe.IndexOf(separa[0]);//verifica a posição da palavra
                textNovo = string.Concat(textNovo + posicao + ". ");//E insere a posição na area de texto compactado
                return (textNovo);
            }
            return textNovo;
        }
         

        

        private int Posicao(string palavra, List<string> existe)
        {
            int posi=0;
          if (existe.IndexOf(palavra) < 0)
             existe.Add(palavra);
        
          foreach(string p in existe)
            {
                if (p.Equals(palavra))
                {
                    return posi;
                }
             posi++;
            }
         return posi;
         
        }

    } 
}
