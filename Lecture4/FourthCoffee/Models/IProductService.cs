using System.Collections.Generic;

namespace FourthCoffee.Models {
    public interface IProductService {
        public IList<Product> Products { get; }
    }
}