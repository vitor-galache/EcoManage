using EcoManage.Desktop.Handlers;
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

namespace EcoManage.Desktop.Suppliers
{
    public partial class FormCreateSupplier : Form
    {
        private readonly SupplierHandler _handler = new SupplierHandler();
        public FormCreateSupplier()
        {
            InitializeComponent();
        }

        private async void btn_SalvarFornecedor_Click(object sender, EventArgs e)
        {
            var request = new CreateSupplierRequest
            {
                CompanyName = txt_CompanyName.Text,
                DocumentNumber = txt_DocumentNumber.Text,
                Street = txt_Street.Text,
                Number = txt_Number.Text,
                Email = txt_Email.Text,
                ZipCode = txt_ZipCode.Text,
                Contact = txt_Contact.Text,
            };
            var result = await _handler.CreateAsync(request);
            if (result.IsSuccess)
            {
                MessageBox.Show("Forncedor cadastrado com sucesso!");
                this.Close();
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
