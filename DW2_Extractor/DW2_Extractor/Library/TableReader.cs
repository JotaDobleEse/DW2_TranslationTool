using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DW2_Extractor
{
    public class TableReader
    {
        private Dictionary<int, string> Table;

        /// <summary>
        /// Crea la tabla de transformación leyendola desde un fichero.
        /// </summary>
        /// <param name="path">Ruta del fichero</param>
        /// <returns></returns>
        public static TableReader Create(string path)
        {
            TableReader table = new TableReader();
            table.read(path);
            return table;
        }

        public string GetValue(int key)
        {
            if (!Table.ContainsKey(key))
                return "";
            return Table[key];
        }

        public int GetKey(string value)
        {
            if (!Table.ContainsValue(value))
            {
                return -1;
            }
            return Table.Keys.First(f => Table[f] == value);
        }

        private TableReader()
        {
            Table = new Dictionary<int, string>();
        }

        private void read(string path)
        {
            if (!File.Exists(path))
                return;
            string[] lines = File.ReadAllLines(path, Encoding.UTF8);
            foreach (var line in lines)
            {
                string[] values = line.Split('=');
                Table.Add(Parse(values[0].ToCharArray()), values[1]);
            }
        }

        private int Parse(char[] value)
        {
            int result;
            result = Parse(value[0]) << 4;
            result += Parse(value[1]);
            if (value.Length == 4)
            {
                result = result << 8;
                result += Parse(value[2]) << 4;
                result += Parse(value[3]);
            }
            return result;
        }

        private byte Parse(char value)
        {
            byte result = 0;
            switch (value)
            {
                case '0':
                    result = 0;
                    break;
                case '1':
                    result = 1;
                    break;
                case '2':
                    result = 2;
                    break;
                case '3':
                    result = 3;
                    break;
                case '4':
                    result = 4;
                    break;
                case '5':
                    result = 5;
                    break;
                case '6':
                    result = 6;
                    break;
                case '7':
                    result = 7;
                    break;
                case '8':
                    result = 8;
                    break;
                case '9':
                    result = 9;
                    break;
                case 'A':
                    result = 10;
                    break;
                case 'B':
                    result = 11;
                    break;
                case 'C':
                    result = 12;
                    break;
                case 'D':
                    result = 13;
                    break;
                case 'E':
                    result = 14;
                    break;
                case 'F':
                    result = 15;
                    break;
            }
            return result;
        }

    }
}
