using CannedFactoryContracts.BindingModels;
using CannedFactoryContracts.BusinessLogicsContracts;
using CannedFactoryContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CannedFactoryView
{
    public partial class FormImplementer : Form
    {
        public int Id { set { id = value; } }
        private readonly IImplementerLogic _logic;
        private int? id;

        public FormImplementer(IImplementerLogic logic)
        {
            InitializeComponent();
            _logic = logic;
        }

        private void FormImplementer_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    var view = _logic.Read(new ImplementerBindingModel { Id = id })?[0];
                    if (view != null)
                    {
                        textBoxFIO.Text = view.FIO;
                        textBoxTimeWork.Text = Convert.ToString(view.WorkingTime);
                        textBoxTimeRest.Text = Convert.ToString(view.PauseTime);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxFIO.Text))
            {
                MessageBox.Show("Заполните ФИО", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxTimeWork.Text))
            {
                MessageBox.Show("Заполните время работы", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxTimeRest.Text))
            {
                MessageBox.Show("Заполните время отдыха", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                _logic.CreateOrUpdate(new ImplementerBindingModel
                {
                    Id = id,
                    FIO = textBoxFIO.Text,
                    TimeWork = Convert.ToInt32(textBoxTimeWork.Text),
                    TimeRest = Convert.ToInt32(textBoxTimeRest.Text)
                });
                MessageBox.Show("Создание прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}