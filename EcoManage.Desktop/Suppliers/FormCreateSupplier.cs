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
        public FormCreateSupplier()
        {
            InitializeComponent();
        }

        private void btn_SalvarFornecedor_Click(object sender, EventArgs e)
        {
            var request = new CreateSupplierRequest
            {
                CompanyName = txt_CompanyName.Text,
                DocumentNumber = txt_DocumentNumber.Text,
                Street = txt_Street.Text,
                Email = txt_Email.Text,
                ZipCode = txt_ZipCode.Text,
                Contact = txt_Contact.Text,
            };

        }
    }
}
