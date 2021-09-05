using AppBarbearia.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace AppBarbearia.Dados
{
    public class clAtendimentoAcoes
    {
        Conexao con = new Conexao();

        public void TestarAgenda(clAtendimento agenda)
        {
            MySqlCommand cmd = new MySqlCommand("select * from tbAtendimento where dataAtend = @data and horaAtend = @hora", con.MyConectarBD());

            cmd.Parameters.Add("@data", MySqlDbType.VarChar).Value = agenda.dataAtend;
            cmd.Parameters.Add("@hora", MySqlDbType.VarChar).Value = agenda.horaAtend;

            MySqlDataReader leitor;

            leitor = cmd.ExecuteReader();

            if (leitor.HasRows)
            {
                // while (leitor.Read())
                ///  {
                agenda.confAgendamento = "0";
                //   }

            }

            else
            {
                agenda.confAgendamento = "1";
            }

            con.MyDesConectarBD();
        }


        public void inserirAgenda(clAtendimento cm)
        {

            MySqlCommand cmd = new MySqlCommand("insert into tbAtendimento(dataAtend, horaAtend, codBarbeiro, codCli) values (@data, @hora,@codBarbeiro,@codCli)", con.MyConectarBD());
            cmd.Parameters.Add("@data", MySqlDbType.VarChar).Value = cm.dataAtend;
            cmd.Parameters.Add("@hora", MySqlDbType.VarChar).Value = cm.horaAtend;
            cmd.Parameters.Add("@codBarbeiro", MySqlDbType.VarChar).Value = cm.codBarbeiro;
            cmd.Parameters.Add("@codCli", MySqlDbType.VarChar).Value = cm.codCli;

            cmd.ExecuteNonQuery();
            con.MyDesConectarBD();
        }
        public DataTable selecionaAgenda()
        {
            // MySqlCommand cmd = new MySqlCommand("Select * from tbAtendimento", con.MyConectarBD());
            MySqlCommand cmd = new MySqlCommand("select t1.codAtend as Código,t2.nomeMedico as Médico,t3.nomePac as Paciente,t4.especialidade as Especialidade,t1.dataAtend as Data,t1.horaAtend as Hora from tbAtendimento as t1" +
                                                " INNER JOIN tbmedico as t2 ON t1.codMedico = t2.codMedico " +
                                               " INNER JOIN tbesp as t4 ON t4.codEspecialidade = t2.codEspecialidade" +
                                               " INNER JOIN tbPaciente as t3 ON t3.codPac = t1.codPac; ", con.MyConectarBD());

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable atend = new DataTable();
            da.Fill(atend);
            con.MyDesConectarBD();
            return atend;
        }

        public DataTable selecionaAgenda(clAtendimento cm)
        {
            MySqlCommand cmd = new MySqlCommand("Select * from tbAtendimento where dataAtend=@dataAtend ", con.MyConectarBD());
            cmd.Parameters.Add("@dataAtend", MySqlDbType.VarChar).Value = cm.dataAtend;
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable atend = new DataTable();
            da.Fill(atend);
            con.MyDesConectarBD();
            return atend;
        }
    }
}