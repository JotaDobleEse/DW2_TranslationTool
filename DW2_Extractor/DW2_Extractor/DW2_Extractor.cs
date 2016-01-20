using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace DW2_Extractor
{
    public partial class DW2_Extractor : Form
    {
        public TableReader Table { get; set; }
        public string FilenameBin { get; set; }
        public DW2_Extractor()
        {
            InitializeComponent();
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "Todos los ficheros|*.*";
            folderBrowserDialog1.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
        }

        #region DUNGMESS
        public DungMess Dialog { get; set; }

        private void openBinMess_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "Binary file|*.BIN|Todos los ficheros|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FilenameBin = openFileDialog1.FileName.Substring(openFileDialog1.FileName.LastIndexOf("\\")+1);
                Dialog = DungMess.OpenBin(openFileDialog1.FileName, Table);
                openTxtMess.Enabled = true;
                saveTxtMess.Enabled = true;
            }
        }

        private void openTxtMess_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "Plain text file|*.txt|Todos los ficheros|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Dialog.OpenTxt(openFileDialog1.FileName);
                saveBinMess.Enabled = true;
            }
        }

        private void saveBinMess_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "";
            saveFileDialog1.Filter = "Binary file|*.BIN";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Dialog.SaveBin(saveFileDialog1.FileName);
                try
                {
                    string filename = saveFileDialog1.FileName.Substring(saveFileDialog1.FileName.LastIndexOf("\\")+1);
                    string pathWithoutFile = saveFileDialog1.FileName.Replace(filename, "");
                    File.WriteAllText(pathWithoutFile + "reinsert_" + FilenameBin.Replace(".BIN", ".bat"), string.Format(DungMess.COMMAND, FilenameBin, filename, dw2Name.Text));
                } catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void saveTxtMess_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "";
            saveFileDialog1.Filter = "Plain text file|*.txt";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Dialog.SaveTxt(saveFileDialog1.FileName);
            }
        }

        private void extractAllTxtFilesMess_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string[] files = Directory.GetFiles(folderBrowserDialog1.SelectedPath, "MESS*.BIN", SearchOption.TopDirectoryOnly);
                foreach (string file in files)
                {
                    DungMess mess = DungMess.OpenBin(file, Table);
                    mess.SaveTxt(file.Replace(".BIN", ".txt"));
                }
            }
        }

        private void generateAllBinDungMess_Click(object sender, EventArgs e)
        {
            string[] binSrcFiles, txtFiles;
            string binDstFolder = "";
            MessageBox.Show("Select BIN source folder");
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                binSrcFiles = Directory.GetFiles(folderBrowserDialog1.SelectedPath, "MESS*.BIN", SearchOption.TopDirectoryOnly);
            }
            else
                return;
            MessageBox.Show("Select TXT source folder");
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtFiles = Directory.GetFiles(folderBrowserDialog1.SelectedPath, "MESS*.txt", SearchOption.TopDirectoryOnly);
            }
            else
                return;
            MessageBox.Show("Select BIN destination folder");
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                binDstFolder = folderBrowserDialog1.SelectedPath;
            }

            binSrcFiles = binSrcFiles.Where(w => txtFiles.Any(a => a.Contains(w.Substring(w.LastIndexOf('\\') + 1, w.LastIndexOf('.') - w.LastIndexOf('\\'))))).ToArray();

            List<string> commands = new List<string>();
            foreach (string file in binSrcFiles)
            {
                DungMess mess = DungMess.OpenBin(file, Table);
                string binFile = file.Substring(file.LastIndexOf('\\'), file.Length - file.LastIndexOf('\\'));
                string txtFile = txtFiles.First(a => a.Contains(file.Substring(file.LastIndexOf('\\') + 1, file.LastIndexOf('.') - file.LastIndexOf('\\'))));
                mess.OpenTxt(txtFile);
                mess.SaveBin(binDstFolder + binFile);
                commands.Add(string.Format(DungMess.COMMAND, binFile, txtFile.Substring(file.LastIndexOf('\\') + 1, file.LastIndexOf('.') - file.LastIndexOf('\\')), dw2Name.Text));
            }

            try
            {
                File.WriteAllLines(binDstFolder + "reinsert_DUNG.bat", commands);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        #endregion

        #region CITYMESS
        public CityMess CityDialog { get; set; }

        private void openBinCityMess_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "Binary file|*.BIN|Todos los ficheros|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FilenameBin = openFileDialog1.FileName.Substring(openFileDialog1.FileName.LastIndexOf("\\") + 1);
                CityDialog = CityMess.OpenBin(openFileDialog1.FileName, Table);
                openTxtCityMess.Enabled = true;
                saveTxtCityMess.Enabled = true;
            }
        }

        private void openTxtCityMess_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "Plain text file|*.txt|Todos los ficheros|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                CityDialog.OpenTxt(openFileDialog1.FileName);
                saveBinCityMess.Enabled = true;
            }
        }

        private void saveBinCityMess_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "";
            saveFileDialog1.Filter = "Binary file|*.BIN";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                CityDialog.SaveBin(saveFileDialog1.FileName);
                try
                {
                    string filename = saveFileDialog1.FileName.Substring(saveFileDialog1.FileName.LastIndexOf("\\")+1);
                    string pathWithoutFile = saveFileDialog1.FileName.Replace(filename, "");
                    File.WriteAllText(pathWithoutFile + "reinsert_" + FilenameBin.Replace(".BIN", ".bat"), string.Format(CityMess.COMMAND, FilenameBin, filename, dw2Name.Text));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void saveTxtCityMess_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "";
            saveFileDialog1.Filter = "Plain text file|*.txt";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                CityDialog.SaveTxt(saveFileDialog1.FileName);
            }
        }

        private void extractAllTxtFilesCityMess_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string[] files = Directory.GetFiles(folderBrowserDialog1.SelectedPath, "MESS*.BIN", SearchOption.TopDirectoryOnly);
                foreach (string file in files)
                {
                    CityMess mess = CityMess.OpenBin(file, Table);
                    mess.SaveTxt(file.Replace(".BIN", ".txt"));
                }
            }
        }

        private void generateAllBinCityMess_Click(object sender, EventArgs e)
        {
            string[] binSrcFiles, txtFiles;
            string binDstFolder = "";
            MessageBox.Show("Select BIN source folder");
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                binSrcFiles = Directory.GetFiles(folderBrowserDialog1.SelectedPath, "MESS*.BIN", SearchOption.TopDirectoryOnly);
            }
            else
                return;
            MessageBox.Show("Select TXT source folder");
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtFiles = Directory.GetFiles(folderBrowserDialog1.SelectedPath, "MESS*.txt", SearchOption.TopDirectoryOnly);
            }
            else
                return;
            MessageBox.Show("Select BIN destination folder");
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                binDstFolder = folderBrowserDialog1.SelectedPath;
            }

            binSrcFiles = binSrcFiles.Where(w => txtFiles.Any(a => a.Contains(w.Substring(w.LastIndexOf('\\') + 1, w.LastIndexOf('.') - w.LastIndexOf('\\'))))).ToArray();

            //foreach (string file in binSrcFiles)
            //{
            //    CityMess mess = CityMess.OpenBin(file, Table);
            //    mess.OpenTxt(txtFiles.First(a => a.Contains(file.Substring(file.LastIndexOf('\\') + 1, file.LastIndexOf('.') - file.LastIndexOf('\\')))));
            //    mess.SaveBin(binDstFolder + file.Substring(file.LastIndexOf('\\'), file.Length - file.LastIndexOf('\\')));
            //}

            List<string> commands = new List<string>();
            foreach (string file in binSrcFiles)
            {
                CityMess mess = CityMess.OpenBin(file, Table);
                string binFile = file.Substring(file.LastIndexOf('\\'), file.Length - file.LastIndexOf('\\'));
                string txtFile = txtFiles.First(a => a.Contains(file.Substring(file.LastIndexOf('\\') + 1, file.LastIndexOf('.') - file.LastIndexOf('\\'))));
                mess.OpenTxt(txtFile);
                mess.SaveBin(binDstFolder + binFile);
                commands.Add(string.Format(CityMess.COMMAND, binFile, txtFile.Substring(file.LastIndexOf('\\') + 1, file.LastIndexOf('.') - file.LastIndexOf('\\')), dw2Name));
            }

            try
            {
                File.WriteAllLines(binDstFolder + "reinsert_CITY.bat", commands);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        #endregion

        #region ITEMS
        public ItemData Items { get; set; }

        private void openBinItems_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "Binary file|*.BIN|Todos los ficheros|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Items = ItemData.OpenBin(openFileDialog1.FileName, Table);
                openTxtItems.Enabled = true;
                saveTxtItems.Enabled = true;
            }
        }

        private void openTxtItems_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "Plain text file|*.txt|Todos los ficheros|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Items.OpenTxt(openFileDialog1.FileName);
                saveBinItems.Enabled = true;
            }
        }

        private void saveBinItems_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "";
            saveFileDialog1.Filter = "Binary file|*.BIN";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Items.SaveBin(saveFileDialog1.FileName);
            }
        }

        private void saveTxtItems_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "";
            saveFileDialog1.Filter = "Plain text file|*.txt";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Items.SaveTxt(saveFileDialog1.FileName);
            }
        }

        #endregion

        #region SYSMESS
        public SysMess SystemMess { get; set; }

        private void openBinSystemMess_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "Binary file|*.BIN|Todos los ficheros|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                SystemMess = SysMess.OpenBin(openFileDialog1.FileName, Table);
                openTxtSysMess.Enabled = true;
                saveTxtSysMess.Enabled = true;
            }
        }

        private void openTxtSystemMess_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "Plain text file|*.txt|Todos los ficheros|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                SystemMess = SysMess.OpenTxt(openFileDialog1.FileName, Table);
                saveBinSysMess.Enabled = true;
            }
        }

        private void saveBinSystemMess_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "";
            saveFileDialog1.Filter = "Binary file|*.BIN";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                SystemMess.SaveBin(saveFileDialog1.FileName);
            }
        }

        private void saveTxtSystemMess_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "";
            saveFileDialog1.Filter = "Plain text file|*.txt";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                SystemMess.SaveTxt(saveFileDialog1.FileName);
            }
        }
        #endregion

        private void openTblInsertion_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "Tabla de caracteres|*.tbl|Plain text file|*.txt|Todos los ficheros|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Table = TableReader.Create(openFileDialog1.FileName);
            }
            if (Table != null)
            {
                openBinMess.Enabled = true;
                openBinCityMess.Enabled = true;
                openBinItems.Enabled = true;
                openBinSysMess.Enabled = true;
                openTxtSysMess.Enabled = true;
                extractAllTxtFilesMess.Enabled = true;
                extractAllTxtCityMess.Enabled = true;
                generateAllBinDungMess.Enabled = true;
            }
        }

        private void openTblExtraction_Click(object sender, EventArgs e)
        {
            //if (openFileDialog1.ShowDialog() == DialogResult.OK)
            //{
            //    Extraction = TableReader.Create(openFileDialog1.FileName);
            //}
            //if (Insertion != null && Extraction != null)
            //{
            //    openBinMess.Enabled = true;
            //}
        }

        private void helpMess_Click(object sender, EventArgs e)
        {
            MessageBox.Show("To extract file:\n\t- Open characters table\n\t- Open BIN file\n\t- Save TXT file\n\nTo create BIN file:\n\t- Open characters table\n\t- Open BIN file\n\t- Open TXT file\n\t- Save BIN file", "Help MESS*.BIN files");
        }

        private void helpItems_Click(object sender, EventArgs e)
        {
            MessageBox.Show("To extract file:\n\t- Open characters table\n\t- Open BIN file\n\t- Save TXT file\n\nTo create BIN file:\n\t- Open characters table\n\t- Open BIN file\n\t- Open TXT file\n\t- Save BIN file", "Help ITEMDATA.BIN file");
        }

        private void helpSysMess_Click(object sender, EventArgs e)
        {
            MessageBox.Show("To extract file:\n\t- Open characters table\n\t- Open BIN file\n\t- Save TXT file\n\nTo create BIN file:\n\t- Open characters table\n\t- Open TXT file\n\t- Save BIN file", "Help SYSMESS.BIN file");
        }
    }
}
