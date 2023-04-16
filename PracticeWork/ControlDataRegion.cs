using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracticeWork
{
    public partial class ControlDataRegion : Form
    {
        private SqlConnection conn = null;
        private SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
        private int _idCounter, _idToChange;
        public ControlDataRegion(int idCounter, int idToChange, bool editing)
        {
            Owner = MainForm.ActiveForm;
            CenterToParent();
            InitializeComponent();
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);
            conn.Open();
            _idCounter = idCounter;
            _idToChange = idToChange;
            label1.Text = $"Попередній id: {_idCounter}";

            if (editing)
            {
                addButton.Visible = false;
                editButton.Visible = true;
                Text = "Редагування";
                label1.Text = $"Вибраний id: {idToChange}";
            }
            else
            {
                addButton.Visible = true;
                editButton.Visible = false;
                Text = "Додавання";
            }
        }
        private void editButton_Click(object sender, EventArgs e)
        {
            int idCountry = Int32.Parse(idCountryTextBox.Text);
            int idRegion = Int32.Parse(idRegionTextBox.Text);
            int idArea = Int32.Parse(idAreaTextBox.Text);
            string area = areaTextBox.Text;

            sqlDataAdapter = new SqlDataAdapter($"UPDATE located_area SET id = {idArea}, country = {idCountry}, region = {idRegion}, area = N'{area}' WHERE id = {_idToChange}", conn);
            Adding();
            Close();
        }

        //_region = checkMaxRows(_region, dataGridViewArea);
        //SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT * FROM located_area WHERE region = {_region}", conn);
        private void addButton_Click(object sender, EventArgs e)
        {
            int idCountry = Int32.Parse(idCountryTextBox.Text);
            int idRegion = Int32.Parse(idRegionTextBox.Text);
            int idArea = Int32.Parse(idAreaTextBox.Text);
            string area = areaTextBox.Text;
            sqlDataAdapter = new SqlDataAdapter($"INSERT INTO located_area VALUES({idArea}, {idCountry}, {idRegion}, N'{area}')", conn);
            Adding();
            Close();
        }

        public object Adding()
        {
            return sqlDataAdapter;
        }
    }
}
