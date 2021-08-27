using AppBarbearia.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppBarbearia.Dados
{
    public class clClienteAcoes
    {
        Conexao con = new Conexao();
        public void inserirCliente(clCliente cm)
        {
            MySqlCommand cmd = new MySqlCommand("insert into tbCliente (nomeCLi, telefoneCli, celularCli, EmailCli ) values (@nomeCLi, @telefoneCli, @celularCli, @EmailCli)", con.MyConectarBD()); // @: PARAMETRO

            cmd.Parameters.Add("@nomeCLi", MySqlDbType.VarChar).Value = cm.nomeCLi;
            cmd.Parameters.Add("@telefoneCli", MySqlDbType.VarChar).Value = cm.telefoneCli;
            cmd.Parameters.Add("@celularCli", MySqlDbType.VarChar).Value = cm.celularCli;
            cmd.Parameters.Add("@EmailCli", MySqlDbType.VarChar).Value = cm.EmailCli;

            cmd.ExecuteNonQuery();
            con.MyDesConectarBD();
        }
    }
}