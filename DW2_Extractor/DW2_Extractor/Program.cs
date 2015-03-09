using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DW2_Extractor
{
    class Program
    {
        [STAThreadAttribute]
        static void Main(string[] args)
        {
            new DW2_Extractor().ShowDialog();
            ////TableReader table_original = TableReader.Create("Tabla_original.tbl");
            //TableReader table_mod = TableReader.Create("Tabla.tbl");

            ////SysMess mess = SysMess.OpenBin("SYS_MESS.BIN", table_mod);
            ////mess.SaveTxt("SYS_MESS.txt");
            ////SysMess mess2 = SysMess.OpenTxt("SYS_MESS.txt", table_mod);
            ////mess2.SaveBin("SYS_MESS2.BIN");

            ////ItemData items = ItemData.OpenBin("ITEMDATA.BIN", table_mod);
            ////items.SaveTxt("ITEMDATA.txt");
            ////items.OpenTxt("ITEMDATA.txt");
            ////items.SaveBin("ITEMDATA2.BIN");

            //var messTest = "MESS6901";
            //DungMess mess = DungMess.OpenBin(messTest + ".BIN", table_mod);
            ////mess.SaveTxt(messTest + ".txt");
            //mess.OpenTxt(messTest + ".txt");
            //mess.SaveBin(messTest + "_2.BIN");
        }
    }
}
