using System;

namespace WebApi.Models
{
    public class CategoryItem
    {
        public string categoryNameTH { get; set; }

        public string categoryNameEN { get; set; }
    }

    public class CategoryListResponse
    {
        public int categoryID { get; set; }

        public string categoryNameTH { get; set; }

        public string categoryNameEN { get; set; }
    }
}
