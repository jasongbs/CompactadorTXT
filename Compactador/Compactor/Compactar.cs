using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Compactador.Compactor
{
    class Compactar
    {
        public void Compacta(string text, string compactado)
        {
            bool primeiro=true;
            string[] descompactado = File.ReadAllLines(text, Encoding.UTF7);
         
            string textonovo="";

            foreach (string line in descompactado)
            {
                if (primeiro==true)
                {
                    textonovo += line;
                    primeiro = false;
                }else
                textonovo +=  line;
            }
            descompactado = null;
            string textNovo = "", dicionario = ""; ;
            string[] palavras = textonovo.Split();
            var existe = new List<string> { };
            int posicao;

            /*Verifica se a palavra existe no dicionario, se não existir ele insere a mesma na area de dicionario
            e depois coloca a posicao do dicionário na area de textos compactados, caso contrario só coloca a posicao do dicionario.
            */
            foreach (string line in palavras)
            {
                if (existe.IndexOf(line) == -1)//verifica se a palavra não existe no dicionario
                {
                    existe.Add(line);//adiciona a palavra no dicionário
                    dicionario = string.Concat(dicionario + line + " ");//atualiza o dicionário
                }
                if (existe.Equals("´"))
                {
                    textNovo = string.Concat(textNovo+ " ");
                }
                posicao = existe.IndexOf(line);//verifica a posição da palavra
                textNovo = string.Concat(textNovo + posicao + " ");//E insere a posição na area de texto compactado
            }
            //Cria arquivo txt com o texto compactado
            File.WriteAllText(compactado, string.Concat(dicionario + "| " + textNovo));

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
    }
}
