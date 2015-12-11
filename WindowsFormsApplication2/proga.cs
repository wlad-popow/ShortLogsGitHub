using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    class proga
    {
        string line;
        string result = "";
        public void main()
        {
            HashSet<string> uzers = new HashSet<string>();
            System.IO.StreamReader file1 = new System.IO.StreamReader(@"C:\Users\Ragnareg\Desktop\Новая папка (7)\a.txt");
            while ((line = file1.ReadLine()) != null)
            {
                if (line.IndexOf("Author:") == 0)
                {
                    uzers.Add(line);
                }
            }

            System.Console.WriteLine(uzers.Count);
            foreach (string i in uzers)
            {
                Poisk(i);
            }

            System.IO.File.WriteAllText(@"C:\Users\Ragnareg\Desktop\Новая папка (7)\ShortLog.txt", result);            
            file1.Close();
        }

        void Poisk(string Autor)
        {
            // открыть файл1
            System.IO.StreamReader file1 = new System.IO.StreamReader(@"C:\Users\Ragnareg\Desktop\Новая папка (7)\a.txt");
            int counter = 0;
            while ((line = file1.ReadLine()) != null)
            {
                if (line.IndexOf(Autor) == 0)
                {
                    counter = 1;
                }
                if (line.IndexOf("commit") == 0)
                {
                    counter = 0;
                }
                if (counter == 1)
                {
                    result += line + "\r\n";
                }
            }

        }


    }
}
