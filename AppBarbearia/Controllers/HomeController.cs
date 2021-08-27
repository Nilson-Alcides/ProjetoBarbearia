using AppBarbearia.Dados;
using AppBarbearia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppBarbearia.Controllers
{
    public class HomeController : Controller
    {
        clCliente modCliente = new clCliente();
        clClienteAcoes acCliente = new clClienteAcoes();

        clBarbeiro modBarbeiro = new clBarbeiro();
        clBarbeiroAcoes acBarbeiro = new clBarbeiroAcoes();
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