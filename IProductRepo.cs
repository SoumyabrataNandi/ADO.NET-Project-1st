
using System;
using System.Collections.Generic;

namespace SoumyaKart
{
    interface IProductRepo
    {
        List<PRODUCT> GetAllProduct();

        List<PRODUCT> GetProductsByCategory(string Category);

        PRODUCT GetProductById(int Id);
    }
}