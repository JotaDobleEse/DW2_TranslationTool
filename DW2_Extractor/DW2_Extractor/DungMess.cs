using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DW2_Extractor
{
    public class DungMess
    {
        private List<string> Dialogs;
        private List<byte[]> BlocksFile;
        private List<int[]> PointersPreData;
        private TableReader ParserTable;

        private DungMess()
        {
            Dialogs = new List<string>();
            BlocksFile = new List<byte[]>();
            PointersPreData = new List<int[]>();
        }

        public static DungMess OpenBin(string path, TableReader table)
        {
            DungMess result = new DungMess() { ParserTable = table };
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
            int length = 12;
            foreach (byte[] block in BlocksFile)
            {
                length += block.Length;
            }

            // Creamos el ficheros
            BinaryWriter fw = new BinaryWriter(File.Create(path));
            fw.Write(length);
            fw.Write(pointers[pointers.Length - 2]);
            fw.Write(pointers[pointers.Length - 1]);

            // Escribimos los items
            foreach (byte[] block in BlocksFile)
            {
                fw.Write(block, 0, block.Length);
            }

            // Escribimos los punteros y los metadatos
            int n = 0;
            for (int pi = 0; pi < pointers.Length - 2; pi++)
            {
                foreach (int data in PointersPreData[n])
                {
                    fw.Write(data);
                }
                n++;
                fw.Write(pointers[pi]);
                for (int i = 0; i < 5; i++)
                {
                    fw.Write((int)0);
                }
            }

            for (int i = 0; i < 11; i++)
            {
                fw.Write((int)0);
            }

            fw.Close();
            Console.WriteLine("File '{0}' was created succesfully.", path);
        }

        public void SaveTxt(string path)
        {
            StreamWriter fw = new StreamWriter(File.Create(path), Encoding.UTF8);
            try
            {
                for (int i = 0; i < Dialogs.Count; i++)
                {
                    fw.WriteLine(string.Format("-- Dialog {0:000} --", i));
                    fw.WriteLine(normalizeString(Dialogs[i]));
                    fw.WriteLine();
                }
            }
            catch (Exception e)
            {
                fw.Close();
                File.Delete(path);
                Console.WriteLine("File '{0}' wasn't created.", path);
                return;
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
                Dialogs.Add(blockMess.Replace("<br>","\n").Replace("<Window>","\n<Window>\n"));
            }
            fr.Close();
        }

        private int[] generatePointersBin(string path)
        {
            List<int> result = new List<int>();
            BinaryReader fr = new BinaryReader(File.OpenRead(path), Encoding.UTF8);
            int inicioPunteros = fr.ReadInt32();
            int p1 = fr.ReadInt32();
            int p2 = fr.ReadInt32();
            fr.Read(new byte[inicioPunteros - 12], 0, inicioPunteros - 12);
            int[] prePointer = new int[5];
            while ((prePointer[0] = fr.ReadInt32()) > 0)
            {
                for (int i = 1; i < 5; i++)
                {
                    prePointer[i] = fr.ReadInt32();
                }
                PointersPreData.Add(prePointer);
                result.Add(fr.ReadInt32());
                for (int i = 0; i < 5; i++)
                {
                    fr.ReadInt32();
                }
                prePointer = new int[5];
            }
            result.Add(p1);
            result.Add(p2);
            result.Add(inicioPunteros);
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
                    //if (value == "<end>")
                    //    return result;
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
            Dialogs.Clear();
            BlocksFile.Clear();
            List<string> items = File.ReadAllLines(path, Encoding.UTF8).Where(w => (!w.Contains("-- Dialog"))).ToList();

            string line = "";
            foreach (var item in items)
            {
                if (string.IsNullOrEmpty(item))
                {
                    line = line.Substring(0, line.Length - 4);
                    Dialogs.Add(line.Replace("<br><Window><br>", "<Window>"));
                    line = "";
                }
                else
                {
                    line += item + "<br>";
                }
            }
            foreach (var item in Dialogs)
            {
                byte[] block = Parse(item);
                BlocksFile.Add(block);
            }
        }

        private int[] generatePointersTxt()
        {
            // TODO Generar los punteros en base al BIN original
            int[] result = new int[Dialogs.Count];
            result[0] = 12;
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
                        Console.WriteLine("Error, character '{0}' not exist.", message[i]);
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
            //block.Add(255);
            while (block.Count % 4 != 0)
            {
                block.Add(0);
            }
        }

        private string normalizeString(string dialog)
        {
            while (dialog[dialog.Length - 1] == '0')
            {
                dialog = dialog.Substring(0, dialog.Length - 1);
            }
            return dialog;
        }
        #endregion
    }


}
