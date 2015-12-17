﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    class proga
    {
        string line;
        string filename;
        string result = "";
        public void main()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                System.IO.StreamReader sr = new
                   System.IO.StreamReader(openFileDialog1.FileName);
                filename = openFileDialog1.FileName;
                sr.Close();
            }
            else
            {
                return;
            }

            HashSet<string> uzers = new HashSet<string>();
            System.IO.StreamReader file1 = new System.IO.StreamReader(filename);
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
                result += "\r\n" + i + "\r\n" + "\r\n";
                Poisk(i);
            }

            System.IO.File.WriteAllText(@"C:\Users\Ragnareg\Desktop\ShortLog.txt", result);            
            file1.Close();
        }

        void Poisk(string Autor)
        {
            System.IO.StreamReader file1 = new System.IO.StreamReader(@"C:\Users\Ragnareg\Desktop\a.txt");
            int counter = 0;
            while ((line = file1.ReadLine()) != null)
            {
                if (line.IndexOf("commit") == 0)
                {
                    counter = 0;
                }
                if (line.IndexOf(Autor) == 0)
                {
                    counter = 1;
                }
                else
                {
                    if (counter == 1)
                    {
                        result += line + "\r\n";
                    }
                }
            }
            file1.Close();
        }

        /// <summary>
        /// Метод обработки исключений и очистки мусора.
        /// </summary>
        /// <param name="obj">Получаемый объект</param>
        private void ReleaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Unable to release the object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}
