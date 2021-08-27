using AppBarbearia.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppBarbearia.Dados
{
    public class clBarbeiroAcoes
    {
        Conexao con = new Conexao();

        public void inserirBarb(clBarbeiro cm)
        {
            MySqlCommand cmd = new MySqlCommand("insert into tbBarbeiro (nomeBarbeiro ) values (@nomeBarbeiro)", con.MyConectarBD()); // @: PARAMETRO

            cmd.Parameters.Add("@nomeBarbeiro", MySqlDbType.VarChar).Value = cm.nomeBarbeiro;

            cmd.ExecuteNonQuery();
            con.MyDesConectarBD();
        }
    }
}