using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppPrincipal
{
    public partial class FormLogin : Form
    {
        public bool Logou;
        public FormLogin()
        {
            InitializeComponent();
            Logou = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Logou = true;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Senha incorreta");
        }
    }
}
