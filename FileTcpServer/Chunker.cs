using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileTcpServer
{
    class Chunker
    {
        static int count = 0;

        public static void FileInput()
        {
            StreamWriter sw = new StreamWriter(@"C:\Files\dictionary_chunk.txt", true);
            using (StreamReader sr = new StreamReader(@"C:\Files\webster-dictionary.txt"))
            {
                for (int i = count; i <= count + 1000; i++)
                {
                    sw.Write(sr.ReadLine());
                    sw.Flush();
                    
                }
                count = count + 1000;
                sw.Close();
            }
        }
    }
}
