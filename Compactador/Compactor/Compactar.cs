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

            // string dirDicionario = File.ReadAllText(new DirDicionario().PathDirData(), Encoding.UTF8);
            string textonovo = "", textNovo = "", dicionario = "";

            var existe = new List<string> { "`"};
            int posicao;

            foreach (string line in descompactado)
            {
                textonovo += line + " ´ ";
            }
            string[] palavras = textonovo.Split(" ");
            /*Verifica se a palavra existe no dicionario, se não existir ele insere a mesma na area de dicionario
            e depois coloca a posicao do dicionário na area de textos compactados, caso contrario só coloca a posicao do dicionario.
            */
            foreach (string line in palavras)
            {
                if (existe.IndexOf(line) == -1)//verifica se a palavra não existe no dicionario
                {
                    if (line.Contains(','))
                    {
                        string[] separa = line.Split(',');
                        if (existe.IndexOf(",") >= 0)
                        {
                            existe.Add(separa[0]);
                        }
                        else if (existe.IndexOf(",") == -1)
                        {
                            existe.Add(separa[0]);
                            existe.Add(",");
                        }
                    }
                    else if (line.Contains('.'))
                    {
                        string[] separa = line.Split('.');
                        if (existe.IndexOf(".") >= 0)
                        {
                            existe.Add(separa[0]);
                        }
                        else if (existe.IndexOf(".") == -1)
                        {
                            existe.Add(separa[0]);
                            existe.Add(".");
                        }
                    }
                    else
                        existe.Add(line);//adiciona a palavra no dicionário
                    //dicionario = dicionario.OrderBy().ToList();
                    existe = existe.OrderBy(dicionario => dicionario).ToList();


                }
            }

            foreach (string line in existe)
                dicionario = string.Concat(dicionario + line + " ");//atualiza o dicionário,

            foreach (string line in palavras)
            {
                if (existe.Equals("´"))
                {
                    textNovo = string.Concat(textNovo + "\n ");
                }
                if (line.IndexOf(",") >= 0 || line.IndexOf(".") >= 0)
                    textNovo = Verifica(line, existe, textNovo);
                else
                {
                    posicao = existe.IndexOf(line);//verifica a posição da palavra
                    textNovo = string.Concat(textNovo + posicao + " ");//E insere a posição na area de texto compactado
                }
            }
            //Cria arquivo txt com o texto compactado
            File.WriteAllText(compactado, textNovo);

            //biblioteca
            string caminho = new DirDicionario().PathDirData();
//modo 1
            File.WriteAllText(caminho, dicionario);
//modo 2
           /* StreamWriter s = File.AppendText(caminho);
            s.WriteLine(dicionario);
            s.Close();*/

            FileStream original = new FileStream(text, FileMode.Open);
            FileStream compacto = new FileStream(compactado, FileMode.Open);

            //Verifica se arquivo compactado é maior que o original
            if (original.Length < compacto.Length)
            {
                Console.WriteLine(" ARQUIVO JÁ É MUITO PEQUENO", Encoding.UTF7);
                original.Close();
                compacto.Close();
                File.WriteAllText(compactado, textonovo);
            }
            else
            {
                Console.WriteLine("\n    -- COMPACTADO COM SUCESSO! --");
                original.Close();
                compacto.Close();
            }
        }

        private string Verifica(string line, List<string> existe, string textNovo)
        {
            int posicao;
            if (line.Contains(','))
            {
                string[] separa = line.Split(',');
                if (existe.IndexOf(",") >= 1)
                {
                    posicao = existe.IndexOf(separa[0]);//verifica a posição da palavra
                    textNovo = string.Concat(textNovo + posicao + " ");//E insere a posição na area de texto compactado
                    return textNovo;
                }
                else if (existe.IndexOf(",") == -1)
                {
                    posicao = existe.IndexOf(separa[0]);//verifica a posição da palavra
                    textNovo = string.Concat(textNovo + posicao + " ");//E insere a posição na area de texto compactado
                    posicao = existe.IndexOf(",");//verifica a posição da palavra
                    textNovo = string.Concat(textNovo + posicao + " ");//E insere a posição na area de texto compactado
                    return textNovo;
                }
            }
            else if (line.Contains('.'))
            {
                string[] separa = line.Split('.');
                if (existe.IndexOf(".") >= 0)
                {
                     posicao = existe.IndexOf(separa[0]);//verifica a posição da palavra
                    textNovo = string.Concat(textNovo + posicao + " ");//E insere a posição na area de texto compactado
                    return (textNovo);
                }
                else if (existe.IndexOf(".") == -1)
                {
                     posicao = existe.IndexOf(separa[0]);//verifica a posição da palavra
                    textNovo = string.Concat(textNovo + posicao + " ");//E insere a posição na area de texto compactado
                    posicao = existe.IndexOf(".");//verifica a posição da palavra
                    textNovo = string.Concat(textNovo + posicao + " ");//E insere a posição na area de texto compactado
                    return (textNovo);
                }
            }
            return textNovo;
        }
    }
}
