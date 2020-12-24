using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CadastroDeClientes
{
    class Usuario
    {
        private string email;
        private string nome;
        private string telefone;
        //variável
        string sql;
        //objetos
        Conexao con = new Conexao();
        DataSet mDataSet = new DataSet();


        //get e set
        public string getEmail()
        {
            return email;
        }
        public void setEmail(string email)
        {
            this.email = email;
        }



        public string getNome()
        {
            return nome;
        }
        public void setNome(string nome)
        {
            this.nome = nome;
        }



        public string getTelefone()
        {
            return telefone;
        }
        public void setTelefone(string telefone)
        {
            this.telefone = telefone;
        }

        public void incluir()
        {
            sql = "insert into clientes (email,nome,telefone)values('" + email + "','" + nome + "','" + telefone + "')";
            MessageBox.Show(sql);
            con.executeSql(sql);
        }
        public DataSet consultar()
        {
            sql = "Select * from clientes";
            mDataSet = con.mostraResultados(sql);
            return mDataSet;
        }
        public void alterar()
        {
            sql = "update clientes set nome='" + nome + "', telefone='" + telefone + "' , email='" + email + "' where email='" + email + "'";
            // MessageBox.Show(sql);
            con.executeSql(sql);
        }

        public void excluir()
        {
            sql = "delete from clientes where email='" + email + "'";
            con.executeSql(sql);
        }

    }
}
