using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ilovecoffee.Models;

namespace ilovecoffee.Controllers
{
    public class HomeController : Controller
    {
        public ProductMockList prodList {get;set;}
        public HomeController(ProductMockList ml)
        {
            prodList = ml;
        }

        public IActionResult Index()
        {

            ViewBag.Title = "Teste";
            return View(prodList.AllProducts());
        }
        [HttpPost]
        public IActionResult Create(Product product){
            prodList.Add(product);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(long id){
            prodList.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(long id){
            Product product = prodList.FindOne(id);
            if(product != null){
                return View(product);
            }
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Update(Product product){
            System.Console.WriteLine($"inside Update method product name = {product.Name}");
            prodList.Update(product);
            return RedirectToAction(nameof(Index));
        }
    }
}