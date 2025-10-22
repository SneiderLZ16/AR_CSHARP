using DigitalLibrary.Data;
using DigitalLibrary.Models;
using Microsoft.AspNetCore.Mvc;

namespace DigitalLibrary.Controllers;

public class BookController: Controller
{
    private readonly AppDbContext _context;

    public BookController(AppDbContext context)
    {
        _context = context; //DataBase
    }
    
    public IActionResult Save(Book book) //Save one Book
    {
        _context.Books.Add(book);
        _context.SaveChanges();
        return RedirectToAction("Index", "User");
    }

    public IActionResult DetailsBook(int id) //Show details of a Book
    {
        var book = _context.Books.FirstOrDefault(b => b.Id == id);
        if (book == null) return NotFound();
        return View(book);
    }

    public IActionResult Edit(Book? bookEdit) //Edit of a Book
    {
        var book = _context.Books.FirstOrDefault(b => bookEdit != null && b.Id == bookEdit.Id);
        if (bookEdit == null) return NotFound();

        if (book != null)
        {
            book.Title = bookEdit.Title;
            book.Author = bookEdit.Author;
            book.Code =  bookEdit.Code;
            book.Stock =  bookEdit.Stock;
        }
        _context.SaveChanges();
        return RedirectToAction("Index", "User");
    }

    public IActionResult Delete(int id) //Delete of a Book
    {
        var book = _context.Books.Find(id);
        if (book == null) return NotFound();
        _context.Books.Remove(book);
        _context.SaveChanges();
        return RedirectToAction("Index", "User");
    }
}