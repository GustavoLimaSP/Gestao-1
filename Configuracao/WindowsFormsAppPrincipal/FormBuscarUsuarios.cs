using BLL;
using Models;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowsFormsAppPrincipal
{
    public partial class FormBuscarUsuarios : Form
    {
        public FormBuscarUsuarios()
        {
            InitializeComponent();
        }

        private void buttonBuscar_Click(object sender, System.EventArgs e)
        {
            UsuarioBLL usuarioBLL = new UsuarioBLL();            
            usuarioBindingSource.DataSource = usuarioBLL.BuscarTodos();
        }

        private void buttonAdicionarUsuario_Click(object sender, System.EventArgs e)
        {
            using (FormCadastroUsuario frm = new FormCadastroUsuario())
            {
                frm.ShowDialog();
            }
            buttonBuscar_Click(sender, e);
        }

        private void buttonAlterar_Click(object sender, System.EventArgs e)
        {
            int id = ((Usuario)usuarioBindingSource.Current).Id;

            using (FormCadastroUsuario frm = new FormCadastroUsuario(true, id))
            {
                frm.ShowDialog();
            }
            buttonBuscar_Click(sender, e);
        }
    }
}