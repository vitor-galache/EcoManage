namespace EcoManage.Desktop
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnSair_menu_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Realmente deseja encerrar a aplicação?", "Encerrar sessão", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
