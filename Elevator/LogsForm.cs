using System;
using System.Windows.Forms;

namespace Elevator
{
    public partial class LogsForm : Form
    {
        private readonly Database db;

        public LogsForm(Database database)
        {
            InitializeComponent();
            db = database;
            LoadLogs();
        }

        private void LoadLogs()
        {
            try
            {
                dataGridView1.DataSource = db.GetLogs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading logs: " + ex.Message);
            }
        }
    }
}
