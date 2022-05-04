using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using System.Threading;


namespace Monitor
{
    public partial class MonitorForm : Form
    {
        string pathFolderMonitor = "";
        string pathFolderProcessing = "";
        Thread th1;
        Excel.Workbook filexls;
        List<string> filesOnFolder = new List<string>();
        FileSystemWatcher fsw;
        bool isProcesing = false;


        public MonitorForm()
        {
            InitializeComponent();
            btnProcesingFilesFolder.Enabled = false;
            txtbxPahtProcesingFolder.Enabled = false;
        }
        #region Buttons Select folder
        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialogMonitoring.ShowDialog() == DialogResult.OK)
            {
                txtbxPathMonitoringFolder.Text = folderBrowserDialogMonitoring.SelectedPath;
            }
        }
        private void btnProcesingFilesFolder_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialogProcessing.ShowDialog() == DialogResult.OK)
            {
                txtbxPahtProcesingFolder.Text = folderBrowserDialogProcessing.SelectedPath;
            }
        }
        #endregion
        #region chckbxSameDirectory Same directory as Monitirising folder.
        private void chckbxSameDirectory_CheckedChanged(object sender, EventArgs e)
        {
            if (chckbxSameDirectory.Checked)
            {
                btnProcesingFilesFolder.Enabled = false;
                txtbxPahtProcesingFolder.Enabled = false;
            }
            else {
                btnProcesingFilesFolder.Enabled = true;
                txtbxPahtProcesingFolder.Enabled = true;
            }
        }
        #endregion
        #region Button for Monitorisig the folder
        private void btnSearch_Click(object sender, EventArgs e)
        {

            if (isProcesing) {
                isProcesing = false;
                btnSearch.Text = "Start monitoring files";
            }
            else
            {
                Timer.Interval = 5000;
                Timer.Tick += new EventHandler(Timer_Tick);

                isProcesing = true;
                
                btnSearch.Text = "Stop monitoring files";
            }
            
            Console.WriteLine("Start monitorising");
            pathFolderMonitor = txtbxPathMonitoringFolder.Text;
            pathFolderProcessing = txtbxPahtProcesingFolder.Text;
            if (!pathFolderMonitor.Equals(""))
            {
                lblWarningFolder.Text = "";
                if (chckbxSameDirectory.Checked)
                {
                    pathFolderProcessing = pathFolderMonitor;
                }
                
                Timer.Enabled = true;
            }//Close if (!pathFolderMonitor.Equals(""))
            else
            {
                Console.WriteLine("Have to select the folder for monitor");
                lblWarningFolder.Text = "Must select the folder for monitor";
            }

        }//Close private void btnSearch_Click
        #endregion

        #region MoveFile Move the file depends of format
        private void MoveFile(string file1, string pathNewFile)
        {
            try
            {
                File.Move(file1, pathNewFile);
                Console.WriteLine("File: " + file1+ " moved to " + pathNewFile);
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex);
            }
        }
        #endregion
        public static void Fsw_Renamed(object source, RenamedEventArgs e)
        { 
            Console.WriteLine(" {0} renamed to {1}", e.OldFullPath, e.FullPath);
        }
        
        private void Timer_Tick(object Sender, EventArgs e)
        {
            if (isProcesing) {
                Thread Thread_Monitor = new Thread(MonitorStart);
                Thread_Monitor.Start();
            }
        }
        private void MonitorStart()
        {
            Console.WriteLine("JC MonitorStart INICIA");
            isProcesing = false;
            
            string ProcessedFolder = pathFolderProcessing + "\\Processed\\";
            if (!System.IO.Directory.Exists(ProcessedFolder)) System.IO.Directory.CreateDirectory(ProcessedFolder);

            string NotApplicableFolder = pathFolderProcessing + "\\Not applicable\\";
            if (!System.IO.Directory.Exists(NotApplicableFolder)) System.IO.Directory.CreateDirectory(NotApplicableFolder);
            
            #region Working files on folder
            
            string path = pathFolderProcessing + "\\Master.xls";
            if (File.Exists(path))
            {
                Console.WriteLine("File Found");
            }
            else
            {
                Console.WriteLine("File Not Found");
                CreateMasterExcel(path);
            }
           
            string[] filesNotExcel = Directory.GetFiles(pathFolderMonitor); // Obtain files NOT *.xls in folder
            string nameFile = "";
            foreach (string f in filesNotExcel)
            {
                nameFile = Path.GetFileName(f);
                filesOnFolder.Add(nameFile);
                if (!f.Contains(".xls"))
                {
                    nameFile = Path.GetFileName(f);
                    MoveFile(f, NotApplicableFolder + nameFile);
                }
            }
            string[] files = Directory.GetFiles(pathFolderMonitor, "*.xls");//Obtain files *.xls in folder
            
            List<String> list = new List<String>();
            
            foreach (string f in files)
            {

                if (!f.Contains("Master.xls"))//~$Master.xls
                {
                    list.Add(f);
                }
            }
            
            Excel.Application excel = new Excel.Application();
                
            foreach (string f in list)
            {
                Console.WriteLine("JC File: " + f); 
                
                try
                {
                    nameFile = Path.GetFileName(f);
                    filexls = excel.Workbooks.Open(f);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error open file: " + ex);
                    MoveFile(f, NotApplicableFolder + nameFile);
                }

                
                #region Working files

                try
                {
                    string ruta_plantilla = f;

                    string ruta_archivo_final = pathFolderProcessing + "\\Master.xls";
                    
                    Excel.Workbook wbSource = excel.Workbooks.Open(ruta_plantilla, 0, false, 1, "", "", false, Excel.XlPlatform.xlWindows, 9, true, false, 0, true, false, false);
                    
                    Excel.Workbook wbDestination = excel.Workbooks.Open(ruta_archivo_final, 0, false, 1, "", "", false, Excel.XlPlatform.xlWindows, 9, true, false, 0, true, false, false);
                    
                    int cantHojasPlantilla = wbSource.Sheets.Count; //wbDestination.Sheets.Count;
                    Console.Write(ruta_plantilla + " have " + cantHojasPlantilla + " sheets");
                    int cantHojasFinal = wbDestination.Sheets.Count; //wbDestination.Sheets.Count;
                    Console.Write(ruta_plantilla + " have " + cantHojasFinal + " sheets");
                    
                    int countNewSheets = 0;
                    foreach (Microsoft.Office.Interop.Excel.Worksheet Sheets in filexls.Sheets)
                    {
                        
                        Excel.Sheets xlSheets = wbDestination.Sheets as Excel.Sheets;
                        Excel.Worksheet xlNewSheet = (Excel.Worksheet)xlSheets.Add(Type.Missing, xlSheets[cantHojasFinal + countNewSheets], Type.Missing, Type.Missing);
                        try
                        {
                            xlNewSheet.Name = Sheets.Name + "_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() +
                                DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error colocando nombre a hoja");
                        }
                        countNewSheets++;
                    }
                    
                    int countSheets = 0;
                    foreach (Microsoft.Office.Interop.Excel.Worksheet Sheets in filexls.Sheets)
                    {
                        Console.WriteLine("Hojas: " + Sheets.Name);
                        countSheets++;
                        Excel.Worksheet wkrSh_src = wbSource.Sheets[countSheets];
                        wkrSh_src.UsedRange.Copy(Type.Missing);
                        Excel.Worksheet wrkSh_ = wbDestination.Sheets[cantHojasFinal + countSheets];//Hoja que contiene la plantilla.
                        wrkSh_.UsedRange.PasteSpecial(Excel.XlPasteType.xlPasteAll, Excel.XlPasteSpecialOperation.xlPasteSpecialOperationNone, Type.Missing, Type.Missing);
                        wrkSh_.Columns.AutoFit();
                    }
                    
                    wbDestination.Sheets[1].Activate();//Poner primera hoja como activa.
                    wbDestination.Save();
                    wbSource.Close();
                    excel.Quit();
                    filesOnFolder.Clear();

                }//Close try
                catch (Exception ex)
                {
                    Console.Write("Error ocurrido al copiar hoja: " + ex);
                }
                #endregion


            }//Close foreach (string f in files)

            foreach (string f in list)
            {
                nameFile = Path.GetFileName(f);
                MoveFile(f, ProcessedFolder + nameFile);
            }
            #endregion


            isProcesing = true;
            
        }//Close MonitorStart


        private void CreateMasterExcel(string ruta_archivo_final)
        {
            
            Excel.Application excel;
            Excel.Workbook worKbooK;
            Excel.Worksheet worKsheeT;
            try
            {
                excel = new Microsoft.Office.Interop.Excel.Application();
                excel.Visible = false;
                excel.DisplayAlerts = false;
                worKbooK = excel.Workbooks.Add(Type.Missing);
                worKsheeT = (Excel.Worksheet)worKbooK.ActiveSheet;
                worKsheeT.Name = "Sheet1";
                worKbooK.SaveAs(ruta_archivo_final);
                worKbooK.Close();
                excel.Quit();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                worKsheeT = null;
                worKbooK = null;
            }
        }
        
    }
}
