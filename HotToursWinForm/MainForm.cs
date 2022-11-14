
using Hot_Tours_BL;
using Hot_Tours_BL.Models;

namespace Hot_tours
{
    public partial class MainForm : Form
    {
        BusinessLogic businessLogic = new BusinessLogic();

        private readonly BindingSource bindingSource;
        public MainForm()
        {
            InitializeComponent();
            toursDataGridView.AutoGenerateColumns = false;
            bindingSource = new BindingSource();
            bindingSource.DataSource = businessLogic.Tours;
            toursDataGridView.DataSource = bindingSource;
            toursDataGridView.AllowUserToAddRows = false;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InfoTourForm tourForm = new InfoTourForm();
            tourForm.Text = "���������� ����";
            if (tourForm.ShowDialog(this) == DialogResult.OK)
            {
                businessLogic.AddTour(tourForm.Tour);
                bindingSource.ResetBindings(false);
                CalculateStats();
                MessageBox.Show("��������� ����� ������!");
            }
        }
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tour data = (Tour)toursDataGridView.Rows[toursDataGridView.SelectedRows[0].Index].DataBoundItem;
            InfoTourForm tourForm = new InfoTourForm((Tour)toursDataGridView
                .Rows[toursDataGridView.SelectedRows[0].Index].DataBoundItem);
            tourForm.Text = "��������� ����";
            if (tourForm.ShowDialog(this) == DialogResult.OK)
            {
                // ��������� � ��
                businessLogic.EditTour(tourForm.Tour,
                    toursDataGridView.SelectedRows[0].Index);
                bindingSource.ResetBindings(false);
                CalculateStats();
                MessageBox.Show("������ ��������!");
            }

        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (toursDataGridView.Columns[e.ColumnIndex].Name == "DirectionColumn" &&
                e.Value != null)
            {
                Direction val = (Direction)e.Value;
                switch (val)
                {
                    case Direction.Tunisia:
                        e.Value = "�����";
                        break;
                    case Direction.UAE:
                        e.Value = "���";
                        break;
                    case Direction.Crimea:
                        e.Value = "����";
                        break;
                    case Direction.Turkey:
                        e.Value = "������";
                        break;
                    case Direction.Egypt:
                        e.Value = "������";
                        break;
                }
            }
            else if (toursDataGridView.Columns[e.ColumnIndex].Name == "DateColumn" &&
                e.RowIndex < businessLogic.Tours.Count)
            {
                e.Value = businessLogic.Tours[e.RowIndex].Date.Date;
            }
            else if ((toursDataGridView.Columns[e.ColumnIndex].Name == "TotalColumn") &&
                e.RowIndex < businessLogic.Tours.Count)
            {
                e.Value = businessLogic.Tours[e.RowIndex].PriceForMan *
                    businessLogic.Tours[e.RowIndex].AmountOfMan *
                    businessLogic.Tours[e.RowIndex].AmountOfDays;
            }
        }


        private void CalculateStats()
        {
            totalToolStripStatusLabel.Text = businessLogic.ToursAmount();
            totalSumToolStripStatusLabel.Text = businessLogic.TotalSum();
            surchargeCountToolStripStatusLabel.Text = businessLogic.SurchargeAmount();
            surchargeSumToolStripStatusLabel.Text = businessLogic.SurchargeSum();
        }


        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            editToolStripMenuItem.Enabled = deleteToolStripMenuItem.Enabled =
                businessLogic.Tours.Count() > 0;
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("�� �������?", "�������������� �� ��������!", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                // ��������� � ��
                businessLogic.DeleteTour((Tour)toursDataGridView
                    .Rows[toursDataGridView.SelectedRows[0].Index].DataBoundItem);
                bindingSource.ResetBindings(false);
                CalculateStats();
            }
        }
    }
}
