using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using WinCSVTest.Models;
using WinCSVTest.Presenters;
using WinCSVTest.Views;

namespace WinCSVTest
{
    /*
     * Create a Windows Form application that has the functionality to load and display CSV files data. 
     * Functionality should be able to load the attached data.csv file.
     *
     * Have a button that, when clicked, replaces the character 'a’ of any cell values, from the selected grid column, 
     * with the character ‘@’.
     *
     * Users should be able to add, edit and remove data from the grid.
     * 
     * Use the attached combo_example.csv file to populate a Combobox.
     * 
     * Combobox should display column "name" and store column ‘id’. 
     * Have a button to show when clicked, the id selected on the Combobox item.
     *
     * Consider internationalization in the implementation.
     * 
     * Consider the use of design patterns.
     * 
     * Upload your source code into the Github repository and share it with us.
     */

    public partial class MainForm : Form, IMainForm
    {
        public MainForm()
        {
            InitializeComponent();

            /* 
            // To define Clobalization an Internationalizacion, Thiscan be also define at Program Class into th Main method
            
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en");
            */
        }

        MainFormPresenter presenter;
        private bool _IsNumericOrDate;
        private string _RewriteValue;

        public string Path
        {
            get { return txtPath.Text; }
            set { txtPath.Text = value; }
        }

        public string RewriteValue
        {
            get { return _RewriteValue; }
            set { _RewriteValue = value; }
        }
        public int SelectedValue
        {
            get { return (int)cmbClassification.SelectedValue; }
            set { cmbClassification.SelectedValue = value; }
        }
        public bool IsAlphanumeric
        {
            get { return _IsNumericOrDate; }
            set { _IsNumericOrDate = value; }
        }

        public void BindCombo(List<WHClassification> listValues)
        {
            cmbClassification.DataSource = listValues;
            cmbClassification.DisplayMember = "Name";
            cmbClassification.ValueMember = "Id";
        }

        public void BindData(DataTable dt)
        {
            dgvData.DataSource = dt;
        }

        public void InitDataGrid()
        {
            // Colunm configuaration 
            // Columns["StationName"] -> Station
            // Columns["screen_id"] -> Screen Id
            // Columns["date"] -> Date
            // Columns["depth_to_water_level"] -> Depth to water level
            // Columns["comment"] -> Comment

            DataGridViewTextBoxColumn[] columns = new DataGridViewTextBoxColumn[] {
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "StationName",
                    HeaderText = "Station",
                    Name = "StationName",
                },
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "screen_id",
                    HeaderText = "Screen Id",
                    Name = "screen_id"
                },
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "date",
                    HeaderText = "Date",
                    Name = "date"
                },
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "depth_to_water_level",
                    HeaderText = "Depth To Water Level",
                    Name = "depth_to_water_level"
                },
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "comment",
                    HeaderText = "Comment",
                    Name = "comment"
                }
            };

            //DataGridViewButtonColumn buttonColumns = new DataGridViewButtonColumn
            //{
            //    HeaderText = "Select",
            //    Name = "Select",
            //    Text = "Select",
            //    UseColumnTextForButtonValue = true
            //};

            dgvData.Columns.AddRange(columns);
            //DgvData.Columns.Add(buttonColumns);

            // To avoid auto-generate columns when DataGridView receive a dataset.
            dgvData.AutoGenerateColumns = false;

            // To avoid multiple selection.
            dgvData.MultiSelect = false;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            InitDataGrid();

            presenter = new MainFormPresenter(this);
            presenter.LoadCombo();

            btnLoader.Click += BtnLoad_Click;
            btnReplaceValue.Click += BtnReplaceCellValue_Click;
            btnShowValue.Click += BtnShowSelectValue_Click;
            btnSaveChanges.Click += BtnSave_Click;
            btnEnglish.Click += BtnChangeLanguage_Click;
            btnPortuguese.Click += BtnChangeLanguage_Click;
        }

        private void BtnChangeLanguage_Click(object sender, EventArgs e)
        {
            string language = ((Button)sender).Text;
            string cultureInfo;

            switch (language)
            {
                case "Português":
                case "Portuguese":
                    cultureInfo = "pt";
                    break;
                default:
                    cultureInfo = "en";
                    break;
            }

            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(cultureInfo);
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(cultureInfo);

            this.Controls.Clear();
            InitializeComponent();
            MainForm_Load(sender, e);

            //Application.Restart();
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                // Specifies the directory that you want to always open
                // InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop),

                Title = "Data file....",
                Filter = "File (*.csv)|*.csv",
                FilterIndex = 0,
                RestoreDirectory = true // Open in last directory.
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    presenter.LoadData(openFileDialog.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Fail loading file..", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _ = ex.Message;
                }
            }
        }

        private void BtnReplaceCellValue_Click(object sender, EventArgs e)
        {
            bool RowIsEmpty = dgvData.Rows.Cast<DataGridViewRow>()
                .Any(x => x.Cells.Cast<DataGridViewCell>()
                .Any(c => c.Value != null));

            if (dgvData.RowCount == 0 || RowIsEmpty == false)
            {
                MessageBox.Show("Load file to DataGrid is required.",
                                "Warning",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            string cellValue = (dgvData.CurrentCell.Value != null &&
                                dgvData.CurrentCell.Value != DBNull.Value)
                                ? (string)dgvData.CurrentCell.Value
                                : String.Empty;

            presenter.IsAlphanumeric(cellValue);

            if (IsAlphanumeric)
            {
                MessageBox.Show("Alphanumeric values only.",
                                "Warning",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            presenter.RewriteValue(cellValue, "a", "@");
            dgvData.CurrentCell.Value = RewriteValue;
        }

        private void BtnShowSelectValue_Click(object sender, EventArgs e)
        {
            string DisplayValue = $"Id selected: {SelectedValue}";
            MessageBox.Show(DisplayValue,
                "Information",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            DataTable dataToCSV = (DataTable)dgvData.DataSource;
            presenter.SaveChanges(dataToCSV, Path);
        }
    }
}
