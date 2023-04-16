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
    public partial class ControlDataCountry : Form
    {
        private SqlConnection conn = null;
        private SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
        private int _idCounter, _id;
        public ControlDataCountry(int idCounter, int id, bool editing)
        {
            Owner = MainForm.ActiveForm;
            CenterToParent();
            InitializeComponent();
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);
            conn.Open();
            _idCounter = idCounter;
            _id = id;
            label1.Text = $"Попередній id: {_idCounter}";

            if (editing)
            {
                addButton.Visible = false;
                editButton.Visible = true;
                Text = "Редагування";
                label1.Text = $"Вибраний id: {id}";
            }
            else
            {
                addButton.Visible = true;
                editButton.Visible = false;
                Text = "Додавання";
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse(idTextBox.Text);
            
            string country = countryTextBox.Text;
            sqlDataAdapter = new SqlDataAdapter($"INSERT INTO located_countrys VALUES({id},N'{country}')", conn);
            Adding();
            Close();
        }

        public object Adding()
        {
            return sqlDataAdapter;
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            int idToEdit = Int32.Parse(idTextBox.Text);
            string country = countryTextBox.Text;
            sqlDataAdapter = new SqlDataAdapter($"UPDATE located_countrys SET id = {idToEdit}, country = N'{country}' WHERE id = {_id}", conn);            
            Adding();
            Close();
        }
    }
}
