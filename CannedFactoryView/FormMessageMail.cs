using CannedFactoryContracts.BindingModels;
using CannedFactoryContracts.BusinessLogicsContracts;
using CannedFactoryContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CannedFactoryView
{
    public partial class FormMessageMail : Form
    {
        private readonly IMessageInfoLogic _messageLogic;
        private readonly IClientLogic _clientLogic;

        public FormMessageMail(IMessageInfoLogic messageLogic, IClientLogic clientLogic)
        {
            InitializeComponent();
            _messageLogic = messageLogic;
            _clientLogic = clientLogic;

            List<ClientViewModel> list = _clientLogic.Read(null);
            if (list != null)
            {
                comboBox1.DisplayMember = "Login";
                comboBox1.ValueMember = "Id";
                comboBox1.DataSource = list;
                comboBox1.SelectedItem = null;
            }
        }

        private void FormMessageMail_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                if (comboBox1.SelectedItem != null)
                {
                    MessageInfoBindingModel model = new MessageInfoBindingModel { FromMailAddress = ((ClientViewModel)comboBox1.SelectedItem).Login };
                    Program.ConfigGrid(_messageLogic.Read(model), dataGridView1);
                }
                else
                {
                    Program.ConfigGrid(_messageLogic.Read(null), dataGridView1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
