using ConnectCA;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Resources;
using System.Net;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace ConnectCABR
{
    public partial class Dashboard : Form
    {
        string Folder = String.Empty;
        int count;
        int cont;
        int Vel;
        public Dashboard()
        {
            InitializeComponent();
        }
        private void Download(object Data)
        {
            try
            {
                List<string> FoldersName = (List<string>)Data;
                string Location = FoldersName[0];
                string Url = FoldersName[1];
                var clientDown = new WebClient();
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                clientDown.DownloadFileAsync(new Uri(Url), @Location);
            }
            catch (Exception Download)
            {
                Alert(Download.Message);
            }
        }
        private void Alert(string Alerta)
        {
            try
            {
                var result = MessageBox.Show(Alerta, "Connect CA - Alert", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            catch (Exception)
            {
            }
        }

        private void FolderButton_Click(object sender, EventArgs e)
        {
            try
            {
                CreateAlert("Selecione a pasta aonde está o combat arms, ela é parecida com isso veja!\nC:\\Level Up\\Combat Arms");
                using (var fbd = new FolderBrowserDialog())
                {
                    DialogResult result = fbd.ShowDialog();

                    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                    {
                        Folder = fbd.SelectedPath;
                        FolderTextBox.Text = Folder;
                    }
                }
            }
            catch(Exception FolderButton)
            {
                Alert(FolderButton.Message);
            }
        }
        private void GetAllNicDescriptions()
        {
            try
            {
                using (var networkConfigMng = new ManagementClass("Win32_NetworkAdapterConfiguration"))
                {
                    using (var networkConfigs = networkConfigMng.GetInstances())
                    {
                        foreach (var config in networkConfigs.Cast<ManagementObject>()
                                                                           .Where(mo => (bool)mo["IPEnabled"])
                                                                           .Select(x => new NetworkAdapterConfiguration(x)))
                        {
                            setDNS(config.Description, "1.1.1.1,8.8.8.8");
                            SetNameservers(config.Description, "1.1.1.1,8.8.8.8");
                            RestartNetworkAdapter(config.Description);
                        }
                    }
                }
            }
            catch(Exception GetAllNicDescriptions)
            {
                Alert(GetAllNicDescriptions.Message);
            }
        }
        private void setDNS(string NIC, string DNS)
        {
            try
            {
                ManagementClass objMC = new ManagementClass("Win32_NetworkAdapterConfiguration");
                ManagementObjectCollection objMOC = objMC.GetInstances();

                foreach (ManagementObject objMO in objMOC)
                {
                    if ((bool)objMO["IPEnabled"])
                    {
                        // if you are using the System.Net.NetworkInformation.NetworkInterface
                        // you'll need to change this line to
                        // if (objMO["Caption"].ToString().Contains(NIC))
                        // and pass in the Description property instead of the name 
                        if (objMO["Caption"].Equals(NIC))
                        {
                            ManagementBaseObject newDNS =
                              objMO.GetMethodParameters("SetDNSServerSearchOrder");
                            newDNS["DNSServerSearchOrder"] = DNS.Split(',');
                            ManagementBaseObject setDNS =
                              objMO.InvokeMethod("SetDNSServerSearchOrder", newDNS, null);
                        }
                    }
                }
            }
            catch(Exception setDNS)
            {
                Alert(setDNS.Message);
            }
        }
        private void SetNameservers(string nic, string dnsServers)
        {
            try
            {
                using (var networkConfigMng = new ManagementClass("Win32_NetworkAdapterConfiguration"))
                {
                    using (var networkConfigs = networkConfigMng.GetInstances())
                    {
                        foreach (var managementObject in networkConfigs.Cast<ManagementObject>().Where(objMO => (bool)objMO["IPEnabled"] && objMO["Caption"].Equals(nic)))
                        {
                            using (var newDNS = managementObject.GetMethodParameters("SetDNSServerSearchOrder"))
                            {
                                newDNS["DNSServerSearchOrder"] = dnsServers.Split(',');
                                managementObject.InvokeMethod("SetDNSServerSearchOrder", newDNS, null);
                            }
                        }
                    }
                }
            }
            catch(Exception SetNameservers)
            {
                Alert(SetNameservers.Message);
            }
        }
        private void RestartNetworkAdapter(string nicDescription)
        {
            try
            {
                using (ManagementClass networkConfigMng = new ManagementClass("Win32_NetworkAdapter"))
                {
                    using (ManagementObjectCollection networkConfigs = networkConfigMng.GetInstances())
                    {
                        foreach (ManagementObject mboDNS in networkConfigs.Cast<ManagementObject>().Where(mo => (string)mo["Description"] == nicDescription))
                        {
                            // NA class was generated by opening dev console and entering
                            // mgmtclassgen Win32_NetworkAdapter -p NetworkAdapter.cs
                            using (NetworkAdapter adapter = new NetworkAdapter(mboDNS))
                            {
                                adapter.Disable();
                                adapter.Enable();
                                Thread.Sleep(4000); // Wait a few secs until exiting, this will give the NIC enough time to re-connect
                                return;
                            }
                        }
                    }
                }
            }
            catch(Exception RestartNetworkAdapter)
            {
                Alert(RestartNetworkAdapter.Message);
            }
        }
        private void clearFolder(object Folder)
        {
            try
            {
                List<string> FoldersName = (List<string>)Folder;
                string FolderName = FoldersName[0];
                DirectoryInfo dir = new DirectoryInfo(FolderName);

                foreach (FileInfo fi in dir.GetFiles())
                {
                    fi.Delete();
                }

                foreach (DirectoryInfo di in dir.GetDirectories())
                {
                    clearFolder(di.FullName);
                    di.Delete();
                }
            }
            catch(Exception clearFolder)
            {
                Alert(clearFolder.Message);
            }
        }
        private void CheckFolder()
        {
            try
            {
                if(ClearLogs.Enabled)
                {
                }
                else if (Folder.Contains("Combat"))
                {
                    ClearLogs.Enabled = true;
                }
            }
            catch(Exception CheckFolder)
            {
                Alert(CheckFolder.Message);
            }
        }
        private void SearchEngine_Tick(object sender, EventArgs e)
        {
            CheckFolder();
        }
        private void ClearAction()
        {
            try
            {
                Thread ClearFolder = new Thread(new ParameterizedThreadStart(clearFolder));
                List<string> Dados = new List<string>();
                Dados.Add(Folder + "\\NMDATA.900");
                ClearFolder.IsBackground = true;
                ClearFolder.Start(Dados);
                ClearFolder.Join();
                Thread ClearFolder2 = new Thread(new ParameterizedThreadStart(clearFolder));
                List<string> Dados2 = new List<string>();
                Dados2.Add(Folder + "\\Log");
                ClearFolder2.IsBackground = true;
                ClearFolder2.Start(Dados2);
                ClearFolder2.Join();
                Thread ClearFolder3 = new Thread(new ParameterizedThreadStart(clearFolder));
                List<string> Dados3 = new List<string>();
                Dados3.Add(Folder + "\\Game\\Etc");
                ClearFolder3.IsBackground = true;
                ClearFolder3.Start(Dados3);
                ClearFolder3.Join();
                Thread ClearFolder4 = new Thread(new ParameterizedThreadStart(clearFolder));
                List<string> Dados4 = new List<string>();
                Dados4.Add(Folder + "\\Game\\BGM");
                ClearFolder4.IsBackground = true;
                ClearFolder4.Start(Dados4);
                ClearFolder4.Join();
                Thread ClearFolder5 = new Thread(new ParameterizedThreadStart(clearFolder));
                List<string> Dados5 = new List<string>();
                Dados5.Add(Folder + "\\Game\\MOVIES");
                ClearFolder5.IsBackground = true;
                ClearFolder5.Start(Dados5);
                ClearFolder5.Join();
            }
            catch(Exception ClearAction)
            {
                Alert(ClearAction.Message);
            }
        }
        private void InsertProfileConfig()
        {
            Thread.Sleep(2000);
            try
            {
                StreamWriter writer = new StreamWriter(@Folder + "\\Profiles\\player.txt", true);
                writer.WriteLine("");
                writer.Close();
            }
            catch (Exception InsertProfileConfig)
            {
                Alert(InsertProfileConfig.Message);
            }
        }
        delegate void StartProcCallback();
        private void StartProc()
        {
            try
            {
                if (InvokeRequired)
                {
                    StartProcCallback callback = StartProc;
                    Invoke(callback);
                }
                else
                {
                    ProgressBar.Value = 0;
                    if (CorrectDNS.Checked)
                    {
                        Thread getallnickdescriptions = new Thread(new ThreadStart(GetAllNicDescriptions))
                        {
                            IsBackground = true
                        };
                        getallnickdescriptions.Start();
                        getallnickdescriptions.Join();
                        ProgressBar.Value += 25;
                        Alert("Processo de conexão terminado!");
                    }
                    if (ClearLogs.Checked)
                    {
                        Thread clearaction = new Thread(new ThreadStart(ClearAction))
                        {
                            IsBackground = true
                        };
                        clearaction.Start();
                        clearaction.Join();
                        ProgressBar.Value += 25;
                        Thread insertprofileconfig = new Thread(new ThreadStart(InsertProfileConfig))
                        {
                            IsBackground = true
                        };
                        insertprofileconfig.Start();
                        insertprofileconfig.Join();
                        ProgressBar.Value += 25;
                        Thread download = new Thread(new ParameterizedThreadStart(Download));
                        List<string> Dados6 = new List<string>();
                        Dados6.Add(Folder + "\\Profiles\\player.txt");
                        Dados6.Add("https://combatarms.anticheats.com.br/PlayerData.txt");
                        download.IsBackground = true;
                        download.Start(Dados6);
                        download.Join();
                        ProgressBar.Value += 25;
                        Alert("Processo de limpeza terminado!");
                    }
                    OnOff(true);
                }
            }
            catch (Exception StartProc)
            {
                Alert(StartProc.Message);
            }
        }
        [DllImport("User32.dll")]
        static extern int SetForegroundWindow(IntPtr point);
        private void login()
        {
            try
            {
                count = 0;
                cont = 0;
                for (count=0; cont < 25; count++)
                {
                    cont = count;
                    Process p = Process.GetProcessesByName("Engine").FirstOrDefault();
                    if (p != null)
                    {
                        IntPtr h = p.MainWindowHandle;
                        SetForegroundWindow(h);
                        SendKeys.SendWait("{ENTER}");
                    }
                    else
                    {
                        count = 25;
                        cont = 25;
                    }
                    Thread.Sleep(Vel);
                }
                OnOff(true);
                CreateAlert("Uffa! Terminamos por aqui, esperamos que tenha conseguido logar!");
            }
            catch (Exception login)
            {
                Alert(login.Message);
            }
        }
        private void StartButton_Click(object sender, EventArgs e)
        {
            OnOff(false);
            CreateAlert("Aguarde um pouco, vamos fazer alguns ajustes!");
            Thread startproc = new Thread(new ThreadStart(StartProc))
            {
                IsBackground = true
            };
            startproc.Start();
        }
        delegate void OnOffCallback(bool status);
        private void OnOff(bool status)
        {
            if (InvokeRequired)
            {
                OnOffCallback callback = OnOff;
                Invoke(callback, status);
            }
            else
            {
                StartButton.Enabled = status;
                LoginButton.Enabled = status;
            }
        }
        delegate void CreateAlertCallback(string message);
        public void CreateAlert(string message)
        {
            if (InvokeRequired)
            {
                CreateAlertCallback callback = CreateAlert;
                Invoke(callback, message);
            }
            else
            {
                DashboardAlert.Visible = true;
                DashboardAlert.ShowBalloonTip(20000, "WAC - Connect CA", message, ToolTipIcon.Info);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            CreateAlert("Olá! Faça bom uso!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OnOff(false);
            CreateAlert("Este processo leva 1 minuto, Aguarde até o fim!");
            Thread Login = new Thread(new ThreadStart(login))
            {
                IsBackground = true
            };
            Login.Start();
        }
        private void VelBar_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (VelBar.Value == 1)
                {
                    Vel = 2000;
                }
                if (VelBar.Value == 2)
                {
                    Vel = 1500;
                }
                if (VelBar.Value == 3)
                {
                    Vel = 1000;
                }
                if (VelBar.Value == 4)
                {
                    Vel = 500;
                }
            }
            catch(Exception VelBar_ValueChanged)
            {
                Alert(VelBar_ValueChanged.Message);
            }
        }
    }
}
