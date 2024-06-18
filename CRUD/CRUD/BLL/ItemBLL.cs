using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CRUD.Model;
using CRUD.DAL;

namespace CRUD.BLL
{
    internal class ItemBLL
    {
        ItemDAL itemDAL = new ItemDAL();

        // Excluir

        public void Excluir(Item item)
        {
            try
            {
                itemDAL.Excluir(item);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }


        // Alterar
        public void Alterar(Item item)
        {
            try
            {
                itemDAL.Alterar(item);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }
        public void Salvar(Item item)
        {
            try
            {
                itemDAL.Salvar(item);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public DataTable Listar()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = itemDAL.Listar();
                return dt;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "Erro ao conectar com o banco de dados da BLL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw erro;
            }
        }

    }
}

