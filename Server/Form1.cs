using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using OfficeOpenXml;

namespace ProductServer
{
    public partial class Form1 : Form
    {
        TcpListener server;
        Thread potok;
        bool robota = false;
        string shlyah = "";
        List<Tovar> tovari = new List<Tovar>();

        public Form1()
        {
            ExcelPackage.License.SetNonCommercialPersonal("YourName");
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Excel файли|*.xlsx";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txtFile.Text = dlg.FileName;
                shlyah = dlg.FileName;
                lstLog.Items.Add("Вибрано файл");
                LoadData();
            }
        }

        private void LoadData()
        {
            try
            {
                tovari.Clear();

                using (var package = new ExcelPackage(new FileInfo(shlyah)))
                {
                    var sheet = package.Workbook.Worksheets[0];

                    for (int i = 2; i <= sheet.Dimension.Rows; i++)
                    {
                        string name = sheet.Cells[i, 1].Text;
                        if (name == "") continue;

                        decimal price = 0;
                        int qty = 0;

                        decimal.TryParse(sheet.Cells[i, 2].Text, out price);
                        int.TryParse(sheet.Cells[i, 3].Text, out qty);

                        Tovar t = new Tovar();
                        t.name = name.ToLower();
                        t.price = price;
                        t.qty = qty;

                        tovari.Add(t);
                    }
                }

                lstLog.Items.Add("Завантажено " + tovari.Count + " товарів");
            }
            catch (Exception ex)
            {
                lstLog.Items.Add("Помилка: " + ex.Message);
            }
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (tovari.Count == 0)
            {
                MessageBox.Show("Немає товарів!");
                return;
            }

            try
            {
                server = new TcpListener(IPAddress.Any, 8888);
                server.Start();
                robota = true;

                potok = new Thread(() => {
                    while (robota)
                    {
                        try
                        {
                            TcpClient client = server.AcceptTcpClient();
                            Thread t = new Thread(Obrobka);
                            t.Start(client);
                        }
                        catch { }
                    }
                });
                potok.Start();

                btnStart.Enabled = false;
                btnStop.Enabled = true;
                lblStatus.Text = "Працює";
                lstLog.Items.Add("Сервер запущено");
            }
            catch (Exception ex)
            {
                lstLog.Items.Add("Помилка: " + ex.Message);
            }
        }

        private void Obrobka(object obj)
        {
            TcpClient client = (TcpClient)obj;
            string ip = client.Client.RemoteEndPoint.ToString();

            try
            {
                NetworkStream stream = client.GetStream();
                byte[] buf = new byte[1024];
                int bytes = stream.Read(buf, 0, buf.Length);

                if (bytes > 0)
                {
                    string zapros = Encoding.UTF8.GetString(buf, 0, bytes);
                    string[] items = zapros.Split(',');
                    List<string> vidpovid = new List<string>();
                    decimal vsego = 0;

                    foreach (string item in items)
                    {
                        string poisk = item.Trim().ToLower();
                        Tovar znaydeniy = null;

                        foreach (Tovar t in tovari)
                        {
                            if (t.name.Contains(poisk))
                            {
                                znaydeniy = t;
                                break;
                            }
                        }

                        if (znaydeniy != null)
                        {
                            decimal suma = znaydeniy.price * znaydeniy.qty;
                            vsego += suma;
                            vidpovid.Add(znaydeniy.name + ": " + znaydeniy.price + " грн x " + znaydeniy.qty + " = " + suma + " грн");
                        }
                        else
                        {
                            vidpovid.Add("'" + item.Trim() + "' - не знайдено");
                        }
                    }

                    string result = "";
                    foreach (string s in vidpovid)
                    {
                        result += s + "\n";
                    }
                    result += "\nВСЬОГО: " + vsego + " грн";

                    byte[] data = Encoding.UTF8.GetBytes(result);
                    stream.Write(data, 0, data.Length);
                }
            }
            catch { }
            finally
            {
                client.Close();
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            robota = false;
            if (server != null)
            {
                server.Stop();
            }

            btnStart.Enabled = true;
            btnStop.Enabled = false;
            lblStatus.Text = "Зупинено";
            lstLog.Items.Add("Сервер зупинено");
        }
    }

    public class Tovar
    {
        public string name;
        public decimal price;
        public int qty;
    }
}