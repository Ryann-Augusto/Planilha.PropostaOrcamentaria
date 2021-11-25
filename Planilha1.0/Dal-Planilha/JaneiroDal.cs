﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal_Planilha
{
    public class JaneiroDal
    {
        private string MysqlConn()
        {
                //Chama a string de conexao dentro do Web.Config do projeto.
                return ConfigurationManager.AppSettings["MysqlConn"];
        }
        //Cria a funçao lista para ser usada em outras classes
        public DataTable Lista(int Ano, string mes)
        {
            string queryString = "SELECT pl_codigo, pl_categoria, pl_proposta, pl_realizado FROM tbl_"+mes+" WHERE pl_ano = ?Ano";
            using (MySqlConnection connection = new MySqlConnection(MysqlConn()))
            {
                //Select que chama atraves do ID
                MySqlCommand command = new MySqlCommand(queryString, connection);
                command.Parameters.AddWithValue("?Ano", Ano);
                command.Connection.Open();

                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = command;

                DataTable table = new DataTable();
                adapter.Fill(table);

                command.Connection.Close();

                return table;
            }
        }
        public DataTable BuscaPorId(int Codigo, string mes)
        {
            using (MySqlConnection connection = new MySqlConnection(MysqlConn()))
            {
                    //Select que chama atraves do ID
                    string queryString = "SELECT pl_codigo, pl_categoria, pl_proposta, pl_realizado FROM tbl_"+mes+" WHERE pl_codigo= ?Codigo";
                    MySqlCommand command = new MySqlCommand(queryString, connection);
                    command.Parameters.AddWithValue("?Codigo", Codigo);
                    command.Connection.Open();

                    MySqlDataAdapter adapter = new MySqlDataAdapter();
                    adapter.SelectCommand = command;

                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    command.Connection.Close();

                    return table;
            }
        }
        public void Alterar(int Codigo, decimal Proposta, decimal Realizado, string mes)
        {
            //Altera os dados no DB
            MySqlCommand cmd = new MySqlCommand("UPDATE tbl_"+mes+" SET pl_proposta = @tbl_proposta , pl_realizado = @tbl_realizacao  WHERE pl_codigo = @tbl_codigo");
            cmd.Parameters.Add("@tbl_codigo", MySqlDbType.Int32).Value = Codigo;
            cmd.Parameters.Add("@tbl_proposta", MySqlDbType.Decimal).Value = Proposta;
            cmd.Parameters.Add("@tbl_realizacao", MySqlDbType.Decimal).Value = Realizado;

            using (MySqlConnection connection = new MySqlConnection(MysqlConn()))
            {
                cmd.Connection = connection;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
        }
    }
}
