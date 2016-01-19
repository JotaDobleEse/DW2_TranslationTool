using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DW2_Extractor
{
    public class ItemData
    {
        private List<string> Items;
        private List<byte[]> BlocksFile;
        private List<long> PointersPreData;
        private TableReader ParserTable;

        private ItemData()
        {
            Items = new List<string>();
            BlocksFile = new List<byte[]>();
            PointersPreData = new List<long>();
        }

        public static ItemData OpenBin(string path, TableReader table)
        {
            ItemData result = new ItemData() { ParserTable = table };
            result.readBin(path);
            return result;
        }

        public void OpenTxt(string path)
        {
            readTxt(path);
            generatePointersTxt();
        }

        public void SaveBin(string path)
        {
            int[] pointers = generatePointersTxt();
            // Contamos la longitud del fichero hasta el inicio de punteros
            int length = 4;
            foreach (byte[] block in BlocksFile)
            {
                length += block.Length;
            }

            // Creamos el ficheros
            BinaryWriter fw = new BinaryWriter(File.Create(path));
            fw.Write(length);

            // Escribimos los items
            foreach (byte[] block in BlocksFile)
            {
                fw.Write(block, 0, block.Length);
            }

            // Escribimos los punteros y los metadatos
            bool print = true;
            int n = 0;
            foreach (int p in pointers)
            {
                if (print)
                {
                    fw.Write(PointersPreData[n]);
                    n++;
                }
                print = !print;
                fw.Write(p);
            }

            // Escribimos los metadatos faltantes
            for (int i = n; i < PointersPreData.Count; i++)
            {
                fw.Write(PointersPreData[i]);
            }

            fw.Close();
            Console.WriteLine("File '{0}' was created succesfully.", path);
        }

        public void SaveTxt(string path)
        {
            StreamWriter fw = new StreamWriter(File.Create(path), Encoding.UTF8);
            for (int i = 0; i < Items.Count; i++)
            {
                fw.WriteLine(string.Format("-- Item {0:000} --", i));
                fw.WriteLine(Items[i]);
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
            for (int i = 0; i < pointers.Length - 1; i++)
            {
                byte[] block = new byte[pointers[i + 1] - pointers[i]];
                fr.Read(block, 0, block.Length);
                BlocksFile.Add(block);
                string blockMess = Parse(block);
                Items.Add(blockMess);
            }
            fr.Close();
        }

        private int[] generatePointersBin(string path)
        {
            List<int> result = new List<int>();
            BinaryReader fr = new BinaryReader(File.OpenRead(path), Encoding.UTF8);
            int inicioPunteros = fr.ReadInt32();
            fr.Read(new byte[inicioPunteros - 4], 0, inicioPunteros - 4);
            long prePointer = 0;
            while ((prePointer = fr.ReadInt64()) > 0)
            {
                PointersPreData.Add(prePointer);
                result.Add(fr.ReadInt32());
                result.Add(fr.ReadInt32());
            }
            result.Add(inicioPunteros);
            PointersPreData.Add(0);
            PointersPreData.Add(0);
            fr.Close();
            return result.ToArray();
        }

        private string Parse(byte[] block)
        {
            string result = "";
            for (int i = 0; i < block.Length; i++)
            {
                if (string.IsNullOrEmpty(ParserTable.GetValue(block[i])))
                {
                    int key = block[i];
                    if (i < block.Length - 1)
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
            Items.Clear();
            BlocksFile.Clear();
            List<string> items = File.ReadAllLines(path, Encoding.UTF8).Where(w => (!w.Contains("-- Item"))).ToList();
            for (int i = 0; i < items.Count; i += 2)
            {
                Items.Add(items[i]);
            }
            foreach (var item in Items)
            {
                byte[] block = Parse(item);
                BlocksFile.Add(block);
            }
        }

        private int[] generatePointersTxt()
        {
            // TODO Generar los punteros en base al BIN original
            int[] result = new int[Items.Count];
            result[0] = 4;
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
                    int n = int.Parse(value.Replace("[", "").Replace("]", ""));
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
                    if (n < 0)
                    {
                        Console.WriteLine("Error, character not exist.");
                    }
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
