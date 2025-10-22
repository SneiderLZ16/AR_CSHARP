using DigitalLibrary.Data;
using DigitalLibrary.Models;
using Microsoft.AspNetCore.Mvc;

namespace DigitalLibrary.Controllers;

public class LoanController : Controller
{
    private readonly AppDbContext _context;

    public LoanController(AppDbContext context)
    {
        _context = context; //DataBase
    }

    public IActionResult Index() //Show all
    {
        var vm = new ViewModel
        {
            Users = _context.Users.ToList(),
            Books = _context.Books.ToList(),
            Loans = _context.Loans.ToList()
        };
        return View(vm);
    }

    public IActionResult Save(Loan loan)
    {
        _context.Loans.Add(loan);
        var book = _context.Books.FirstOrDefault(b => b.Id == loan.BookId);
        if (book != null)
        {
            book.Stock -= 1;
        }
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult DetailsLoan(int id)
    {
        var loan = _context.Loans.FirstOrDefault(l => l.Id == id);
        if (loan == null) return NotFound();
        return View(loan);
    }

    public IActionResult Edit(Loan? loanEdit)
    {
        var loan = _context.Loans.FirstOrDefault(l => loanEdit != null && l.Id == loanEdit.Id);
        if (loanEdit == null) return NotFound();

        if (loan != null)
        {
            loan.ReturnDate = loanEdit.ReturnDate;
            loan.ReturnDay = loanEdit.ReturnDay;
            loan.BookId = loanEdit.BookId;
            loan.UserId = loanEdit.UserId;
        }

        _context.SaveChanges();
        return RedirectToAction("Index");
    }
    
    public IActionResult EditDay(int id)
    {
        var loan = _context.Loans.FirstOrDefault(l => l.Id == id);
        if (loan == null) return NotFound();

        loan.ReturnDay = DateTime.Today;

        var book = _context.Books.FirstOrDefault(b => b.Id == loan.BookId);
        if (book != null)
        {
            book.Stock += 1;
        }

        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Delete(int id)
    {
        var loan = _context.Loans.Find(id);
        if (loan == null) return NotFound();
        _context.Loans.Remove(loan);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
}