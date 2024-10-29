using EcoManage.Desktop.Handlers;
using EcoManage.Domain.Entities;
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
    public partial class FormEditSupplier : Form
    {
        private Supplier _supplier = null!;
        private SupplierHandler _handler = new SupplierHandler();
        public FormEditSupplier(Supplier supplier)
        {
            InitializeComponent();
            _supplier = supplier;
            LoadSupplierData();
        }
        private void LoadSupplierData()
        {
            txt_CompanyName.Text = _supplier.CompanyName;
            txt_Email.Text = _supplier.Email.Address;
            txt_Contact.Text = _supplier.Contact;
        }

        private async void btn_AtualizarFornecedor_Click(object sender, EventArgs e)
        {
            var request = new UpdateSupplierRequest
            {
                Id = _supplier.Id,
                Email = txt_Email.Text,
                CompanyName = txt_CompanyName.Text,
                Contact = txt_Contact.Text
            };
            var result = await _handler.UpdateAsync(request);
            if (result.IsSuccess)
            {
                MessageBox.Show(result.Message);
                this.Close();
            }
            else
            {
                MessageBox.Show(result.Message);
                this.Close();
            }
        }

        private void btn_Voltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
