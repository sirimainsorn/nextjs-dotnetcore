using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

using MySql.Data.MySqlClient;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private MySqlConnection _connection;
        private string _connectionStrings;
        public IConfiguration Configuration { get; set; }
        public ProductController(IConfiguration configuration)
        {
            _connectionStrings = configuration["ConnectionStrings:Default"];
            _connection = new MySqlConnection(_connectionStrings);
            _connection.Open();
        }

        [HttpGet("ProductList")]
        public async Task<IActionResult> GetProduct()
        {
            List<ProductListResponse> productList = new List<ProductListResponse>();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM products", _connection);
            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                ProductListResponse productResponse = new ProductListResponse();
                productResponse.ProductID = Convert.ToInt32(reader["ProductID"]);
                productResponse.ProductName = reader["ProductName"].ToString();
                productResponse.ProductPrice = Convert.ToDecimal(reader["ProductPrice"]);
                productResponse.CategoryID = Convert.ToInt32(reader["CategoryID"]);
                productList.Add(productResponse);
            }
            reader.Close();

            return Ok(productList);
        }
    }
}


