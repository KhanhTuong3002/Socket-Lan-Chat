namespace Socket_Lan_Chat
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
           
        }

        private void Main_shown(object sender, EventArgs e)
        {
            try
            {
                var loginForm = new Login();
                loginForm.ShowDialog();
                if (loginForm.DialogResult != DialogResult.Cancel)
                {
                    Close();
                    return;
                }
                MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
