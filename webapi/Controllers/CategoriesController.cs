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
        public async Task<IActionResult> GetCategoryList(int pageNo, int pageRow)
        {
            List<CategoryListResponse> categoryList = new List<CategoryListResponse>();
            MySqlCommand cmd = new MySqlCommand("GetCategoryList", _connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new MySqlParameter("pageNo", pageNo == 0 ? 1 : pageNo));
            cmd.Parameters["pageNo"].Direction = ParameterDirection.Input;
            cmd.Parameters.Add(new MySqlParameter("pageRow", pageRow == 0 ? 10 : pageRow));
            cmd.Parameters["pageRow"].Direction = ParameterDirection.Input;

            using var reader = await cmd.ExecuteReaderAsync();
        
            while (await reader.ReadAsync())
            {
                CategoryListResponse categoryResponse = new CategoryListResponse();
                categoryResponse.categoryID = Convert.ToInt32(reader["categoryID"]);
                categoryResponse.categoryNameTH = reader["categoryNameTH"].ToString();
                categoryResponse.categoryNameEN = reader["categoryNameEN"].ToString();
                categoryList.Add(categoryResponse);
            }
                
            int count = categoryList.Count();
            int TotalPages = (int)Math.Ceiling(count / (double)pageRow);

            var categoryMetadata = new
            {  
                pageNo = pageNo == 0 ? 1 : pageNo,
                pageRow = pageRow == 0 ? 10 : pageRow,
                totalRecord = count,
                totalPage = TotalPages,
                data = categoryList
            };
  
            reader.Close();

            return Ok(categoryMetadata);
        }

        [HttpPost("CreateCategory")]
        public async Task<ActionResult<CategoryItem>> CreateCategory(CategoryItem category)
        {
            MySqlCommand cmd = new MySqlCommand("InsertCategory", _connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new MySqlParameter("categoryNameTH", category.categoryNameTH.ToString()));
            cmd.Parameters["categoryNameTH"].Direction = ParameterDirection.Input;
            cmd.Parameters.Add(new MySqlParameter("categoryNameEN", category.categoryNameEN.ToString()));
            cmd.Parameters["categoryNameEN"].Direction = ParameterDirection.Input;
            await cmd.ExecuteReaderAsync();
        
            return Ok();
        }
    }
}
