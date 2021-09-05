using AppBarbearia.Dados;
using AppBarbearia.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppBarbearia.Controllers
{
    public class HomeController : Controller
    {
        clCliente modCliente = new clCliente();
        clClienteAcoes acCliente = new clClienteAcoes();

        clBarbeiro modBarbeiro = new clBarbeiro();
        clBarbeiroAcoes acBarbeiro = new clBarbeiroAcoes();

        clAtendimentoAcoes acAtend = new clAtendimentoAcoes();



        //Carrega barbeiro 
        public void carregarBarbeiro()
        {
            List<SelectListItem> babeiros = new List<SelectListItem>();

            using (MySqlConnection con = new MySqlConnection("Server=localhost;port=3307; DataBase=BdBarbearia; user id=root;password=361190"))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from tbBarbeiro", con);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    babeiros.Add(new SelectListItem
                    {
                        Text = rdr[1].ToString(),
                        Value = rdr[0].ToString()
                    });
                }
                con.Close();

            }

            ViewBag.barb = new SelectList(babeiros, "Value", "Text");
        }
        //Carrega Cliente do Barbeiro
        public void carregarClientes()
        {
            List<SelectListItem> clientes = new List<SelectListItem>();

            using (MySqlConnection con = new MySqlConnection("Server=localhost;port=3307; DataBase=BdBarbearia; user id=root;password=361190"))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from tbCliente", con);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    clientes.Add(new SelectListItem
                    {
                        Text = rdr[1].ToString(),
                        Value = rdr[0].ToString()
                    });
                }
                con.Close();

            }

            ViewBag.cli = new SelectList(clientes, "Value", "Text");
        }


        public ActionResult consAgenda()
        {
            GridView gvAtend = new GridView();
            gvAtend.DataSource = acAtend.selecionaAgenda();
            gvAtend.DataBind();
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            gvAtend.RenderControl(htw);
            ViewBag.GridViewString = sw.ToString();
            return View();
        }
        public ActionResult consAgendaBuscaData()
        {
            return View();
        }
        [HttpPost]
        public ActionResult consAgendaBuscaData(clAtendimento modeloAtend)
        {
            GridView gvAtend = new GridView();
            gvAtend.DataSource = acAtend.selecionaAgendaData(modeloAtend);
            gvAtend.DataBind();
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            gvAtend.RenderControl(htw);
            ViewBag.GridViewString = sw.ToString();
            return View();

        }

        public ActionResult Index()
        {
            return View();
        }
        //Cadastro do cliente
        public ActionResult cadCliente()
        {

            return View();
        }
        [HttpPost]
        public ActionResult cadCliente(FormCollection frm)
        {

            modCliente.nomeCLi = frm["txtNmCliente"];
            modCliente.telefoneCli = frm["txtTelefone"];
            modCliente.celularCli = frm["txtCelular"];
            modCliente.EmailCli = frm["txtEmail"];

            acCliente.inserirCliente(modCliente);

            ViewBag.msg = "Cadastro Realizado com sucesso!";
            return View();
        }
        public ActionResult cadBarb()
        {
            return View();
        }
        [HttpPost]
        public ActionResult cadBarb(FormCollection frm)
        {

            modBarbeiro.nomeBarbeiro = frm["txtBarbeiro"];
            acBarbeiro.inserirBarb(modBarbeiro);
            ViewBag.msg = "Cadastro Realizado com sucesso!";
            return View();
        }
        public ActionResult ConsultaClientes()
        {
            clClienteAcoes ac = new clClienteAcoes();
            GridView dgv = new GridView(); // Instância para a tabela
            dgv.DataSource = ac.consultaCli(); //Atribuir ao grid o resultado da consulta
            dgv.DataBind(); //Confirmação do Grid
            StringWriter sw = new StringWriter(); //Comando para construção do Grid na tela
            HtmlTextWriter htw = new HtmlTextWriter(sw); //Comando para construção do Grid na tela
            dgv.RenderControl(htw); //Comando para construção do Grid na tela
            ViewBag.GridViewString = sw.ToString(); //Comando para construção do Grid na tela
            return View();
        }

        public ActionResult cadAtendimento()
        {
            carregarBarbeiro();
            carregarClientes();
            return View();
        }
        [HttpPost]
        public ActionResult cadAtendimento(clAtendimento modeloAtend)
        {

            carregarBarbeiro();
            carregarClientes();
            acAtend.TestarAgenda(modeloAtend);

            if (modeloAtend.confAgendamento == "1")
            {
                modeloAtend.codCli = Request["cli"];
                modeloAtend.codBarbeiro = Request["barb"];
                acAtend.inserirAgenda(modeloAtend);
                ViewBag.msg = "Agendamento realizado com sucesso";
            }
            else
            {
                ViewBag.msg = "Horário indisponível, por favor escolaher outra data/hora";
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}