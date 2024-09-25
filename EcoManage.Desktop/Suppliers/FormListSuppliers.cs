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

            foreach (var supplier in _suppliers)
            {
                dataGridViewSuppliers.Rows.Add(supplier.CompanyName,supplier.Email);
            }
            dataGridViewSuppliers.Columns["Email"].Width = 200;
            dataGridViewSuppliers.Columns["Email"].Width = 350;
        }
    }
}
