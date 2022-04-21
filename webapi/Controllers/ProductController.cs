using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

using MySql.Data.MySqlClient;

using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ProductController : ControllerBase
    {
        private MySqlConnection _connection;
        
        private string _connectionStrings;
        
        public IConfiguration Configuration { get; }

        public ProductController(IConfiguration configuration)
        {
            _connectionStrings = configuration["ConnectionStrings:Default"];
            _connection = new MySqlConnection(_connectionStrings);
            _connection.Open();
        }

        [HttpGet("ProductList")]
        public async Task<IActionResult> GetProductList()
        {
            List<ProductListResponse> productList = new List<ProductListResponse>();
            MySqlCommand cmd = new MySqlCommand("GetProductList", _connection);
            cmd.CommandType = CommandType.StoredProcedure;

            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                ProductListResponse productResponse = new ProductListResponse();
                productResponse.productID = Convert.ToInt32(reader["productID"]);
                productResponse.productNameTH = reader["productNameTH"].ToString();
                productResponse.productNameEN = reader["productNameEN"].ToString();
                productResponse.productPrice = Convert.ToDecimal(reader["productPrice"]);
                productResponse.categoryID = Convert.ToInt32(reader["categoryID"]);
                productList.Add(productResponse);
            }

            reader.Close();

            return Ok(productList);
        }
    }
}
