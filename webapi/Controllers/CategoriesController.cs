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
    public class CategoriesController : ControllerBase
    {
        private MySqlConnection _connection;
        
        private string _connectionStrings;
        
        public IConfiguration Configuration { get; }

        public CategoriesController(IConfiguration configuration)
        {
            _connectionStrings = configuration["ConnectionStrings:Default"];
            _connection = new MySqlConnection(_connectionStrings);
            _connection.Open();
        }

        [HttpGet("CategoryList")]
        public async Task<IActionResult> GetCategoryList()
        {
            List<CategoryListResponse> categoryList = new List<CategoryListResponse>();
            MySqlCommand cmd = new MySqlCommand("GetCategoryList", _connection);
            cmd.CommandType = CommandType.StoredProcedure;

            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                CategoryListResponse categoryResponse = new CategoryListResponse();
                categoryResponse.CategoryID = Convert.ToInt32(reader["CategoryID"]);
                categoryResponse.CategoryNameTH = reader["CategoryNameTH"].ToString();
                categoryResponse.CategoryNameEN = reader["CategoryNameEN"].ToString();
                categoryList.Add(categoryResponse);
            }

            reader.Close();

            return Ok(categoryList);
        }
    }
}
