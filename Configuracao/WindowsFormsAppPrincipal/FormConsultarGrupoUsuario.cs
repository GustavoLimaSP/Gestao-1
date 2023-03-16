using System;
using BLL;
using System.Windows.Forms;

namespace WindowsFormsAppPrincipal
{
    public partial class FormConsultarGrupoUsuario : Form
    {
        public int Id;
        public FormConsultarGrupoUsuario()
        {
            InitializeComponent();
        }

        private void buttonSelecionar_Click(object sender, EventArgs e)
        {

        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {

        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            GrupoUsuarioBLL grupoUsuarioBLL = new GrupoUsuarioBLL();
            
            grupoUsuarioBindingSource.DataSource = grupoUsuarioBLL.BuscarPorNome(textBoxBuscar.Text);
        }
    }
}
