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
        // public MySqlConnection _connection;
        // private string _connectionStrings;
        // public ProductController(IOptions<MySqlConnection> connectionStrings)
        // {
        //     _connectionStrings = connectionStrings.Value.PrimaryDatabase;
        //     _connection = new MySqlConnection(connectionString);
        // }
        // private MySqlDatabase _connection;
        private MySqlConnection _connection;
        private string _connectionStrings;
        public ProductController()
        {
            _connectionStrings = "server=localhost;user=root;password=123456;database=mybiz;port=3306;";
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


