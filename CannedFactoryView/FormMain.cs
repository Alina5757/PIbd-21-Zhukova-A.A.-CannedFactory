using CannedFactoryContracts.BindingModels;
using CannedFactoryContracts.BusinessLogicsContracts;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Unity;

namespace CannedFactoryView
{
    public partial class FormMain : Form
    {
        private readonly IOrderLogic _orderLogic;
        private readonly IReportLogic _reportLogic;
        private readonly IImplementerLogic _implementerLogic;
        private readonly IWorkProcess _workLogic;
        private readonly IBackUpLogic _backUpLogic;

        public FormMain(IOrderLogic orderLogic, IReportLogic reportLogic, IImplementerLogic implementerLogic, 
            IWorkProcess workLogic, IBackUpLogic backUpLogic)
        {
            InitializeComponent();
            _orderLogic = orderLogic;
            _reportLogic = reportLogic;
            _implementerLogic = implementerLogic;
            _workLogic = workLogic;
            _backUpLogic = backUpLogic;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                Program.ConfigGrid(_orderLogic.Read(null), dataGridView1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ToolStripMenuItemComponents_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormComponents>();
            form.ShowDialog();
        }

        private void ToolStripMenuItemCanneds_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormCanneds>();
            form.ShowDialog();
        }

        private void buttonCreateOrder_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormCreateOrder>();
            form.ShowDialog();
            LoadData();
        }

        private void buttonTakeOrderInWork_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                try
                {
                    _orderLogic.TakeOrderInWork(new ChangeStatusBindingModel { OrderId = id });
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonOrderReady_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                try
                {
                    _orderLogic.FinishOrder(new ChangeStatusBindingModel { OrderId = id });
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonIssuedOrder_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                try
                {
                    _orderLogic.DeliveryOrder(new ChangeStatusBindingModel { OrderId = id });
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonRefact_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void ComponentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using var dialog = new SaveFileDialog { Filter = "docx|*.docx" };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                _reportLogic.SaveCannedsToWordFile(new ReportBindingModel
                {
                    FileName = dialog.FileName
                });
                MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ComponentCannedsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormReportCannedComponents>();
            form.ShowDialog();
        }

        private void OrdersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormReportOrders>();
            form.Show();
        }

        private void ToolStripMenuItemClients_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormClient>();
            form.ShowDialog();
        }

        private void ToolStripMenuItemImplementer_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormImplementers>();
            form.ShowDialog();
        }

        private void ToolStripMenuItemWork_Click(object sender, EventArgs e)
        {
            _workLogic.DoWork(_implementerLogic, _orderLogic);
        }

        private void ToolStripMenuItemMessage_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormMessageMail>();
            form.ShowDialog();
        }

        private void ToolStripMenuItemCreateBackUp_Click(object sender, EventArgs e)
        {
            try
            {
                if (_backUpLogic != null)
                {
                    var fbd = new FolderBrowserDialog();
                    if (fbd.ShowDialog() == DialogResult.OK)
                    {
                        _backUpLogic.CreateBackUp(new BackUpSaveBinidingModel { FolderName = fbd.SelectedPath });
                        MessageBox.Show("Бекап создан", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
