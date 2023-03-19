using Microsoft.AspNetCore.Mvc; 
using Microsoft.AspNetCore.Mvc.RazorPages;
using SQL_DATA.Models;
using SQL_DATA.Services;

namespace SQL_DATA.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public List<Product> Products;
        public void OnGet()
        {
            ProductService productService = new ProductService();
            Products=productService.GetProducts();
        }
    }
}