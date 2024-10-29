namespace EcoManage.Desktop
{
    partial class FormPrincipal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrincipal));
            fornecedoresToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripMenuItem();
            listarFornecedoresToolStripMenuItem = new ToolStripMenuItem();
            btnSair_menu = new ToolStripMenuItem();
            menuStrip1 = new MenuStrip();
            h1_lbl = new Label();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // fornecedoresToolStripMenuItem
            // 
            fornecedoresToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem1, listarFornecedoresToolStripMenuItem });
            fornecedoresToolStripMenuItem.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            fornecedoresToolStripMenuItem.ForeColor = Color.LightGray;
            fornecedoresToolStripMenuItem.Name = "fornecedoresToolStripMenuItem";
            fornecedoresToolStripMenuItem.Padding = new Padding(5);
            fornecedoresToolStripMenuItem.Size = new Size(134, 34);
            fornecedoresToolStripMenuItem.Text = "Fornecedores";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(239, 24);
            toolStripMenuItem1.Text = "Cadastrar";
            toolStripMenuItem1.Click += toolStripMenuItem1_Click;
            // 
            // listarFornecedoresToolStripMenuItem
            // 
            listarFornecedoresToolStripMenuItem.Name = "listarFornecedoresToolStripMenuItem";
            listarFornecedoresToolStripMenuItem.Size = new Size(239, 24);
            listarFornecedoresToolStripMenuItem.Text = "Listar Fornecedores";
            listarFornecedoresToolStripMenuItem.Click += listarFornecedoresToolStripMenuItem_Click;
            // 
            // btnSair_menu
            // 
            btnSair_menu.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSair_menu.ForeColor = Color.LightGray;
            btnSair_menu.Name = "btnSair_menu";
            btnSair_menu.Padding = new Padding(5);
            btnSair_menu.Size = new Size(55, 34);
            btnSair_menu.Text = "Sair";
            btnSair_menu.Click += btnSair_menu_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.FromArgb(84, 110, 122);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fornecedoresToolStripMenuItem, btnSair_menu });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(6, 5, 5, 5);
            menuStrip1.Size = new Size(800, 44);
            menuStrip1.TabIndex = 3;
            menuStrip1.Text = "menuStrip1";
            // 
            // h1_lbl
            // 
            h1_lbl.AutoSize = true;
            h1_lbl.BackColor = SystemColors.AppWorkspace;
            h1_lbl.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            h1_lbl.ForeColor = Color.FromArgb(101, 145, 87);
            h1_lbl.Location = new Point(12, 54);
            h1_lbl.Name = "h1_lbl";
            h1_lbl.Size = new Size(345, 25);
            h1_lbl.TabIndex = 5;
            h1_lbl.Text = "Seja Bem Vindo Ao EcoManage";
            h1_lbl.Click += h1_lbl_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.AppWorkspace;
            label2.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(101, 145, 87);
            label2.Location = new Point(14, 88);
            label2.Name = "label2";
            label2.Size = new Size(290, 16);
            label2.TabIndex = 9;
            label2.Text = " Controle de Fornecedores da Fazenda Urbana";
            label2.Click += label2_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.FromArgb(0, 0, 0, 0);
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(215, 117);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(368, 321);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            // 
            // FormPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(117, 117, 117);
            ClientSize = new Size(800, 450);
            Controls.Add(pictureBox1);
            Controls.Add(label2);
            Controls.Add(h1_lbl);
            Controls.Add(menuStrip1);
            ForeColor = Color.FromArgb(101, 145, 87);
            FormBorderStyle = FormBorderStyle.None;
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            Name = "FormPrincipal";
            Opacity = 0.9D;
            StartPosition = FormStartPosition.CenterScreen;
            Load += FormPrincipal_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStripMenuItem fornecedoresToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem listarFornecedoresToolStripMenuItem;
        private ToolStripMenuItem btnSair_menu;
        private MenuStrip menuStrip1;
        private Label h1_lbl;
        private Label label2;
        private PictureBox pictureBox1;
    }
}
