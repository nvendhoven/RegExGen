using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegExGen
{
    class FileIO
    {
        public static void saveFile(string path, string fileContent)
        {
            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.Write(fileContent);
                }
            }
            else
            {
                throw new SyntaxErrorException("FileIO error: file at: {" + path + "} already exists");
            }
        }

        public static string loadFile(string path)
        {
            string output = "";
            if (File.Exists(path))
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    string s;
                    while ((s = sr.ReadLine()) != null)
                    {
                        output += s;
                    }
                }
            }
            else
            {
                throw new SyntaxErrorException("FileIO error: file at: {" + path +"} doesn't exists");
            }

            return output;
        }

        public static List<RegExp> loadRegExTrees(string path)
        {
            List<RegExp> regExes = new List<RegExp>();

            string output = "";
            if (File.Exists(path))
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    string s;
                    while ((s = sr.ReadLine()) != null)
                    {
                        regExes.Add(RegExParser.GetRegEx(s));
                    }
                }
            }
            else
            {
                throw new SyntaxErrorException("FileIO error: file at: {" + path + "} doesn't exists");
            }

            return regExes;
        }
    }
}
