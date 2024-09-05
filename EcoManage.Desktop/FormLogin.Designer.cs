namespace EcoManage.Desktop
{
    partial class FormLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            txt_Email = new TextBox();
            txt_Password = new TextBox();
            btnLogin = new Button();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            panel2 = new Panel();
            panel3 = new Panel();
            linkLabel1 = new LinkLabel();
            btn_Fechar = new PictureBox();
            btn_Minimizar = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_Fechar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_Minimizar).BeginInit();
            SuspendLayout();
            // 
            // txt_Email
            // 
            txt_Email.BackColor = Color.FromArgb(15, 15, 15);
            txt_Email.BorderStyle = BorderStyle.None;
            txt_Email.Font = new Font("Nunito", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txt_Email.ForeColor = Color.DimGray;
            txt_Email.Location = new Point(317, 99);
            txt_Email.Name = "txt_Email";
            txt_Email.Size = new Size(436, 22);
            txt_Email.TabIndex = 1;
            txt_Email.Text = "EMAIL";
            txt_Email.Enter += txt_Email_Enter;
            txt_Email.Leave += txt_Email_Leave;
            // 
            // txt_Password
            // 
            txt_Password.BackColor = Color.FromArgb(15, 15, 15);
            txt_Password.BorderStyle = BorderStyle.None;
            txt_Password.Font = new Font("Nunito", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txt_Password.ForeColor = Color.DimGray;
            txt_Password.Location = new Point(317, 178);
            txt_Password.Name = "txt_Password";
            txt_Password.Size = new Size(436, 22);
            txt_Password.TabIndex = 2;
            txt_Password.Text = "SENHA";
            txt_Password.Enter += txt_Password_Enter;
            txt_Password.Leave += txt_Password_Leave;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(40, 40, 40);
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatAppearance.MouseDownBackColor = Color.FromArgb(28, 28, 28);
            btnLogin.FlatAppearance.MouseOverBackColor = Color.FromArgb(64, 64, 64);
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Nunito", 8.999998F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.ForeColor = Color.LightGray;
            btnLogin.Location = new Point(317, 228);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(436, 40);
            btnLogin.TabIndex = 3;
            btnLogin.Text = "ENTRAR";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(101, 145, 87);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(250, 330);
            panel1.TabIndex = 5;
            panel1.MouseDown += panel1_MouseDown;
            // 
            // pictureBox1
            // 
            pictureBox1.Enabled = false;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(250, 330);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Nunito", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.DimGray;
            label1.Location = new Point(473, 0);
            label1.Name = "label1";
            label1.Size = new Size(106, 40);
            label1.TabIndex = 6;
            label1.Text = "LOGIN";
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Location = new Point(317, 125);
            panel2.Name = "panel2";
            panel2.Size = new Size(436, 1);
            panel2.TabIndex = 7;
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Location = new Point(317, 197);
            panel3.Name = "panel3";
            panel3.Size = new Size(436, 1);
            panel3.TabIndex = 8;
            // 
            // linkLabel1
            // 
            linkLabel1.ActiveLinkColor = Color.FromArgb(101, 145, 87);
            linkLabel1.AutoSize = true;
            linkLabel1.Font = new Font("Nunito", 8.999998F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkLabel1.LinkColor = Color.DimGray;
            linkLabel1.Location = new Point(473, 287);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(121, 17);
            linkLabel1.TabIndex = 0;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Esqueci minha senha";
            // 
            // btn_Fechar
            // 
            btn_Fechar.Image = (Image)resources.GetObject("btn_Fechar.Image");
            btn_Fechar.Location = new Point(759, 0);
            btn_Fechar.Name = "btn_Fechar";
            btn_Fechar.Size = new Size(15, 15);
            btn_Fechar.SizeMode = PictureBoxSizeMode.Zoom;
            btn_Fechar.TabIndex = 9;
            btn_Fechar.TabStop = false;
            btn_Fechar.Click += btn_Fechar_Click;
            // 
            // btn_Minimizar
            // 
            btn_Minimizar.Image = (Image)resources.GetObject("btn_Minimizar.Image");
            btn_Minimizar.Location = new Point(738, 0);
            btn_Minimizar.Name = "btn_Minimizar";
            btn_Minimizar.Size = new Size(15, 15);
            btn_Minimizar.SizeMode = PictureBoxSizeMode.Zoom;
            btn_Minimizar.TabIndex = 10;
            btn_Minimizar.TabStop = false;
            btn_Minimizar.Click += btn_Minimizar_Click;
            // 
            // FormLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(15, 15, 15);
            ClientSize = new Size(780, 330);
            Controls.Add(btn_Minimizar);
            Controls.Add(btn_Fechar);
            Controls.Add(linkLabel1);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(label1);
            Controls.Add(panel1);
            Controls.Add(btnLogin);
            Controls.Add(txt_Password);
            Controls.Add(txt_Email);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormLogin";
            Opacity = 0.9D;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormLogin";
            Load += FormLogin_Load;
            MouseDown += FormLogin_MouseDown;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_Fechar).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_Minimizar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txt_Email;
        private TextBox txt_Password;
        private Button btnLogin;
        private Panel panel1;
        private Label label1;
        private Panel panel2;
        private Panel panel3;
        private LinkLabel linkLabel1;
        private PictureBox pictureBox1;
        private PictureBox btn_Fechar;
        private PictureBox btn_Minimizar;
    }
}