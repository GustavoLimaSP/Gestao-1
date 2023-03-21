using BLL;
using Models;
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
            try
            {
                UsuarioBLL usuarioBLL = new UsuarioBLL();
                usuarioBindingSource.DataSource = usuarioBLL.BuscarTodos();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonAdicionarUsuario_Click(object sender, System.EventArgs e)
        {
            try
            {
                new UsuarioBLL().ValidarPermissao(2);
                using (FormCadastroUsuario frm = new FormCadastroUsuario())
                {
                    frm.ShowDialog();
                }
                buttonBuscar_Click(sender, e);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonAlterar_Click(object sender, System.EventArgs e)
        {
            try
            {
                int id = ((Usuario)usuarioBindingSource.Current).Id;

                using (FormCadastroUsuario frm = new FormCadastroUsuario(true, id))
                {
                    frm.ShowDialog();
                }
                buttonBuscar_Click(sender, e);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonExcluirUsuario_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (usuarioBindingSource.Count <= 0)
                {
                    MessageBox.Show("Não existe registro para ser excluído.");
                    return;
                }

                if (MessageBox.Show("Deseja realmente excluir este registro?", "Atenção", MessageBoxButtons.YesNo) == DialogResult.No)
                    return;

                int id = ((Usuario)usuarioBindingSource.Current).Id;
                new UsuarioBLL().Excluir(id);

                MessageBox.Show("Registro excluído com sucesso!");
                buttonBuscar_Click(null, null);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonAdicionarGrupoUsuario_Click(object sender, System.EventArgs e)
        {
            try
            {
                using (FormConsultarGrupoUsuario frm = new FormConsultarGrupoUsuario())
                {
                    frm.ShowDialog();
                    UsuarioBLL usuarioBLL = new UsuarioBLL();
                    int idUsuario = ((Usuario)usuarioBindingSource.Current).Id;
                    usuarioBLL.AdicionarGrupo(idUsuario, frm.Id);
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}