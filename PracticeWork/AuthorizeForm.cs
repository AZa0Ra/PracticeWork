using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracticeWork
{
    public partial class AuthorizeForm : Form
    {
        private int _counter = 0;
        private bool _isAuthorized = false;
        public AuthorizeForm()
        {
            Owner = MainForm.ActiveForm;
            CenterToParent();
            InitializeComponent();
        }
        private void label1_Click(object sender, EventArgs e)
        {
            _counter++;
            if (_counter % 2 != 1)
            {
                PasswordTextBox.UseSystemPasswordChar = true;
                Image image = Image.FromFile(@"images\ClosedEye.png");
                label1.Image = image;
            } 
            else
            {
                PasswordTextBox.UseSystemPasswordChar = false;
                Image image = Image.FromFile(@"images\OpenedEye.png");
                label1.Image = image;
            }
                
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (LoginTextBox.Text == "admin" && PasswordTextBox.Text == "admin")
            {
                MessageBox.Show("Ви успішно авторизувались", "Авторизація", buttons: MessageBoxButtons.OK);
                _isAuthorized = true;
                Authorize();
                Close();
            }
            else MessageBox.Show("Не вірний логін або пароль", "Авторизація", buttons: MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }

        public bool Authorize()
        {
            return _isAuthorized;
        }

        private void AuthorizeForm_Load(object sender, EventArgs e)
        {
            PasswordTextBox.UseSystemPasswordChar = true;
            Image image = Image.FromFile(@"images\ClosedEye.png");
            label1.Image = image;
        }
    }
}
