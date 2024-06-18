using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CRUD.Model;

namespace CRUD.DAL
{
    internal class ItemDAL : Conexao
    {
        MySqlCommand comando = null;

        // Excluir
        public void Excluir(Item item)
        {
            try
            {
                AbrirConexao();

                comando = new MySqlCommand("DELETE FROM item WHERE @iditens = iditens", conexao);
                comando.Parameters.AddWithValue("@iditens", item.iditens);
                comando.ExecuteNonQuery();
            }
            catch (MySqlException erro)
            {
                MessageBox.Show(erro.Message, "Erro no DELETE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;

            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "Ocorre um erro ao deletar os dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
            finally
            {
                FecharConexao();
            }
        }

        // Alterar
        public void Alterar(Item item)
        {
            try
            {
                AbrirConexao();
                comando = new MySqlCommand("UPDATE item SET nome = @nome, preco = @preco, quantidade  = @quantidade," +
                    "imposto = @imposto, pagamento = @pagamento WHERE iditens = @iditens", conexao);

                comando.Parameters.AddWithValue("@iditens", item.iditens);
                comando.Parameters.AddWithValue("@nome", item.nome);
                comando.Parameters.AddWithValue("@preco", item.preco);
                comando.Parameters.AddWithValue("@quantidade", item.quantidade);
                comando.Parameters.AddWithValue("@imposto", item.imposto);
                comando.Parameters.AddWithValue("@pagamento", item.pagamento);
                comando.ExecuteNonQuery();

            }
            catch (MySqlException erro)
            {
                MessageBox.Show(erro.Message, "Erro no UPDATE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;

            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "Ocorre um erro ao alterar os dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
            finally
            {
                FecharConexao();
            }
        }

        // Salvar 
        public void Salvar(Item item)
        {
            try
            {
                AbrirConexao();
                comando = new MySqlCommand("INSERT INTO item (nome, preco, quantidade, pagamento, imposto, precofinal) "
                    + " VALUES(@nome, @preco, @quantidade, @pagamento, @imposto, @precofinal)", conexao);
                comando.Parameters.AddWithValue("@nome", item.nome);
                comando.Parameters.AddWithValue("@preco", item.preco);
                comando.Parameters.AddWithValue("@quantidade", item.quantidade);
                comando.Parameters.AddWithValue("@pagamento", item.pagamento);
                comando.Parameters.AddWithValue("@imposto", item.imposto);
                comando.Parameters.AddWithValue("@precofinal", item.precofinal);

                comando.ExecuteNonQuery();
            }
            catch (MySqlException erro)
            {
                MessageBox.Show(erro.Message, "Erro no INSERT", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;

            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "Ocorre um erro ao salvar os dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
            finally
            {
                FecharConexao();
            }
        }

        public DataTable Listar()
        {
            try
            {
                AbrirConexao();
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter();
                comando = new MySqlCommand("SELECT * FROM item", conexao);
                da.SelectCommand = comando;
                da.Fill(dt);
                return dt;
            }
            catch (MySqlException erro)
            {
                MessageBox.Show(erro.Message, "Erro ao conectar com o banco de dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;

            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "Erro ao conectar com o banco de dados da DAL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
            finally
            {
                FecharConexao();
            }
        }
    }
}
