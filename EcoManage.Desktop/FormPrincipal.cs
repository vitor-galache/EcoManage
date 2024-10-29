using EcoManage.Desktop.Suppliers;

namespace EcoManage.Desktop
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void listarFornecedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormListSuppliers formListSuppliers = new FormListSuppliers();
            this.Hide();
            formListSuppliers.ShowDialog();
        }

        private void btnSair_menu_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Realmente deseja encerrar a aplicação?", "Encerrar sessão", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormCreateSupplier formCreateSupplier = new FormCreateSupplier();
            formCreateSupplier.ShowDialog();
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            BackColor = Color.White;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void h1_lbl_Click(object sender, EventArgs e)
        {

        }
    }
}
