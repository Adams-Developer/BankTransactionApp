﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankTransactionApplication.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;

namespace BankTransactionApplication.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly TransactionDbContext _context;

        public TransactionsController(TransactionDbContext context)
        {
            _context = context;
        }

        // GET: Transaction
        public async Task<IActionResult> Index()
        {
            return View(await _context.Transactions.ToListAsync());
        }

        // GET: Transactions/AddOrEdit(Insert)
        // GET: Transactions/AddOrEdit/5(Update)
        //[NoDirectAccess]
        public async Task<IActionResult> AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new TransactionModel());
            else
            {
                var transactionModel = await _context.Transactions.FindAsync(id);

                if (transactionModel == null)
                {
                    return NotFound();
                }
                return View(transactionModel);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, [Bind("TransactionId,AccountNumber,BeneficiaryName,BankName,SWIFTCode,Amount,Date")] TransactionModel transactionModel)
        {
            if (ModelState.IsValid)
            {
                //Insert
                if (id == 0)
                {
                    transactionModel.Date = DateTime.Now;

                    _context.Add(transactionModel);
                    await _context.SaveChangesAsync();

                }
                //Update
                else
                {
                    try
                    {
                        _context.Update(transactionModel);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!TransactionModelExists(transactionModel.TransactionId))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                   
                }
                // since we are submitting the form using ajax POST request, return response in JSON format instead of RedirectToAction
                // return Json function new object, inside that we have the isValid property, html property, after insert or update
                // we have to pass html table as a string inside
                // the helper class (this controller, the name of the action, pass in the model which is a list of updated transactions )
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.Transactions.ToList()) }); 
            }
            // if any validation error, return the view(AddOrEdit), pass in transactionModel(contains all the error messages) in the form
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEdit", transactionModel) });
        }

        // GET: Transaction/Delete/5
        // GET Delete View
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var transactionModel = await _context.Transactions
        //        .FirstOrDefaultAsync(x => x.TransactionId == id);

        //    if (transactionModel == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(transactionModel);
        //}

        // GET: Transaction/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken] // net core security feature (delete button has the form with input fields)
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transactionModel = await _context.Transactions.FindAsync(id);

            _context.Transactions.Remove(transactionModel);

            await _context.SaveChangesAsync();

            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.Transactions.ToList()) });

        }

        private bool TransactionModelExists(int id)
        {
            return _context.Transactions.Any(x => x.TransactionId == id);
        }
    }
}
