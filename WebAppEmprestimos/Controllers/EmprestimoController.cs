﻿using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Threading.Tasks;
using WebAppEmprestimos.Data;
using WebAppEmprestimos.Models;
using WebAppEmprestimos.Services.EmprestimosService;
using WebAppEmprestimos.Services.SessaoService;

namespace WebAppEmprestimos.Controllers
{
    public class EmprestimoController : Controller
    {
        readonly private ISessaoInterface _sessaoInterface;
        private readonly IEmprestimosInterface _emprestimosInterface;

        public EmprestimoController(IEmprestimosInterface emprestimosInterface, ISessaoInterface sessaoInterface)
        {
            _sessaoInterface = sessaoInterface;
            _emprestimosInterface = emprestimosInterface;
        }

        public async Task<IActionResult> Index()
        {
            var usuario = _sessaoInterface.BuscarSessao();
            if(usuario == null)
            {
                return RedirectToAction("Login", "Login");
            }

            var emprestimos = await _emprestimosInterface.BuscarEmprestimos();
            return View(emprestimos.Dados);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            var usuario = _sessaoInterface.BuscarSessao();
            if (usuario == null)
            {
                return RedirectToAction("Login", "Login");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int? id)
        {
            var usuario = _sessaoInterface.BuscarSessao();
            if (usuario == null)
            {
                return RedirectToAction("Login", "Login");
            }

            var emprestimo = await _emprestimosInterface.BuscarEmprestimosPorId(id);    

            return View(emprestimo.Dados);
        }


        [HttpGet]
        public async Task<IActionResult> Excluir(int? id)
        {
            var usuario = _sessaoInterface.BuscarSessao();
            if (usuario == null)
            {
                return RedirectToAction("Login", "Login");
            }

            var emprestimo = await _emprestimosInterface.BuscarEmprestimosPorId(id);

            return View(emprestimo.Dados);
        }

        public async Task<IActionResult> Exportar()
        {
            var dados = await _emprestimosInterface.BuscaDadosEmprestimoExcel();

            using (XLWorkbook workBook = new XLWorkbook())
            {
                workBook.AddWorksheet(dados, "Dados Empréstimos");

                using (MemoryStream ms = new MemoryStream())
                {
                    workBook.SaveAs(ms);
                    return File(ms.ToArray(), "application/vnd.openxmlformats-officedocument.spredsheetml.sheet", "Emprestimo.xls");
                }                  
            }
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(EmprestimosModel emprestimo)
        {
            if (ModelState.IsValid)
            {
                var emprestimoResult = await _emprestimosInterface.CadastrarEmprestimo(emprestimo);

                if (emprestimoResult.Status)
                {
                    TempData["MensagemSucesso"] = emprestimoResult.Mensagem;
                }
                else
                {
                    TempData["MensagemErro"] = emprestimoResult.Mensagem;
                    return View(emprestimo);
                }

                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Editar(EmprestimosModel emprestimo)
        {
            if (ModelState.IsValid)
            {
                var emprestimoResult = await _emprestimosInterface.EditarEmprestimo(emprestimo);

                if (emprestimoResult.Status)
                {
                    TempData["MensagemSucesso"] = emprestimoResult.Mensagem;
                }
                else
                {
                    TempData["MensagemErro"] = emprestimoResult.Mensagem;
                    return View(emprestimo);  
                }

                return RedirectToAction("Index");
            }

            TempData["MensagemErro"] = "Ocorreu um erro ao realizar a edição!";
            return View(emprestimo);
        }

        [HttpPost]
        public async Task<IActionResult> Excluir(EmprestimosModel emprestimo)
        {
            if (emprestimo == null)
            {
                TempData["MensagemErro"] = "Empréstimo não localizado!";
                return View(emprestimo);
            }

            var emprestimoResult = await _emprestimosInterface.RemoveEmprestimo(emprestimo);

            if (emprestimoResult.Status)
            {
                TempData["MensagemSucesso"] = emprestimoResult.Mensagem;
            }
            else 
            {
                TempData["MensagemErro"] = emprestimoResult.Mensagem;
                return View(emprestimo);
            }

            return RedirectToAction("Index");
        }
    }
}
