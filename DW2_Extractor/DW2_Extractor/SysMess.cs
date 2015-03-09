using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DW2_Extractor
{
    public class SysMess
    {
        private List<string> Messages;
        private List<byte[]> BlocksFile;
        private TableReader ParserTable;

        private SysMess()
        {
            Messages = new List<string>();
            BlocksFile = new List<byte[]>();
        }

        public static SysMess OpenBin(string path, TableReader table)
        {
            SysMess result = new SysMess() { ParserTable = table };
            result.readBin(path);
            return result;
        }

        public static SysMess OpenTxt(string path, TableReader table)
        {
            SysMess result = new SysMess() { ParserTable = table };
            result.readTxt(path);
            return result;
        }

        public void SaveBin(string path)
        {
            int[] pointers = generatePointersTxt();
            BinaryWriter fw = new BinaryWriter(File.Create(path));
            
            foreach (int p in pointers)
            {
                fw.Write(p);
            }
            
            foreach (byte[] block in BlocksFile)
            {
                fw.Write(block, 0, block.Length);
            }
            fw.Close();
            Console.WriteLine("File '{0}' was created succesfully.", path);
        }

        public void SaveTxt(string path)
        {
            StreamWriter fw = new StreamWriter(File.Create(path), Encoding.UTF8);
            for (int i = 0; i < Messages.Count; i++)
            {
                fw.WriteLine(string.Format("-- Message {0:000} --", i));
                fw.WriteLine(Messages[i]);
                fw.WriteLine();
            }
            fw.Close();
            Console.WriteLine("File '{0}' was created succesfully.", path);
        }

        #region BIN
        private void readBin(string path)
        {
            if (!File.Exists(path))
                return;
            // Tabla de punteros
            int[] pointers = generatePointersBin(path);
            
            // Abrimos el fichero y nos vamos al punto donde acaba la tabla de punteros
            FileStream fr = File.OpenRead(path);
            fr.Seek(pointers[0], SeekOrigin.Begin);
            
            // Leemos las lineas
            for (int i = 0; i < pointers.Length-1; i++)
            {
                byte[] block = new byte[pointers[i + 1] - pointers[i]];
                fr.Read(block, 0, block.Length);
                BlocksFile.Add(block);
                string blockMess = Parse(block);
                Messages.Add(blockMess);
            }
            fr.Close();
        }

        private int[] generatePointersBin(string path)
        {
            BinaryReader fr = new BinaryReader(File.OpenRead(path), Encoding.UTF8);
            int firstPointer = fr.ReadInt32();
            int[] pointers = new int[firstPointer / 4 + 1];
            pointers[0] = firstPointer;

            for (int i = 1; i < pointers.Length-1; i++)
            {
                pointers[i] = fr.ReadInt32();
            }

            pointers[pointers.Length - 1] = (int)fr.BaseStream.Length;

            fr.Close();
            return pointers;
        }

        private string Parse(byte[] block)
        {
            string result = "";
            for (int i = 0; i < block.Length; i++)
            {
                if (string.IsNullOrEmpty(ParserTable.GetValue(block[i])))
                {
                    int key = block[i];
                    if (i < block.Length-1)
                        key = (key << 8) + block[i + 1];
                    if (string.IsNullOrEmpty(ParserTable.GetValue(key)))
                        result += "[" + block[i] + "]";
                    else
                    {
                        result += ParserTable.GetValue(key);
                        i++;
                    }
                }
                else
                {
                    string value = ParserTable.GetValue(block[i]);
                    if (value == "<end>")
                        return result;
                    result += value;
                }
            }
            return result;
        }
        #endregion

        #region TXT
        private void readTxt(string path)
        {
            if (!File.Exists(path))
                return;
            List<string> messages = File.ReadAllLines(path, Encoding.UTF8).Where(w => (!w.Contains("-- Message"))).ToList();
            for (int i = 0; i < messages.Count; i+=2)
            {
                Messages.Add(messages[i]);
            }
            foreach (var message in Messages)
            {
                byte[] block = Parse(message);
                BlocksFile.Add(block);
            }
        }

        private int[] generatePointersTxt()
        {
            int[] result = new int[Messages.Count];
            result[0] = result.Length * 4;
            for (int i = 1; i < result.Length; i++)
            {
                result[i] = result[i - 1] + BlocksFile[i - 1].Length;
            }
            return result;
        }

        private byte[] Parse(string message)
        {
            List<byte> result = new List<byte>();

            for (int i = 0; i < message.Length; i++)
            {
                if (message[i] == '[')
                {
                    int indice = message.IndexOf(']', i);
                    string value = message.Substring(i, indice - i);
                    int n = int.Parse(value.Replace("[","").Replace("]",""));
                    result.Add((byte)n);
                    i += value.Length;
                }
                else if (message[i] == '<')
                {
                    int indice = message.IndexOf('>', i);
                    string value = message.Substring(i, indice - i);
                    int n = ParserTable.GetKey(value + ">");
                    if (n > 255)
                    {
                        byte b = (byte)(n / 256);
                        result.Add(b);
                        b = (byte)(n % 256);
                        result.Add(b);
                    }
                    else
                    {
                        byte b = (byte)(n % 256);
                        result.Add(b);
                    }
                    i += value.Length;
                }
                else
                {
                    int n = ParserTable.GetKey(message[i] + "");
                    byte b = (byte)(n % 256);
                    if (n > 255)
                    {
                        result.Add(b);
                        b = (byte)(n / 256);
                    }
                    result.Add(b);
                }
            }

            normalizeBlock(result);

            return result.ToArray();
        }

        private void normalizeBlock(List<byte> block)
        {
            block.Add(255);
            while (block.Count % 4 != 0)
            {
                block.Add(0);
            }
        }
        #endregion
    }
}
