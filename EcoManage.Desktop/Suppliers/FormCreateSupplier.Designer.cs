namespace EcoManage.Desktop.Suppliers
{
    partial class FormCreateSupplier
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
            lbl_CadastrarFornecedor = new Label();
            lbl_CompanyName = new Label();
            txt_CompanyName = new TextBox();
            lbl_DocumentNumber = new Label();
            lbl_Address = new Label();
            lbl_Street = new Label();
            lbl_Number = new Label();
            lbl_ZipCode = new Label();
            lbl_Email = new Label();
            lbl_Contact = new Label();
            txt_DocumentNumber = new TextBox();
            txt_Street = new TextBox();
            txt_ZipCode = new TextBox();
            txt_Email = new TextBox();
            txt_Contact = new TextBox();
            btn_SalvarFornecedor = new Button();
            txt_Number = new TextBox();
            btn_Voltar = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)btn_Voltar).BeginInit();
            SuspendLayout();
            // 
            // lbl_CadastrarFornecedor
            // 
            lbl_CadastrarFornecedor.AutoSize = true;
            lbl_CadastrarFornecedor.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_CadastrarFornecedor.Location = new Point(274, 9);
            lbl_CadastrarFornecedor.Name = "lbl_CadastrarFornecedor";
            lbl_CadastrarFornecedor.Size = new Size(249, 29);
            lbl_CadastrarFornecedor.TabIndex = 0;
            lbl_CadastrarFornecedor.Text = "Cadastrar Fornecedor";
            // 
            // lbl_CompanyName
            // 
            lbl_CompanyName.AutoSize = true;
            lbl_CompanyName.Location = new Point(34, 63);
            lbl_CompanyName.Name = "lbl_CompanyName";
            lbl_CompanyName.Size = new Size(123, 15);
            lbl_CompanyName.TabIndex = 1;
            lbl_CompanyName.Text = "Nome do Fornecedor:";
            // 
            // txt_CompanyName
            // 
            txt_CompanyName.Location = new Point(34, 81);
            txt_CompanyName.Name = "txt_CompanyName";
            txt_CompanyName.Size = new Size(188, 23);
            txt_CompanyName.TabIndex = 2;
            // 
            // lbl_DocumentNumber
            // 
            lbl_DocumentNumber.AutoSize = true;
            lbl_DocumentNumber.Location = new Point(34, 117);
            lbl_DocumentNumber.Name = "lbl_DocumentNumber";
            lbl_DocumentNumber.Size = new Size(188, 15);
            lbl_DocumentNumber.TabIndex = 3;
            lbl_DocumentNumber.Text = "Documento do Fornecedor(CNPJ):";
            // 
            // lbl_Address
            // 
            lbl_Address.AutoSize = true;
            lbl_Address.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_Address.Location = new Point(34, 172);
            lbl_Address.Name = "lbl_Address";
            lbl_Address.Size = new Size(85, 21);
            lbl_Address.TabIndex = 4;
            lbl_Address.Text = "Endereço:";
            // 
            // lbl_Street
            // 
            lbl_Street.AutoSize = true;
            lbl_Street.Location = new Point(35, 208);
            lbl_Street.Name = "lbl_Street";
            lbl_Street.Size = new Size(30, 15);
            lbl_Street.TabIndex = 5;
            lbl_Street.Text = "Rua:";
            // 
            // lbl_Number
            // 
            lbl_Number.AutoSize = true;
            lbl_Number.Location = new Point(35, 263);
            lbl_Number.Name = "lbl_Number";
            lbl_Number.Size = new Size(54, 15);
            lbl_Number.TabIndex = 6;
            lbl_Number.Text = "Número:";
            // 
            // lbl_ZipCode
            // 
            lbl_ZipCode.AutoSize = true;
            lbl_ZipCode.Location = new Point(34, 319);
            lbl_ZipCode.Name = "lbl_ZipCode";
            lbl_ZipCode.Size = new Size(31, 15);
            lbl_ZipCode.TabIndex = 7;
            lbl_ZipCode.Text = "CEP:";
            // 
            // lbl_Email
            // 
            lbl_Email.AutoSize = true;
            lbl_Email.Location = new Point(343, 63);
            lbl_Email.Name = "lbl_Email";
            lbl_Email.Size = new Size(119, 15);
            lbl_Email.TabIndex = 8;
            lbl_Email.Text = "Email do Fornecedor:";
            // 
            // lbl_Contact
            // 
            lbl_Contact.AutoSize = true;
            lbl_Contact.Location = new Point(343, 117);
            lbl_Contact.Name = "lbl_Contact";
            lbl_Contact.Size = new Size(114, 15);
            lbl_Contact.TabIndex = 9;
            lbl_Contact.Text = "Contato Alternativo:";
            // 
            // txt_DocumentNumber
            // 
            txt_DocumentNumber.Location = new Point(35, 135);
            txt_DocumentNumber.Name = "txt_DocumentNumber";
            txt_DocumentNumber.Size = new Size(187, 23);
            txt_DocumentNumber.TabIndex = 10;
            // 
            // txt_Street
            // 
            txt_Street.Location = new Point(39, 226);
            txt_Street.Name = "txt_Street";
            txt_Street.Size = new Size(183, 23);
            txt_Street.TabIndex = 11;
            // 
            // txt_ZipCode
            // 
            txt_ZipCode.Location = new Point(39, 337);
            txt_ZipCode.Name = "txt_ZipCode";
            txt_ZipCode.Size = new Size(123, 23);
            txt_ZipCode.TabIndex = 12;
            // 
            // txt_Email
            // 
            txt_Email.Location = new Point(343, 81);
            txt_Email.Name = "txt_Email";
            txt_Email.Size = new Size(293, 23);
            txt_Email.TabIndex = 13;
            // 
            // txt_Contact
            // 
            txt_Contact.Location = new Point(343, 135);
            txt_Contact.Multiline = true;
            txt_Contact.Name = "txt_Contact";
            txt_Contact.Size = new Size(293, 143);
            txt_Contact.TabIndex = 14;
            // 
            // btn_SalvarFornecedor
            // 
            btn_SalvarFornecedor.BackColor = Color.FromArgb(40, 40, 40);
            btn_SalvarFornecedor.Cursor = Cursors.Hand;
            btn_SalvarFornecedor.FlatStyle = FlatStyle.Flat;
            btn_SalvarFornecedor.ForeColor = SystemColors.ControlLight;
            btn_SalvarFornecedor.Location = new Point(343, 337);
            btn_SalvarFornecedor.Name = "btn_SalvarFornecedor";
            btn_SalvarFornecedor.Padding = new Padding(5);
            btn_SalvarFornecedor.Size = new Size(293, 35);
            btn_SalvarFornecedor.TabIndex = 15;
            btn_SalvarFornecedor.Text = "Cadastrar Fornecedor";
            btn_SalvarFornecedor.UseVisualStyleBackColor = false;
            btn_SalvarFornecedor.Click += btn_SalvarFornecedor_Click;
            // 
            // txt_Number
            // 
            txt_Number.Location = new Point(39, 281);
            txt_Number.Name = "txt_Number";
            txt_Number.Size = new Size(54, 23);
            txt_Number.TabIndex = 16;
            // 
            // btn_Voltar
            // 
            btn_Voltar.Image = Properties.Resources.seta_voltar;
            btn_Voltar.Location = new Point(12, 9);
            btn_Voltar.Name = "btn_Voltar";
            btn_Voltar.Size = new Size(31, 28);
            btn_Voltar.SizeMode = PictureBoxSizeMode.Zoom;
            btn_Voltar.TabIndex = 17;
            btn_Voltar.TabStop = false;
            btn_Voltar.Click += pictureBox1_Click;
            // 
            // FormCreateSupplier
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(117, 117, 117);
            ClientSize = new Size(800, 450);
            Controls.Add(btn_Voltar);
            Controls.Add(txt_Number);
            Controls.Add(btn_SalvarFornecedor);
            Controls.Add(txt_Contact);
            Controls.Add(txt_Email);
            Controls.Add(txt_ZipCode);
            Controls.Add(txt_Street);
            Controls.Add(txt_DocumentNumber);
            Controls.Add(lbl_Contact);
            Controls.Add(lbl_Email);
            Controls.Add(lbl_ZipCode);
            Controls.Add(lbl_Number);
            Controls.Add(lbl_Street);
            Controls.Add(lbl_Address);
            Controls.Add(lbl_DocumentNumber);
            Controls.Add(txt_CompanyName);
            Controls.Add(lbl_CompanyName);
            Controls.Add(lbl_CadastrarFornecedor);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormCreateSupplier";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormCreateSupplier";
            ((System.ComponentModel.ISupportInitialize)btn_Voltar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_CadastrarFornecedor;
        private Label lbl_CompanyName;
        private TextBox txt_CompanyName;
        private Label lbl_DocumentNumber;
        private Label lbl_Address;
        private Label lbl_Street;
        private Label lbl_Number;
        private Label lbl_ZipCode;
        private Label lbl_Email;
        private Label lbl_Contact;
        private TextBox txt_DocumentNumber;
        private TextBox txt_Street;
        private TextBox txt_ZipCode;
        private TextBox txt_Email;
        private TextBox txt_Contact;
        private Button btn_SalvarFornecedor;
        private TextBox txt_Number;
        private PictureBox btn_Voltar;
    }
}