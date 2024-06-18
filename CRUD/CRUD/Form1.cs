using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CRUD.Model;
using CRUD.DAL;
using CRUD.BLL;
namespace CRUD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            btnAlterar.Enabled = false;
            btnLimpar.Enabled = false;
        }
        private void Salvar(Item item)
        {
            ItemBLL itemBLL = new ItemBLL();

            if (txnome.Text.Trim() == string.Empty || txnome.Text.Trim().Length < 3)
            {
                MessageBox.Show("O nome não pode estar vazio e ser menor do 3 caracteres", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txnome.BackColor = Color.Coral;
                cbpagamento.BackColor = Color.White;
                txpreco.BackColor = Color.White;
            }
            else if (txpreco.Text.Trim() == string.Empty)
            {
                MessageBox.Show("O Preço não pode estar vazio", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txnome.BackColor = Color.White;
                cbpagamento.BackColor = Color.White;
                txpreco.BackColor = Color.Coral;
            }
            else if (cbpagamento.Text == string.Empty)
            {
                MessageBox.Show("O Pagamento não pode estar vazio", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txnome.BackColor = Color.White;
                cbpagamento.BackColor = Color.Coral;
                txpreco.BackColor = Color.White;
            }
            else
            {

                item.nome = txnome.Text;
                item.preco =  Convert.ToDouble(txpreco.Text);
                item.quantidade = Convert.ToInt32(txquantidade.Text);
                item.pagamento = cbpagamento.Text;
                item.imposto = item.preco * item.quantidade * 0.92;
                item.precofinal = item.imposto + item.preco * item.quantidade;

                itemBLL.Salvar(item);
                MessageBox.Show("Cadastro Realizado com sucesso", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpar();
            }

        }
        private void Alterar(Item item)
        {
            ItemBLL itemBLL = new ItemBLL();


            if (txnome.Text.Trim() == string.Empty || txnome.Text.Trim().Length < 3)
            {
                MessageBox.Show("O nome não pode estar vazio e ser menor do 3 caracteres", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txnome.BackColor = Color.Coral;
                cbpagamento.BackColor = Color.White;
                txpreco.BackColor = Color.White;
            }
            else if (txpreco.Text.Trim() == string.Empty)
            {
                MessageBox.Show("O Preço não pode estar vazio", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txnome.BackColor = Color.White;
                cbpagamento.BackColor = Color.White;
                txpreco.BackColor = Color.Coral;
            }
            else if (cbpagamento.Text == string.Empty)
            {
                MessageBox.Show("O Pagamento não pode estar vazio", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txnome.BackColor = Color.White;
                cbpagamento.BackColor = Color.Coral;
                txpreco.BackColor = Color.White;
            }
            else
            {
                item.iditens = Convert.ToInt32(txid.Text);
                item.nome = txnome.Text;
                item.preco = Convert.ToDouble(txpreco.Text);
                item.quantidade = Convert.ToInt32(txquantidade.Text);
                item.pagamento = cbpagamento.Text;
                item.imposto = Convert.ToDouble(tximposto.Text);
                itemBLL.Alterar(item);
                MessageBox.Show("Atualização Realizada com sucesso", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpar();
            }
        }


        public void Listar()
        {
            ItemBLL itemBLL = new ItemBLL();
            try
            {
                dataGridView1.DataSource = itemBLL.Listar();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "Erro ao exibir dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Ajustar largura das colunas
            dataGridView1.Columns[0].Width = 80;
            dataGridView1.Columns[1].Width = 120;
            dataGridView1.Columns[2].Width =  80;
            dataGridView1.Columns[3].Width = 80;
            dataGridView1.Columns[4].Width = 70;
            dataGridView1.Columns[5].Width = 125;
            dataGridView1.Columns[6].Width = 125;

            // Nome coluna

            dataGridView1.Columns[0].HeaderText = "Id Item";
            dataGridView1.Columns[1].HeaderText = "Nome Item";
            dataGridView1.Columns[2].HeaderText = "Preço Item";
            dataGridView1.Columns[3].HeaderText = "Quantidade";
            dataGridView1.Columns[4].HeaderText = "Pagamento";
            dataGridView1.Columns[5].HeaderText = "Imposto";
            dataGridView1.Columns[6].HeaderText = "Preço Final";
        }
        


        private void Excluir(Item item)
        {
            ItemBLL itemBLL = new ItemBLL();

            if (txid.Text == string.Empty)
            {
                MessageBox.Show("Coloque um ID para ser excluido!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (MessageBox.Show("Deseja excluir o cadastro selecionado?", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                item.iditens = Convert.ToInt32(txid.Text);
                itemBLL.Excluir(item);

                MessageBox.Show("Excluido com sucesso!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpar();
            }
        }



        public void Limpar()
        {
            txid.Clear();
            txnome.Clear();
            txpreco.Clear();
            tximposto.Clear();
            txquantidade.Clear();
            txquantidade.BackColor = Color.White;
            txnome.BackColor = Color.White;
            txid.BackColor = Color.White;

            btnAlterar.Enabled = true;
            btnSalvar.Enabled = true;
            btnAlterar.Enabled = false;
            btnExcluir.Enabled = false;

        }



        private void btnAlterar_Click(object sender, EventArgs e)
        {
            Item item = new Item();
            Alterar(item);
            txid.ReadOnly = false;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            Item item = new Item();
            Excluir(item);  
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Item item = new Item();
            Salvar(item);
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            txid.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txnome.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txpreco.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txquantidade.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            cbpagamento.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            tximposto.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            
            
            btnAlterar.Enabled = false;
            btnSalvar.Enabled = false;
            btnAlterar.Enabled = true;
            btnExcluir.Enabled = true;
            btnLimpar.Enabled = true;

            
   
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            Limpar();
        }
    }
}
