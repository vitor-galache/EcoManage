using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EcoManage.Domain;
using EcoManage.Domain.Requests.Account;
using Newtonsoft.Json;
using System.Runtime.InteropServices;


namespace EcoManage.Desktop
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        public static CookieContainer cookieContainer = new CookieContainer();

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            var request = new LoginRequest()
            {
                Email = txt_Email.Text,
                Password = txt_Password.Text
            };


            var handler = new HttpClientHandler()
            {
                CookieContainer = cookieContainer,
                UseCookies = true,
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            };

            using (HttpClient client = new HttpClient(handler))
            {

                var response = await client.PostAsJsonAsync(DesktopConfiguration.ApiUrl + "v1/identity/login?useCookies=true", request);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    FormPrincipal principal = new FormPrincipal();

                    principal.Show();
                    this.Hide();
                }

                else
                {
                    MessageBox.Show("Falha no login");
                }
            }
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }

        private void txt_Email_Enter(object sender, EventArgs e)
        {
            if (txt_Email.Text == "EMAIL")
            {
                txt_Email.Text = "";
                txt_Email.ForeColor = Color.LightGray;
            }
        }

        private void txt_Email_Leave(object sender, EventArgs e)
        {
            if (txt_Email.Text == "")
            {
                txt_Email.Text = "EMAIL";
                txt_Email.ForeColor = Color.DimGray;
            }
        }

        private void txt_Password_Enter(object sender, EventArgs e)
        {
            if (txt_Password.Text == "SENHA")
            {
                txt_Password.Text = "";
                txt_Password.ForeColor = Color.LightGray;
                txt_Password.UseSystemPasswordChar = true;
            }
        }

        private void txt_Password_Leave(object sender, EventArgs e)
        {
            if (txt_Password.Text == "")
            {
                txt_Password.Text = "SENHA";
                txt_Password.ForeColor = Color.DimGray;
                txt_Password.UseSystemPasswordChar = false;
            }
        }

        private void btn_Fechar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_Minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void FormLogin_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
           
        }
    }
}
