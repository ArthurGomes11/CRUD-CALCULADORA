using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
namespace CRUD.DAL
{
    internal class Conexao
    {
        string conecta = "SERVER=localhost; DATABASE=itens; UID=root; PWD=arthur@332";

        protected MySqlConnection conexao = null;

        public void AbrirConexao()
        {
            try
            {
                conexao = new MySqlConnection(conecta);
                conexao.Open();
            }
            catch (MySqlException erro)
            {
                MessageBox.Show(erro.Message, "Erro ao conectar com o banco de dados", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "Erro ao conectar com o banco de dados", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        public void FecharConexao()
        {
            try
            {
                conexao = new MySqlConnection(conecta);
                conexao.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }
    }
}
