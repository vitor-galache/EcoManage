namespace EcoManage.Desktop.Suppliers
{
    partial class FormEditSupplier
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
            btn_AtualizarFornecedor = new Button();
            txt_Contact = new TextBox();
            txt_Email = new TextBox();
            lbl_Contact = new Label();
            lbl_Email = new Label();
            txt_CompanyName = new TextBox();
            lbl_CompanyName = new Label();
            lbl_EditarFornecedor = new Label();
            SuspendLayout();
            // 
            // btn_AtualizarFornecedor
            // 
            btn_AtualizarFornecedor.BackColor = Color.FromArgb(40, 40, 40);
            btn_AtualizarFornecedor.Cursor = Cursors.Hand;
            btn_AtualizarFornecedor.FlatStyle = FlatStyle.Flat;
            btn_AtualizarFornecedor.ForeColor = SystemColors.ControlLight;
            btn_AtualizarFornecedor.Location = new Point(247, 388);
            btn_AtualizarFornecedor.Name = "btn_AtualizarFornecedor";
            btn_AtualizarFornecedor.Padding = new Padding(5);
            btn_AtualizarFornecedor.Size = new Size(293, 35);
            btn_AtualizarFornecedor.TabIndex = 32;
            btn_AtualizarFornecedor.Text = "Atualizar Fornecedor";
            btn_AtualizarFornecedor.UseVisualStyleBackColor = false;
            // 
            // txt_Contact
            // 
            txt_Contact.Location = new Point(247, 224);
            txt_Contact.Multiline = true;
            txt_Contact.Name = "txt_Contact";
            txt_Contact.Size = new Size(293, 143);
            txt_Contact.TabIndex = 31;
            // 
            // txt_Email
            // 
            txt_Email.Location = new Point(247, 160);
            txt_Email.Name = "txt_Email";
            txt_Email.Size = new Size(293, 23);
            txt_Email.TabIndex = 30;
            // 
            // lbl_Contact
            // 
            lbl_Contact.AutoSize = true;
            lbl_Contact.Location = new Point(247, 197);
            lbl_Contact.Name = "lbl_Contact";
            lbl_Contact.Size = new Size(114, 15);
            lbl_Contact.TabIndex = 26;
            lbl_Contact.Text = "Contato Alternativo:";
            // 
            // lbl_Email
            // 
            lbl_Email.AutoSize = true;
            lbl_Email.Location = new Point(247, 142);
            lbl_Email.Name = "lbl_Email";
            lbl_Email.Size = new Size(119, 15);
            lbl_Email.TabIndex = 25;
            lbl_Email.Text = "Email do Fornecedor:";
            // 
            // txt_CompanyName
            // 
            txt_CompanyName.Location = new Point(247, 116);
            txt_CompanyName.Name = "txt_CompanyName";
            txt_CompanyName.Size = new Size(293, 23);
            txt_CompanyName.TabIndex = 19;
            // 
            // lbl_CompanyName
            // 
            lbl_CompanyName.AutoSize = true;
            lbl_CompanyName.Location = new Point(247, 84);
            lbl_CompanyName.Name = "lbl_CompanyName";
            lbl_CompanyName.Size = new Size(123, 15);
            lbl_CompanyName.TabIndex = 18;
            lbl_CompanyName.Text = "Nome do Fornecedor:";
            // 
            // lbl_EditarFornecedor
            // 
            lbl_EditarFornecedor.AutoSize = true;
            lbl_EditarFornecedor.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_EditarFornecedor.Location = new Point(294, 9);
            lbl_EditarFornecedor.Name = "lbl_EditarFornecedor";
            lbl_EditarFornecedor.Size = new Size(208, 29);
            lbl_EditarFornecedor.TabIndex = 17;
            lbl_EditarFornecedor.Text = "Editar Fornecedor";
            // 
            // FormEditSupplier
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(117, 117, 117);
            ClientSize = new Size(800, 450);
            Controls.Add(btn_AtualizarFornecedor);
            Controls.Add(txt_Contact);
            Controls.Add(txt_Email);
            Controls.Add(lbl_Contact);
            Controls.Add(lbl_Email);
            Controls.Add(txt_CompanyName);
            Controls.Add(lbl_CompanyName);
            Controls.Add(lbl_EditarFornecedor);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormEditSupplier";
            Text = "FormEditSupplier";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btn_AtualizarFornecedor;
        private TextBox txt_Contact;
        private TextBox txt_Email;
        private Label lbl_Contact;
        private Label lbl_Email;
        private TextBox txt_CompanyName;
        private Label lbl_CompanyName;
        private Label lbl_EditarFornecedor;
    }
}