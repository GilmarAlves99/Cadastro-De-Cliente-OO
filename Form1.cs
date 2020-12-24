using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CadastroDeClientes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Usuario usu = new Usuario();

        DataSet mDataSet = new DataSet();
        public void preencheGrid()
        {
            mDataSet = usu.consultar();
            //atribui o resultado à propriedade DataSource da dataGridView
            dgvcliente.DataSource = mDataSet;
            dgvcliente.DataMember = "tabela_dados";
        }

        private void btncadastrar_Click(object sender, EventArgs e)
        {

            usu.setEmail(txtemail.Text);
            usu.setNome(txtnome.Text);
            usu.setTelefone(txttelefone.Text);
            usu.incluir();
            preencheGrid();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            preencheGrid();

        }
        private void dgvcliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                txtnome.Text = this.dgvcliente.Rows[dgvcliente.CurrentRow.Index].Cells[1].Value.ToString();
                txtemail.Text = this.dgvcliente.Rows[dgvcliente.CurrentRow.Index].Cells[0].Value.ToString();
                txttelefone.Text = this.dgvcliente.Rows[dgvcliente.CurrentRow.Index].Cells[2].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "Erro no grid");
            }
        }

        private void btnalterar_Click_1(object sender, EventArgs e)
        {
            usu.setEmail(txtemail.Text);
            usu.setNome(txtnome.Text);
            usu.setTelefone(txttelefone.Text);
            usu.alterar();
            preencheGrid();
        }

        private void btnexcluir_Click_1(object sender, EventArgs e)
        {
            usu.setEmail(txtemail.Text);
            usu.excluir();
            preencheGrid();
        }

        private void btnlimpar_Click(object sender, EventArgs e)
        {
            txtnome.Text = "";
            txtemail.Text = "";
            txttelefone.Text = "";
        }
    }
}
