namespace EcoManage.Desktop.Suppliers
{
    partial class FormListSuppliers
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormListSuppliers));
            dataGridViewSuppliers = new DataGridView();
            lbl_CadastrarFornecedor = new Label();
            btn_Voltar = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)dataGridViewSuppliers).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_Voltar).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewSuppliers
            // 
            dataGridViewSuppliers.BackgroundColor = Color.FromArgb(117, 117, 117);
            dataGridViewSuppliers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(dataGridViewSuppliers, "dataGridViewSuppliers");
            dataGridViewSuppliers.Name = "dataGridViewSuppliers";
            dataGridViewSuppliers.CellContentClick += dataGridViewSuppliers_CellContentClick;
            // 
            // lbl_CadastrarFornecedor
            // 
            resources.ApplyResources(lbl_CadastrarFornecedor, "lbl_CadastrarFornecedor");
            lbl_CadastrarFornecedor.Name = "lbl_CadastrarFornecedor";
            // 
            // btn_Voltar
            // 
            btn_Voltar.Image = Properties.Resources.seta_voltar;
            resources.ApplyResources(btn_Voltar, "btn_Voltar");
            btn_Voltar.Name = "btn_Voltar";
            btn_Voltar.TabStop = false;
            btn_Voltar.Click += btn_Voltar_Click;
            // 
            // FormListSuppliers
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(84, 110, 122);
            Controls.Add(btn_Voltar);
            Controls.Add(lbl_CadastrarFornecedor);
            Controls.Add(dataGridViewSuppliers);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormListSuppliers";
            Opacity = 0.9D;
            Load += FormListSuppliers_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewSuppliers).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_Voltar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewSuppliers;
        private Label lbl_CadastrarFornecedor;
        private PictureBox btn_Voltar;
    }
}