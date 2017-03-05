using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportsStore.Models;



namespace SportsStore.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;
        public int PageSize = 4;

        public ProductController(IProductRepository repo)
        {
            repository = repo;
        }

        // GET: /<controller>/
        public ViewResult List(int page = 1) => View(repository.Products
            .OrderBy(p => p.ProductID)
            .Skip((page -1) * PageSize)
            .Take(PageSize));
    }
}
