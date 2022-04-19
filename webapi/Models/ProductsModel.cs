using System;

namespace WebApi.Models {
  public class ProductListResponse {
    public int ProductID {
      get;
      set;
    }
    public string ProductName {
      get;
      set;
    }
    public decimal ProductPrice {
      get;
      set;
    }
    public int CategoryID {
      get;
      set;
    }
  }
}