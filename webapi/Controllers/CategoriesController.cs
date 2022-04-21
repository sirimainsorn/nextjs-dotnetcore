using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

using Newtonsoft.Json;

using MySql.Data;
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
            cmd.Parameters.Add(new MySqlParameter("pageNo", 1));
            cmd.Parameters["pageNo"].Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add(new MySqlParameter("pageRow", 10));
            cmd.Parameters["pageRow"].Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add(new MySqlParameter("totalRecord", System.Data.SqlDbType.Int));
            cmd.Parameters["totalRecord"].Direction = ParameterDirection.Output;

            using var reader = await cmd.ExecuteReaderAsync();
        
            while (await reader.ReadAsync())
            {
                CategoryListResponse categoryResponse = new CategoryListResponse();
                categoryResponse.categoryID = Convert.ToInt32(reader["categoryID"]);
                categoryResponse.categoryNameTH = reader["categoryNameTH"].ToString();
                categoryResponse.categoryNameEN = reader["categoryNameEN"].ToString();
                categoryList.Add(categoryResponse);
            }

            if (reader.NextResult())
            {
                while (await reader.ReadAsync())
                {
                    Console.WriteLine(reader.GetString(0));
                }
            }

            reader.Close();

            return Ok(categoryList);
        }
    }
}
