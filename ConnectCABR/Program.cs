using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConnectCABR
{
    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (!new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator))
            {
                var result = MessageBox.Show("Execute como administrador!", "Necessário permissões elevadas", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            else
            {
                using (var mutex = new System.Threading.Mutex(true, "b79a6443-3f16-4c79-9041-959e75b2f468"))
                {
                    Process aProcess = Process.GetCurrentProcess();
                    string aProcName = aProcess.ProcessName;
                    var jaEstaRodando = !mutex.WaitOne(0, true);
                    if (jaEstaRodando)
                    {
                        var result = MessageBox.Show("Outro aplicativo deste já está ativo no momento, ele será fechado agora!", "Duplicata encontrada", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        var processes = Process.GetProcessesByName(aProcName);
                        foreach (var p in processes)
                        {
                            p.Kill();
                            p.WaitForExit();
                        }
                        return;
                    }
                    else
                    {
                        try
                        {
                            var processes = Process.GetProcessesByName("Engine");
                            foreach (var p in processes)
                            {
                                p.Kill();
                                p.WaitForExit();
                            }
                        }
                        catch (Exception)
                        {
                        }
                        mutex.ReleaseMutex();
                        Application.EnableVisualStyles();
                        Application.SetCompatibleTextRenderingDefault(false);
                        Application.Run(new Dashboard());
                    }
                }
            }
        }
    }
}
