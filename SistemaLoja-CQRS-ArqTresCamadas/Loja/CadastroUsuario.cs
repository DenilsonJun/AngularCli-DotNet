using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LojaBLL;
using LojaDTO;

namespace Loja
{
    public partial class CadastroUsuario : Form
    {
        string Modo = "";

        public CadastroUsuario()
        {
            InitializeComponent();
        }
        private void CarregaGrid()
        {
            try
            {
                IList<UsuarioDTO> listUsuarioDTO = new List<UsuarioDTO>();
                listUsuarioDTO = new UsuarioBLL().cargaUsuario();

                dataGridView1.DataSource = listUsuarioDTO;
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("Ocorreu o seguinte erro: {0}", ex), "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CadastroUsuario_Load(object sender, EventArgs e)
        {
            CarregaGrid();            
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int sel = dataGridView1.CurrentRow.Index;

            txtNome.Text = dataGridView1["nome", sel].Value.ToString();
            txtCadastro.Text = dataGridView1["Cadastro", sel].Value.ToString();
            txtEmail.Text = dataGridView1["email", sel].Value.ToString();
            txtLogin.Text = dataGridView1["login", sel].Value.ToString();
            txtSenha.Text = dataGridView1["senha", sel].Value.ToString();

            if(Convert.ToString(dataGridView1["situacao",sel].Value) == "A")
            {
                cbSituacao.Text = "Ativo";
            }
            else
            {
                cbSituacao.Text = "Inativo";
                
            }
            switch(cbPerfil.Text = Convert.ToString(dataGridView1["perfil", sel].Value))
            {
                case "1":
                    cbPerfil.Text = "Administrador";
                break;

                case "2":
                    cbPerfil.Text = "Operador";
                break;

                case "3":
                    cbPerfil.Text = "Gerencial";
                break;
            }

        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimparCampos();
            txtCadastro.Text = Convert.ToString(DateTime.Now);

            Modo = "Novo";

        }

        private void LimparCampos()
        {
            txtCadastro.Text = "";
            txtEmail.Text = "";
            txtLogin.Text = "";
            txtNome.Text = "";
            txtSenha.Text = "";
            cbPerfil.Text = "";
            cbSituacao.Text = "";
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            

            if (Modo == "Novo")
            {
                try
                {
                    UsuarioDTO Usuario = new UsuarioDTO();
                    
                    Usuario.nome = txtNome.Text;
                    Usuario.login = txtLogin.Text;
                    Usuario.email = txtEmail.Text;
                    Usuario.senha = txtSenha.Text;

                   if(cbSituacao.Text == "Ativo")
                    {
                        Usuario.situacao = "A";
                    }
                    else
                    {
                        Usuario.situacao = "I";
                    }
                    switch (cbPerfil.Text)
                    {
                        case "Administrador":
                            cbPerfil.Text = "1";
                            break;

                        case "Operador":
                            cbPerfil.Text = "2";
                            break;

                        case "Gerencial":
                            cbPerfil.Text = "3";
                            break;
                    }

                    Usuario.Cadastro = Convert.ToDateTime(txtCadastro.Text);
                    Usuario.perfil = Convert.ToInt32(cbPerfil.Text);
                    
                    int x = new UsuarioBLL().InserirUsuario(Usuario);
                    if (x > 0)
                    {
                        MessageBox.Show("Gravado com Sucesso", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(String.Format("Ocorreu o seguinte erro: {0}", ex), "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
            }


            if (Modo == "Editar")
            {
               
                try
                {
                    int sel = dataGridView1.CurrentRow.Index;


                    UsuarioDTO Usuario = new UsuarioDTO();
                    Usuario.codigo_cliente = Convert.ToInt32(dataGridView1["codigo_cliente", sel].Value);
                    Usuario.nome = txtNome.Text;                   
                    Usuario.login = txtLogin.Text;
                    Usuario.senha = txtSenha.Text;
                    Usuario.Cadastro = Convert.ToDateTime(txtCadastro.Text);
                    Usuario.email = txtEmail.Text;

                    if (cbSituacao.Text == "Ativo")
                    {
                        Usuario.situacao = "A";
                    }
                    else
                    {
                        Usuario.situacao = "I";
                    }
                    switch (cbPerfil.Text)
                    {
                        case "Administrador":
                            cbPerfil.Text = "1";
                            break;

                        case "Operador":
                            cbPerfil.Text = "2";
                            break;

                        case "Gerencial":
                            cbPerfil.Text = "3";
                            break;
                    }

                    Usuario.Cadastro = Convert.ToDateTime(txtCadastro.Text);
                    Usuario.perfil = Convert.ToInt32(cbPerfil.Text);


                    int x = new UsuarioBLL().EditarUsuario(Usuario);
                    if (x > 0)
                    {
                        MessageBox.Show("Gravado com Sucesso", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(String.Format("Ocorreu o seguinte erro: {0}", ex), "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            if (Modo == "Deletar")
            {

                try
                {
                    int sel = dataGridView1.CurrentRow.Index;


                    UsuarioDTO Usuario = new UsuarioDTO();
                    Usuario.codigo_cliente = Convert.ToInt32(dataGridView1["codigo_cliente", sel].Value);

                    int x = new UsuarioBLL().ExcluirUsuario(Usuario);
                    if (x > 0)
                    {
                        MessageBox.Show("Gravado com Sucesso", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(String.Format("Ocorreu o seguinte erro: {0}", ex), "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
                CarregaGrid();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Modo = "Editar";
           
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            Modo = "Deletar";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
