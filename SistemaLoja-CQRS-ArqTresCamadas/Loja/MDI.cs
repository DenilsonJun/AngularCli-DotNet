using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Loja
{
    public partial class MDI : Form
    {
        private int childFormNumber = 0;
        public MDI()
        {
            InitializeComponent();
        }

        private void usuáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form cadastroUsuario = new CadastroUsuario();
            cadastroUsuario.MdiParent = this;
            cadastroUsuario.Show();
        }
    }
}
