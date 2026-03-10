using System;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace ProductClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                string ip = txtIP.Text.Trim();
                int port = Convert.ToInt32(txtPort.Text.Trim());

                TcpClient client = new TcpClient();
                client.Connect(ip, port);

                if (client.Connected)
                {
                    btnConnect.Enabled = false;
                    btnSend.Enabled = true;
                    txtIP.Enabled = false;
                    txtPort.Enabled = false;
                    lblStatus.Text = "Підключено";
                    lstResponse.Items.Add("Підключено до сервера");
                    client.Close();
                }
            }
            catch
            {
                MessageBox.Show("Не можу підключитись!");
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                string ip = txtIP.Text.Trim();
                int port = Convert.ToInt32(txtPort.Text.Trim());
                string tovary = txtProducts.Text.Trim();

                if (tovary == "")
                {
                    MessageBox.Show("Введіть товари!");
                    return;
                }

                TcpClient client = new TcpClient();
                client.Connect(ip, port);

                NetworkStream stream = client.GetStream();
                byte[] data = Encoding.UTF8.GetBytes(tovary);
                stream.Write(data, 0, data.Length);

                byte[] buffer = new byte[4096];
                int bytes = stream.Read(buffer, 0, buffer.Length);
                string vidpovid = Encoding.UTF8.GetString(buffer, 0, bytes);

                lstResponse.Items.Clear();
                lstResponse.Items.Add("Запит: " + tovary);
                lstResponse.Items.Add("----------------------");

                string[] lines = vidpovid.Split('\n');
                foreach (string line in lines)
                {
                    if (line != "")
                    {
                        lstResponse.Items.Add(line);
                    }
                }

                client.Close();
            }
            catch
            {
                MessageBox.Show("Помилка відправки!");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}