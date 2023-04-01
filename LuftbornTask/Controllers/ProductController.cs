using LuftbornTask.Migrations;
using LuftbornTask.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace LuftbornTask.Controllers
{
    public class ProductController : Controller
    {
        private ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        public  IActionResult Index()
        {
            var products =  _context.Products.ToList();
            return View(products);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            // validate that our model meets the requirement
            if (ModelState.IsValid)
            {
                try
                {
                    // update the ef core context in memory 
                    _context.Products.Add(product);

                    // sync the changes of ef code in memory with the database
                     _context.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, $"Something went wrong {ex.Message}");
                }
            }

            ModelState.AddModelError(string.Empty, $"Something went wrong, invalid model");

            // We return the object back to view
            return View(product);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var exist =  _context.Products.Where(x => x.Id == id).FirstOrDefault();

            return View(exist);
        }
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            // validate that our model meets the requirement
            if (ModelState.IsValid)
            {
                try
                {
                    // Check if the contact exist based on the id
                    var exist = _context.Products.Where(x => x.Id == product.Id).FirstOrDefault();

                    // if the contact is not null we update the information
                    if (exist != null)
                    {
                        exist.ProductCode = product.ProductCode;
                        exist.ProductName = product.ProductName;
                        exist.Quantity = product.Quantity;

                        // we save the changes into the db
                         _context.SaveChanges();

                        return RedirectToAction("Index");
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, $"Something went wrong {ex.Message}");
                }
            }

            ModelState.AddModelError(string.Empty, $"Something went wrong, invalid model");

            return View(product);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var exist =  _context.Products.Where(x => x.Id == id).FirstOrDefault();

            return View(exist);
        }
        [HttpPost]
        public IActionResult Delete(Product product)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var exist = _context.Products.Where(x => x.Id == product.Id).FirstOrDefault();

                    if (exist != null)
                    {
                        _context.Products.Remove(exist);
                         _context.SaveChanges();

                        return RedirectToAction("Index");
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, $"Something went wrong {ex.Message}");
                }
            }

            ModelState.AddModelError(string.Empty, $"Something went wrong, invalid model");

            return View();
        }
    }
}
