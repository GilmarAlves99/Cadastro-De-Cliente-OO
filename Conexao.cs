using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;
//using MySqlConnector;

namespace CadastroDeClientes
{
    class Conexao
    {
        private MySqlConnection connection = new MySqlConnection("Server=localhost;Database=cadastrodeclientes;Uid=root;Pwd=");
        private MySqlCommand command = new MySqlCommand();
        private DataTable data = new DataTable();
        private DataSet mDataSet = new DataSet();


        public void executeSql(string sql)
        {
            try  //Tentativa de conexão
            {
                connection.Open();
                command = connection.CreateCommand();
                command.CommandText = sql;
                command.ExecuteNonQuery();
                MessageBox.Show("Operação realizada com sucesso");
            }
            catch
            {
                MessageBox.Show("Erro executeSql");  //Quando houver erro
            }
            finally
            {
                connection.Close();
            }
        }
        public DataSet mostraResultados(string sql)
        {
            mDataSet.Clear();
            //connection.Open();
            //cria um adapter utilizando a instrução SQL para aceder à tabela
            MySqlDataAdapter mAdapter = new MySqlDataAdapter(sql, connection);



            //preenche o dataset através do adapter
            mAdapter.Fill(mDataSet, "tabela_dados");
            return mDataSet;
        }
    }

}
