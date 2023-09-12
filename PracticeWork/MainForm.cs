using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace PracticeWork
{
    public partial class MainForm : Form
    {
        private SqlConnection conn = null;
        public MainForm()
        {
            InitializeComponent();
        }
        private int _country = 0, _region = 0, _area = 0, _village = 0;
        private void Form1_Load(object sender, EventArgs e)
        {

            CenterToScreen();
            // TODO: This line of code loads data into the 'dBDataSetCountry.located_countrys' table. You can move, or remove it, as needed.
            this.located_countrysTableAdapter.Fill(this.dBDataSetCountry.located_countrys);
            // TODO: This line of code loads data into the 'dBDataSetRegion.located_region' table. You can move, or remove it, as needed.
            this.located_regionTableAdapter.Fill(this.dBDataSetRegion.located_region);
            // TODO: This line of code loads data into the 'dBDataSetArea.located_area' table. You can move, or remove it, as needed.
            this.located_areaTableAdapter.Fill(this.dBDataSetArea.located_area);
            // TODO: This line of code loads data into the 'dBDataSetVillage1.located_village' table. You can move, or remove it, as needed.
            this.located_villageTableAdapter.Fill(this.dBDataSetVillage1.located_village);
            // TODO: This line of code loads data into the 'dBDataSetRegion.located_region' table. You can move, or remove it, as needed.

            // TODO: This line of code loads data into the 'dBDataSet1.located_area' table. You can move, or remove it, as needed.

            // this.located_countrysTableAdapter.Fill(this.dBDataSet.located_area);
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);   
            conn.Open();


            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM located_countrys", conn);
            DataSet countryDataSet = new DataSet();
            sqlDataAdapter.Fill(countryDataSet);
            dataGridViewCountry.DataSource = countryDataSet.Tables[0];
            paintRows(dataGridViewCountry);
            // Перша табличка країн

            sqlDataAdapter = new SqlDataAdapter("SELECT * FROM located_region", conn);
            DataSet regionDataSet = new DataSet();
            sqlDataAdapter.Fill(regionDataSet);
            dataGridViewArea.DataSource = regionDataSet.Tables[0];
            paintRows(dataGridViewArea);

            // Друга табличка областей

            sqlDataAdapter = new SqlDataAdapter("SELECT * FROM located_area", conn);
            DataSet areaDataSet = new DataSet();
            sqlDataAdapter.Fill(areaDataSet);
            dataGridViewRegion.DataSource = areaDataSet.Tables[0];
            paintRows(dataGridViewRegion);
            // Третя табличка районів

            sqlDataAdapter = new SqlDataAdapter("SELECT * FROM located_village", conn);
            DataSet villageDataSet = new DataSet();
            sqlDataAdapter.Fill(villageDataSet);
            dataGridViewVillage.DataSource = villageDataSet.Tables[0];
            paintRows(dataGridViewVillage);
            // Четверка табличка населених пунктів

            addCountryButton.Enabled = false;
            editCountryButton.Enabled = false;
            removeCountryButton.Enabled = false;

            addAreaButton.Enabled = false;
            editAreaButton.Enabled = false;
            removeAreaButton.Enabled = false;

            addRegionButton.Enabled = false;
            editRegionButton.Enabled = false;
            removeRegionButton.Enabled = false;

            addVillageButton.Enabled = false;
            editVillageButton.Enabled = false;
            removeVillageButton.Enabled = false;

        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            _country = checkMaxRows(_country, dataGridViewCountry);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT * FROM located_region WHERE country = {_country}", conn);
            DataSet regionDataSet = new DataSet();
            sqlDataAdapter.Fill(regionDataSet);
            dataGridViewArea.DataSource = regionDataSet.Tables[0];
            paintRows(dataGridViewArea);

            try
            {
                textBoxSearchCountry.Text = dataGridViewCountry.CurrentRow.Cells[1].Value.ToString().Trim();
                int id = (int)dataGridViewCountry.Rows[dataGridViewCountry.CurrentCell.RowIndex].Cells[0].Value;
                idCountryTextBox.Text = id.ToString();
            }
            catch (Exception)
            {
            }
        }
        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {

            _region = checkMaxRows(_region, dataGridViewArea);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT * FROM located_area WHERE country = {_country} AND region = {_region}", conn);
            DataSet areaDataSet = new DataSet();
            sqlDataAdapter.Fill(areaDataSet);
            dataGridViewRegion.DataSource = areaDataSet.Tables[0];
            paintRows(dataGridViewRegion);
            try
            {
                textBoxSearchArea.Text = dataGridViewArea.CurrentRow.Cells[2].Value.ToString().Trim();
                int id = (int)dataGridViewArea.Rows[dataGridViewArea.CurrentCell.RowIndex].Cells[0].Value;
                idAreaTextBox.Text = id.ToString();
            }
            catch (Exception)
            {
            }
        }
        private void dataGridView3_SelectionChanged(object sender, EventArgs e)
        {

            _area = checkMaxRows(_area, dataGridViewRegion);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT * FROM located_village WHERE country = {_country} AND region = {_region} AND area = {_area}", conn);
            DataSet regionDataSet = new DataSet();
            sqlDataAdapter.Fill(regionDataSet);
            dataGridViewVillage.DataSource = regionDataSet.Tables[0];
            paintRows(dataGridViewVillage);

            try
            {
                textBoxSearchRegion.Text = dataGridViewRegion.CurrentRow.Cells[3].Value.ToString().Trim();
                int id = (int)dataGridViewRegion.Rows[dataGridViewRegion.CurrentCell.RowIndex].Cells[0].Value;
                idRegionTextBox.Text = id.ToString();
            }
            catch (Exception)
            {
            }

        }
        private void dataGridView4_SelectionChanged(object sender, EventArgs e)
        {
            _village = checkMaxRows(_village, dataGridViewVillage);
            try
            {
                textBoxSearchVillage.Text = dataGridViewVillage.CurrentRow.Cells[4].Value.ToString().Trim();
                int id = (int)dataGridViewVillage.Rows[dataGridViewVillage.CurrentCell.RowIndex].Cells[0].Value;
                idVillageTextBox.Text = id.ToString();
            }
            catch (Exception)
            {
            }            
        }
        private void LoginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AuthorizeForm authorize = new AuthorizeForm();
            authorize.ShowDialog();
            if (authorize.Authorize())
            {
                addCountryButton.Enabled = true;
                editCountryButton.Enabled = true;
                removeCountryButton.Enabled = true;

                addAreaButton.Enabled = true;
                editAreaButton.Enabled = true;
                removeAreaButton.Enabled = true;

                addRegionButton.Enabled = true;
                editRegionButton.Enabled = true;
                removeRegionButton.Enabled = true;

                addVillageButton.Enabled = true;
                editVillageButton.Enabled = true;
                removeVillageButton.Enabled = true;
            }
        }
        private void ResetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1_SelectionChanged(sender, e);
            dataGridView2_SelectionChanged(sender, e);
            dataGridView3_SelectionChanged(sender, e);
            dataGridView4_SelectionChanged(sender, e);
        }
        private void textBoxSearchArea_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                string strToFind = "";
                strToFind = textBoxSearchArea.Text;

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT * FROM located_region WHERE region LIKE N'{strToFind}%'", conn);
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                dataGridViewArea.DataSource = dataSet.Tables[0];
                paintRows(dataGridViewArea);

                if (strToFind == "")
                {
                    sqlDataAdapter = new SqlDataAdapter($"SELECT * FROM located_region", conn);
                    dataSet = new DataSet();
                    sqlDataAdapter.Fill(dataSet);
                    dataGridViewArea.DataSource = dataSet.Tables[0];
                    paintRows(dataGridViewArea);
                }
            }
        }
        private void textBoxSearchRegion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                string strToFind = "";
                strToFind = textBoxSearchRegion.Text;

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT * FROM located_area WHERE area LIKE N'{strToFind}%'", conn);
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                dataGridViewRegion.DataSource = dataSet.Tables[0];
                paintRows(dataGridViewRegion);

                if (strToFind == "")
                {
                    sqlDataAdapter = new SqlDataAdapter($"SELECT * FROM located_area", conn);
                    dataSet = new DataSet();
                    sqlDataAdapter.Fill(dataSet);
                    dataGridViewRegion.DataSource = dataSet.Tables[0];
                    paintRows(dataGridViewRegion);
                }
            }
        }
        private void textBoxSearchVillage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                string strToFind = "";
                strToFind = textBoxSearchVillage.Text;

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT * FROM located_village WHERE village LIKE N'{strToFind}%'", conn);
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                dataGridViewVillage.DataSource = dataSet.Tables[0];
                paintRows(dataGridViewVillage);

                if (strToFind == "")
                {
                    sqlDataAdapter = new SqlDataAdapter($"SELECT * FROM located_village", conn);
                    dataSet = new DataSet();
                    sqlDataAdapter.Fill(dataSet);
                    dataGridViewVillage.DataSource = dataSet.Tables[0];
                    paintRows(dataGridViewVillage);
                }
            }
        }
        private void AddCountryButton_Click(object sender, EventArgs e)
        {
            int idCounter = dataGridViewCountry.RowCount - 1;
            ControlDataCountry controlDataCountry = new ControlDataCountry(idCounter, 0, false);
            controlDataCountry.ShowDialog();
            SqlDataAdapter sqlDataAdapter = (SqlDataAdapter)controlDataCountry.Adding();
            if (sqlDataAdapter.SelectCommand != null)
            {
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                sqlDataAdapter.SelectCommand = new SqlCommand("SELECT * FROM located_countrys", conn);
                sqlDataAdapter.Fill(dataSet);
                dataGridViewCountry.DataSource = dataSet.Tables[0];
                paintRows(dataGridViewCountry);
            }
        }
        private void editCountryButton_Click(object sender, EventArgs e)
        {
            int id = (int)dataGridViewCountry.Rows[dataGridViewCountry.CurrentCell.RowIndex].Cells[0].Value;
            int idCount = dataGridViewCountry.RowCount - 1;
            ControlDataCountry controlDataCountry = new ControlDataCountry(idCount, id, true);
            controlDataCountry.ShowDialog();
            SqlDataAdapter sqlDataAdapter = (SqlDataAdapter)controlDataCountry.Adding();
            if (sqlDataAdapter.SelectCommand != null)
            {
                DataSet dataSet = new DataSet();
                try
                {
                    sqlDataAdapter.Fill(dataSet);
                }
                catch (Exception)
                {
                    MessageBox.Show("Цей id уже використовується!");
                }
                sqlDataAdapter.SelectCommand = new SqlCommand("SELECT * FROM located_countrys", conn);
                sqlDataAdapter.Fill(dataSet);
                dataGridViewCountry.DataSource = dataSet.Tables[0];
                paintRows(dataGridViewCountry);
            }
        }
        private void removeCountryButton_Click(object sender, EventArgs e)
        {
            int id = (int)dataGridViewCountry.Rows[dataGridViewCountry.CurrentCell.RowIndex].Cells[0].Value;
            // idCountryTextBox.Text = id.ToString();
            DialogResult dialogResult = MessageBox.Show("Ви впевнені що хочете видалити виділений рядок?", "Видалення", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"DELETE FROM located_countrys WHERE id = {id}", conn);
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                sqlDataAdapter.SelectCommand = new SqlCommand("SELECT * FROM located_countrys", conn);
                sqlDataAdapter.Fill(dataSet);
                dataGridViewCountry.DataSource = dataSet.Tables[0];
                paintRows(dataGridViewCountry);
            }
        }
        private void addAreaButton_Click(object sender, EventArgs e)
        {
            int idCounter = dataGridViewArea.RowCount - 1;
            ControlDataArea controlDataArea = new ControlDataArea(idCounter, 0, false);
            controlDataArea.ShowDialog();
            SqlDataAdapter sqlDataAdapter = (SqlDataAdapter)controlDataArea.Adding();
            if (sqlDataAdapter.SelectCommand != null)
            {
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                sqlDataAdapter.SelectCommand = new SqlCommand("SELECT * FROM located_region", conn);
                sqlDataAdapter.Fill(dataSet);
                dataGridViewArea.DataSource = dataSet.Tables[0];
                paintRows(dataGridViewArea);
            }
        }
        private void editAreaButton_Click(object sender, EventArgs e)
        {
            int idArea = (int)dataGridViewArea.Rows[dataGridViewArea.CurrentCell.RowIndex].Cells[0].Value;
            int idCount = dataGridViewArea.RowCount - 1;
            ControlDataArea controlDataArea = new ControlDataArea(idCount, idArea, true);
            controlDataArea.ShowDialog();
            SqlDataAdapter sqlDataAdapter = (SqlDataAdapter)controlDataArea.Adding();
            if (sqlDataAdapter.SelectCommand != null)
            {
                DataSet dataSet = new DataSet();
                try
                {
                    sqlDataAdapter.Fill(dataSet);
                }
                catch (Exception)
                {
                    MessageBox.Show("Цей id уже використовується!");
                }
                sqlDataAdapter.SelectCommand = new SqlCommand("SELECT * FROM located_region", conn);
                sqlDataAdapter.Fill(dataSet);
                dataGridViewArea.DataSource = dataSet.Tables[0];
                paintRows(dataGridViewArea);
            }
        }
        private void removeAreaButton_Click(object sender, EventArgs e)
        {
            int id = (int)dataGridViewArea.Rows[dataGridViewArea.CurrentCell.RowIndex].Cells[0].Value;
            // idCountryTextBox.Text = id.ToString();
            DialogResult dialogResult = MessageBox.Show("Ви впевнені що хочете видалити виділений рядок?", "Видалення", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"DELETE FROM located_region WHERE id = {id}", conn);
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                sqlDataAdapter.SelectCommand = new SqlCommand("SELECT * FROM located_region", conn);
                sqlDataAdapter.Fill(dataSet);
                dataGridViewArea.DataSource = dataSet.Tables[0];
                paintRows(dataGridViewArea);
            }
        }
        private void addRegionButton_Click(object sender, EventArgs e)
        {
            int idCounter = dataGridViewRegion.RowCount - 1;
            ControlDataRegion controlDataRegion = new ControlDataRegion(idCounter, 0, false); //-----
            controlDataRegion.ShowDialog();
            SqlDataAdapter sqlDataAdapter = (SqlDataAdapter)controlDataRegion.Adding();
            if (sqlDataAdapter.SelectCommand != null)
            {
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                sqlDataAdapter.SelectCommand = new SqlCommand("SELECT * FROM located_area", conn);
                sqlDataAdapter.Fill(dataSet);
                dataGridViewRegion.DataSource = dataSet.Tables[0];
                paintRows(dataGridViewRegion);
            }
        }
        private void editRegionButton_Click(object sender, EventArgs e)
        {
            int idRegion = (int)dataGridViewRegion.Rows[dataGridViewRegion.CurrentCell.RowIndex].Cells[0].Value;
            int idCount = dataGridViewRegion.RowCount - 1;
            ControlDataRegion controlDataRegion = new ControlDataRegion(idCount, idRegion, true);
            controlDataRegion.ShowDialog();
            SqlDataAdapter sqlDataAdapter = (SqlDataAdapter)controlDataRegion.Adding();
            if (sqlDataAdapter.SelectCommand != null)
            {
                DataSet dataSet = new DataSet();
                try
                {
                    sqlDataAdapter.Fill(dataSet);
                }
                catch (Exception)
                {
                    MessageBox.Show("Цей id уже використовується!");
                }
                sqlDataAdapter.SelectCommand = new SqlCommand("SELECT * FROM located_area", conn);
                sqlDataAdapter.Fill(dataSet);
                dataGridViewRegion.DataSource = dataSet.Tables[0];
                paintRows(dataGridViewRegion);
            }
        }
        private void removeRegionButton_Click(object sender, EventArgs e)
        {
            int id = (int)dataGridViewRegion.Rows[dataGridViewRegion.CurrentCell.RowIndex].Cells[0].Value;
            // idCountryTextBox.Text = id.ToString();
            DialogResult dialogResult = MessageBox.Show("Ви впевнені що хочете видалити виділений рядок?", "Видалення", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"DELETE FROM located_area WHERE id = {id}", conn);
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                sqlDataAdapter.SelectCommand = new SqlCommand("SELECT * FROM located_area", conn);
                sqlDataAdapter.Fill(dataSet);
                dataGridViewRegion.DataSource = dataSet.Tables[0];
                paintRows(dataGridViewRegion);
            }
        }
        private void addVillageButton_Click(object sender, EventArgs e)
        {
            int idCounter = dataGridViewVillage.RowCount - 1;
            ControlDataVillage controlDataVillage = new ControlDataVillage(idCounter, 0, false); 
            controlDataVillage.ShowDialog();
            SqlDataAdapter sqlDataAdapter = (SqlDataAdapter)controlDataVillage.Adding();
            if (sqlDataAdapter.SelectCommand != null)
            {
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                sqlDataAdapter.SelectCommand = new SqlCommand("SELECT * FROM located_village", conn);
                sqlDataAdapter.Fill(dataSet);
                dataGridViewVillage.DataSource = dataSet.Tables[0];
                paintRows(dataGridViewVillage);
            }
        }
        private void editVillageButton_Click(object sender, EventArgs e)
        {
            int idVillage = (int)dataGridViewVillage.Rows[dataGridViewVillage.CurrentCell.RowIndex].Cells[0].Value;
            int idCount = dataGridViewVillage.RowCount - 1;
            ControlDataVillage controlDataVillage = new ControlDataVillage(idCount, idVillage, true);
            controlDataVillage.ShowDialog();
            SqlDataAdapter sqlDataAdapter = (SqlDataAdapter)controlDataVillage.Adding();
            if (sqlDataAdapter.SelectCommand != null)
            {
                DataSet dataSet = new DataSet();
                try
                {
                    sqlDataAdapter.Fill(dataSet);
                }
                catch (Exception)
                {
                    MessageBox.Show("Цей id уже використовується!");
                }
                sqlDataAdapter.SelectCommand = new SqlCommand("SELECT * FROM located_village", conn);
                sqlDataAdapter.Fill(dataSet);
                dataGridViewVillage.DataSource = dataSet.Tables[0];
                paintRows(dataGridViewVillage);
            }
        }
        private void removeVillageButton_Click(object sender, EventArgs e)
        {
            int id = (int)dataGridViewVillage.Rows[dataGridViewVillage.CurrentCell.RowIndex].Cells[0].Value;
            // idCountryTextBox.Text = id.ToString();
            DialogResult dialogResult = MessageBox.Show("Ви впевнені що хочете видалити виділений рядок?", "Видалення", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"DELETE FROM located_village WHERE id = {id}", conn);
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                sqlDataAdapter.SelectCommand = new SqlCommand("SELECT * FROM located_village", conn);
                sqlDataAdapter.Fill(dataSet);
                dataGridViewVillage.DataSource = dataSet.Tables[0];
                paintRows(dataGridViewVillage);
            }
        }
        private static int checkMaxRows(int row, DataGridView dataGridView)
        {
            try
            {
                row = (int)dataGridView.Rows[dataGridView.CurrentCell.RowIndex].Cells[0].Value;
                paintRows(dataGridView);
            }
            catch (Exception)
            {
            }
            return row;
        }
        private static void paintRows(DataGridView dataGridView)
        {
            for (int i = 0; i < dataGridView.RowCount; i++)
            {
                if (dataGridView.Rows[i].Index % 2 != 0)
                {
                    dataGridView.Rows[i].DefaultCellStyle.BackColor = Color.Gainsboro;
                }
            }
        }
    }
}
