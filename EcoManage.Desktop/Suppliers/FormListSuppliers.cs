using EcoManage.Desktop.Handlers;
using EcoManage.Domain.Entities;
using EcoManage.Domain.Handlers;
using EcoManage.Domain.Requests.Supplier;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EcoManage.Domain.Responses;

namespace EcoManage.Desktop.Suppliers
{
    public partial class FormListSuppliers : Form
    {
        private readonly SupplierHandler _handler = new SupplierHandler();
        private List<Supplier> _suppliers;
        public FormListSuppliers()
        {
            InitializeComponent();
        }

        private void FormListSuppliers_Load(object sender, EventArgs e)
        {
            LoadSuppliers();
        }

        private async void LoadSuppliers()
        {
            var request = new GetAllSupplierRequest();
            var result = await _handler.GetAllAsync(request);
            if (result.IsSuccess)
            {
                _suppliers = result.Data ?? [];

                dataGridViewSuppliers.Columns.Clear();
            }
            dataGridViewSuppliers.Columns.Add("Nome", "Nome do Fornecedor");
            dataGridViewSuppliers.Columns.Add("Email", "Email do Fornecedor");
            DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn();
            DataGridViewButtonColumn editButtonColumn = new DataGridViewButtonColumn();
            editButtonColumn.Name = "Editar";
            editButtonColumn.Text = "Editar";
            editButtonColumn.UseColumnTextForButtonValue = true;

            deleteButtonColumn.Name = "Excluir";
            deleteButtonColumn.Text = "Excluir";
            deleteButtonColumn.UseColumnTextForButtonValue = true;
            dataGridViewSuppliers.Columns.Add(editButtonColumn);
            dataGridViewSuppliers.Columns.Add(deleteButtonColumn);
            dataGridViewSuppliers.Columns["Excluir"].Width = 50;
            dataGridViewSuppliers.Columns["Editar"].Width = 50;
            foreach (var supplier in _suppliers)
            {
                dataGridViewSuppliers.Rows.Add(supplier.CompanyName, supplier.Email);
            }
            dataGridViewSuppliers.Columns["Email"].Width = 300;
            dataGridViewSuppliers.Columns["Email"].Width = 450;
        }

        private void btn_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
            FormPrincipal formPrincipal = new FormPrincipal();
            formPrincipal.Show();
        }

        private async void dataGridViewSuppliers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica se o botão "Excluir" foi clicado
            if (e.ColumnIndex == dataGridViewSuppliers.Columns["Excluir"].Index && e.RowIndex >= 0)
            {
                // Obtém o fornecedor correspondente da linha clicada
                var supplier = _suppliers[e.RowIndex];

                // Confirmação de exclusão
                var confirmResult = MessageBox.Show($"Você tem certeza que deseja excluir o fornecedor {supplier.CompanyName}?",
                                                    "Confirmar Exclusão",
                                                    MessageBoxButtons.YesNo);

                if (confirmResult == DialogResult.Yes)
                {

                    var deleteRequest = new DeleteSupplierRequest { Id = supplier.Id };
                    var deleteResult = await _handler.DeleteAsync(deleteRequest);

                    if (deleteResult.IsSuccess)
                    {
                        MessageBox.Show("Fornecedor excluído com sucesso!");
                        LoadSuppliers();
                    }
                    else
                    {
                        MessageBox.Show("Erro ao excluir fornecedor.");
                    }
                }
            }
            if (e.ColumnIndex == dataGridViewSuppliers.Columns["Editar"].Index && e.RowIndex >= 0)
            {
                // Obtém o fornecedor correspondente da linha clicada
                var supplier = _suppliers[e.RowIndex];

                // Abre o formulário de edição passando o fornecedor selecionado
                FormEditSupplier formEditSupplier = new FormEditSupplier(supplier);
                formEditSupplier.ShowDialog();

                // Após fechar o formulário de edição, você pode recarregar a lista de fornecedores
                LoadSuppliers();
            }
        }

        private void btn_Voltar_Click(object sender, EventArgs e)
        {
            this.Close();
            FormPrincipal formPrincipal = new FormPrincipal();
            formPrincipal.Show();
        }
    }
}
