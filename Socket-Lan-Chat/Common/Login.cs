using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Net;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace Socket_Lan_Chat
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        // Event handler for the login button
        private async void BtnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    MessageBox.Show("Please enter both username and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (var http = new HttpClient())
                {
                    http.Timeout = TimeSpan.FromSeconds(15);

                    // Corrected the `using` statement and made the request asynchronous
                    var response = await http.GetAsync($"http://localhost:5062/api/login?username={txtUsername.Text}&password={txtPassword.Text}");

                    if (response.IsSuccessStatusCode)
                    {
                        // Use System.Text.Json instead of JsonConvert
                        var result = await response.Content.ReadAsStringAsync();
                        var message = JsonSerializer.Deserialize<string>(result);

                        MessageBox.Show(message, "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Exit the application
            Close();
        }


    }
}
