using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Compactador.Services
{
    class DirDicionario
    {
        public string PathDirData()
        {
            string path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + @"/Data/Dicionario.txt";
            path = path.Remove(0, 6);
            return path;
        }
    }
}
