using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Demo.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using Demo.Models.Process;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Demo.Controllers
{
    public class MoviesController : Controller
    {
        
        private readonly MVCDBContext _context;
        
        ExcelProcess _excelPro = new ExcelProcess();
         public IConfiguration Configuration {get;}

        public MoviesController(MVCDBContext context)
        {
            _context = context;
        }
         private int WriteDatableToDatabse(DataTable dt)

    {

        try{

            var con = Configuration.GetConnectionString("DefaltConnection");

            SqlBulkCopy bulkcopy = new SqlBulkCopy(con);

            bulkcopy.DestinationTableName = "Movie";

            bulkcopy.ColumnMappings.Add(0, "Id");

            bulkcopy.ColumnMappings.Add(1, "Title");

            bulkcopy.ColumnMappings.Add(2, "ReleaseDate");

            bulkcopy.ColumnMappings.Add(3, "Genre");

            bulkcopy.ColumnMappings.Add(4, "Price");

            bulkcopy.ColumnMappings.Add(5, "Rating");

           

            bulkcopy.WriteToServer(dt);

        }

        catch{

            return 0;

        }

        return dt.Rows.Count;

    }
        

        // GET: Movies
        // GET: Movies
public async Task<IActionResult> Index(string movieGenre, string searchString)
{
    // Use LINQ to get list of genres.
    IQueryable<string> genreQuery = from m in _context.Movie
                                    orderby m.Genre
                                    select m.Genre;

    var movies = from m in _context.Movie
                 select m;

    if (!string.IsNullOrEmpty(searchString))
    {
        movies = movies.Where(s => s.Title.Contains(searchString));
    }

    if (!string.IsNullOrEmpty(movieGenre))
    {
        movies = movies.Where(x => x.Genre == movieGenre);
    }

    var movieGenreVM = new MovieGenreViewModel
    {
        Genres = new SelectList(await genreQuery.Distinct().ToListAsync()),
        Movies = await movies.ToListAsync()
    };

    return View(movieGenreVM);
}

        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormFile file)
{
    if (file!=null)
    {
        string fileExtension = Path.GetExtension(file.FileName);
        if (fileExtension != ".xls" && fileExtension != ".xlsx")
        {
            ModelState.AddModelError("", "Please choose excel file to upload!");
        }
        else
        {
            //rename file when upload to server
            //tao duong dan /Uploads/Excels de luu file upload len server
            var fileName = "Ten file muon luu";
            var filePath = Path.Combine(Directory.GetCurrentDirectory() + "/Uploads/Excels", fileName + fileExtension);
            var fileLocation = new FileInfo(filePath).ToString();

            if (ModelState.IsValid)
            {
                //upload file to server
                if (file.Length > 0)
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        //save file to server
                        await file.CopyToAsync(stream);
                        //read data from file and write to database
                        //_excelPro la doi tuong xu ly file excel ExcelProcess
                        var dt = _excelPro.ExcelToDataTable(fileLocation);
                        //ghi du lieu datatable vao database
                        
                    }
                    return RedirectToAction(nameof(Index));
                }
            }
        }
    }
    return View();
}

        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ReleaseDate,Genre,Price")] Movie movie)
        {
            if (id != movie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.Id))
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
            return View(movie);
        }

        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await _context.Movie.FindAsync(id);
            _context.Movie.Remove(movie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(int id)
        {
            return _context.Movie.Any(e => e.Id == id);
        }
    }
}
