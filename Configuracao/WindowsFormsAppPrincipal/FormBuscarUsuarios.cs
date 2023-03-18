using BLL;
using Models;
using System;
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
            try
            {
                new UsuarioBLL().ValidarPermissao(4);
                buttonBuscar_Click(sender, e);

                using (FormCadastroUsuario frm = new FormCadastroUsuario())
                {
                    frm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonAlterar_Click(object sender, System.EventArgs e)
        {
            if (usuarioBindingSource.Count <= 0)
            {
                MessageBox.Show("Não existe registro para ser alterado.");
                return;
            }

            int id = ((Usuario)usuarioBindingSource.Current).Id;

            using (FormCadastroUsuario frm = new FormCadastroUsuario(true, id))
            {
                frm.ShowDialog();
            }
            buttonBuscar_Click(sender, e);
        }

        private void buttonExcluirUsuario_Click(object sender, System.EventArgs e)
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

        private void buttonAdicionarGrupoUsuario_Click(object sender, System.EventArgs e)
        {
            using (FormConsultarGrupoUsuario frm = new FormConsultarGrupoUsuario())
            {
                frm.ShowDialog();

                if (frm.Id == 0)
                    return;

                UsuarioBLL usuarioBLL = new UsuarioBLL();
                int idUsuario = ((Usuario)usuarioBindingSource.Current).Id;
                usuarioBLL.AdicionarGrupo(idUsuario, frm.Id);
            }
        }
        private void buttonExcluirGrupoUsuario_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (usuarioBindingSource.Count == 0 || grupoUsuariosBindingSource.Count == 0)
                {
                    MessageBox.Show("Não existe grupo de usuário para ser excluído.");
                    return;
                }

                int idUsuario = ((Usuario)usuarioBindingSource.Current).Id;
                int idGrupoUsuario = ((GrupoUsuario)grupoUsuariosBindingSource.Current).Id;
                new UsuarioBLL().RemoverGrupoUsuario(idUsuario, idGrupoUsuario);
                grupoUsuariosBindingSource.RemoveCurrent();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FormBuscarUsuarios_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }
    }
}