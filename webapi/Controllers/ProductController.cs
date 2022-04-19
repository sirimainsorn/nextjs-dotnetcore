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
            // var cmd = this.MySqlDatabase.Connection.CreateCommand() as MySqlCommand;
            // cmd.CommandText = @"SELECT * FROM dbo.Products";

            // var reader = await cmd.ExecuteReaderAsync();
            Console.WriteLine("Hello");
            // var response = new ProductsModel();
            // response = await reader.ReadAsync();

            return Ok();
        }
    }
}


