﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaWeb.Areas.Identity.Data;
using SistemaWeb.Models;

namespace SistemaWeb.Controllers
{
    public class ContasController : Controller
    {
        private readonly Contexto _context;
        private readonly UserManager<SistemaWebUser> _userManager;

        public ContasController(Contexto context, UserManager<SistemaWebUser> userManager)
        {
            _context = context;
            _userManager = userManager;

        }

        // GET: Contas
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Contas.Where(c=>c.IdUser == _userManager.GetUserId(User)).Include(c => c.Classificacao).Include(c => c.Tipo);

            return View(await contexto.ToListAsync());
        }

        // GET: Contas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conta = await _context.Contas
                .Include(c => c.Classificacao)
                .Include(c => c.Tipo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (conta == null)
            {
                return NotFound();
            }

            return View(conta);
        }

        // GET: Contas/Create
        public IActionResult Create()
        {
            ViewData["ClassificacaoId"] = new SelectList(_context.Classificacao, "Id", "Id");
            ViewData["TipoId"] = new SelectList(_context.Tipo, "Id", "Id");
            return View();
        }

        // POST: Contas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descricao,DataPagamento,Valor,DataVencimento,TipoId,ClassificacaoId")] Conta conta)
        {
            if (ModelState.IsValid)
            {
                conta.IdUser = _userManager.GetUserId(User);
                _context.Add(conta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClassificacaoId"] = new SelectList(_context.Classificacao, "Id", "Id", conta.ClassificacaoId);
            ViewData["TipoId"] = new SelectList(_context.Tipo, "Id", "Id", conta.TipoId);
            return View(conta);
        }

        // GET: Contas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conta = await _context.Contas.FindAsync(id);
            if (conta == null)
            {
                return NotFound();
            }
            ViewData["ClassificacaoId"] = new SelectList(_context.Classificacao, "Id", "Id", conta.ClassificacaoId);
            ViewData["TipoId"] = new SelectList(_context.Tipo, "Id", "Id", conta.TipoId);
            return View(conta);
        }

        // POST: Contas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descricao,DataPagamento,Valor,DataVencimento,TipoId,ClassificacaoId")] Conta conta)
        {
            if (id != conta.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(conta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContaExists(conta.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClassificacaoId"] = new SelectList(_context.Classificacao, "Id", "Id", conta.ClassificacaoId);
            ViewData["TipoId"] = new SelectList(_context.Tipo, "Id", "Id", conta.TipoId);
            return View(conta);
        }

        // GET: Contas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conta = await _context.Contas
                .Include(c => c.Classificacao)
                .Include(c => c.Tipo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (conta == null)
            {
                return NotFound();
            }

            return View(conta);
        }

        // POST: Contas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var conta = await _context.Contas.FindAsync(id);
            _context.Contas.Remove(conta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContaExists(int id)
        {
            return _context.Contas.Any(e => e.Id == id);
        }
    }
}
