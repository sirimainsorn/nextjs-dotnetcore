using System;

namespace WebApi.Models
{
    public class ProductListResponse
    {
        public int productID { get; set; }

        public string productNameTH { get; set; }

        public string productNameEN { get; set; }

        public decimal productPrice { get; set; }

        public int categoryID { get; set; }

    }
}
