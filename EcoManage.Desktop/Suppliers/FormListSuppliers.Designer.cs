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
            btn_Fechar = new PictureBox();
            lbl_CadastrarFornecedor = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewSuppliers).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_Fechar).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewSuppliers
            // 
            dataGridViewSuppliers.BackgroundColor = Color.FromArgb(117, 117, 117);
            dataGridViewSuppliers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(dataGridViewSuppliers, "dataGridViewSuppliers");
            dataGridViewSuppliers.Name = "dataGridViewSuppliers";
            // 
            // btn_Fechar
            // 
            resources.ApplyResources(btn_Fechar, "btn_Fechar");
            btn_Fechar.Name = "btn_Fechar";
            btn_Fechar.TabStop = false;
            btn_Fechar.Click += btn_Fechar_Click;
            // 
            // lbl_CadastrarFornecedor
            // 
            resources.ApplyResources(lbl_CadastrarFornecedor, "lbl_CadastrarFornecedor");
            lbl_CadastrarFornecedor.Name = "lbl_CadastrarFornecedor";
            // 
            // FormListSuppliers
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(84, 110, 122);
            Controls.Add(lbl_CadastrarFornecedor);
            Controls.Add(btn_Fechar);
            Controls.Add(dataGridViewSuppliers);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormListSuppliers";
            Opacity = 0.9D;
            Load += FormListSuppliers_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewSuppliers).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_Fechar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewSuppliers;
        private PictureBox btn_Fechar;
        private Label lbl_CadastrarFornecedor;
    }
}