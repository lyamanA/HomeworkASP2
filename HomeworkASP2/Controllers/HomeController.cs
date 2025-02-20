using System.Diagnostics;
using HomeworkASP2.Models;
using Microsoft.AspNetCore.Mvc;

namespace HomeworkASP2.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        private readonly BookDbContext _context;

        public HomeController(BookDbContext context)
        {
            _context = context;
        }


        //public HomeController(BookDbContext context) => _context = context;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public IActionResult Index()
        {
            var books = _context.Books.ToList();
           
            return View(books);
        }

        [HttpGet]
        public IActionResult AddBook() 
        { 
          return View();
        }

        [HttpPost]
        public IActionResult AddBook(Book book)
        {
            try
            {
                _context.Books.Add(book);
                _context.SaveChanges();
                TempData["Added"] = "Book added successfully!";
                
            }
            catch (Exception)
            {
                TempData["Fail"] = "Book wasn't added!";
            }
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var books = _context?.Books.ToList();
            var book = books?.FirstOrDefault(b => b.Id == id);

            return View(book);
        }

        [HttpPost]
        public IActionResult DeleteBook(int id)
        {
            var books = _context.Books.ToList();
            var bookToDelete = books.FirstOrDefault(b => b.Id == id);
            if (bookToDelete != null)
            {
                _context.Books.Remove(bookToDelete);
                _context.SaveChanges();
                TempData["Deleted"] = "Book has been deleted!";
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult EditBook(int id)
        {
            var books = _context?.Books.ToList();
            var bookToEdit = books?.FirstOrDefault(b => b.Id == id);

            return View(bookToEdit);
        }


        //небезопасно,если id передаётся через форму и он доступен в DevTools
        //[HttpPost]
        //public IActionResult EditBook(Book book)
        //{
        //    _context.Books.Update(book);
        //    _context.SaveChanges();
        //    TempData["Updated"] = "Book updated successfully!";
        //    return RedirectToAction(nameof(Index));

        //}

        [HttpPost]
        public IActionResult EditBook(int id, Book book)
        {

            if (id != book.Id) return BadRequest(); // метод, который возвращает HTTP 400 (Bad Request), указывая, что запрос содержит ошибку.

            //для проверки параметров
            if (!ModelState.IsValid) return View(book);

            _context.Books.Update(book);
            _context.SaveChanges();

            TempData["Updated"] = "Book updated successfully!";
            return RedirectToAction(nameof(Index));
        }


        //[HttpGet]
        //public IActionResult EditBook(int id)
        //{
        //    var book = _context.Books.Find(id);
        //    if (book == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(book);
        //}

        //[HttpPost]
        //public IActionResult EditBook(Book book)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Books.Update(book);
        //        _context.SaveChanges();
        //        TempData["Updated"] = "Book updated successfully!";
        //        return RedirectToAction("Index");
        //    }
        //    return View(book);
        //}


        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            var obj = new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier };
            return View(obj);
        }
    }
}
