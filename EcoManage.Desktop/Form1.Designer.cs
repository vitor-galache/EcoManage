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
            fornecedoresToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripMenuItem();
            ediitarToolStripMenuItem = new ToolStripMenuItem();
            listarFornecedoresToolStripMenuItem = new ToolStripMenuItem();
            excluirToolStripMenuItem = new ToolStripMenuItem();
            minhaContaToolStripMenuItem = new ToolStripMenuItem();
            btnSair_menu = new ToolStripMenuItem();
            menuStrip1 = new MenuStrip();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // fornecedoresToolStripMenuItem
            // 
            fornecedoresToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem1, ediitarToolStripMenuItem, listarFornecedoresToolStripMenuItem, excluirToolStripMenuItem });
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
            // 
            // ediitarToolStripMenuItem
            // 
            ediitarToolStripMenuItem.Name = "ediitarToolStripMenuItem";
            ediitarToolStripMenuItem.Size = new Size(239, 24);
            ediitarToolStripMenuItem.Text = "Editar";
            // 
            // listarFornecedoresToolStripMenuItem
            // 
            listarFornecedoresToolStripMenuItem.Name = "listarFornecedoresToolStripMenuItem";
            listarFornecedoresToolStripMenuItem.Size = new Size(239, 24);
            listarFornecedoresToolStripMenuItem.Text = "Listar Fornecedores";
            // 
            // excluirToolStripMenuItem
            // 
            excluirToolStripMenuItem.Name = "excluirToolStripMenuItem";
            excluirToolStripMenuItem.Size = new Size(239, 24);
            excluirToolStripMenuItem.Text = "Excluir";
            // 
            // minhaContaToolStripMenuItem
            // 
            minhaContaToolStripMenuItem.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            minhaContaToolStripMenuItem.ForeColor = Color.LightGray;
            minhaContaToolStripMenuItem.Name = "minhaContaToolStripMenuItem";
            minhaContaToolStripMenuItem.Padding = new Padding(5);
            minhaContaToolStripMenuItem.Size = new Size(124, 34);
            minhaContaToolStripMenuItem.Text = "Minha Conta";
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
            menuStrip1.Items.AddRange(new ToolStripItem[] { fornecedoresToolStripMenuItem, minhaContaToolStripMenuItem, btnSair_menu });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(6, 5, 5, 5);
            menuStrip1.Size = new Size(800, 44);
            menuStrip1.TabIndex = 3;
            menuStrip1.Text = "menuStrip1";
            // 
            // FormPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(117, 117, 117);
            ClientSize = new Size(800, 450);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.None;
            MainMenuStrip = menuStrip1;
            Name = "FormPrincipal";
            Opacity = 0.9D;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "S";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStripMenuItem fornecedoresToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem ediitarToolStripMenuItem;
        private ToolStripMenuItem listarFornecedoresToolStripMenuItem;
        private ToolStripMenuItem excluirToolStripMenuItem;
        private ToolStripMenuItem minhaContaToolStripMenuItem;
        private ToolStripMenuItem btnSair_menu;
        private MenuStrip menuStrip1;
    }
}
