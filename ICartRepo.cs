using System;
using System.Collections.Generic;

namespace SoumyaKart
{
    interface ICartRepo
    {

        List<CART> GetCartItems(string UserId);

        void RemoveProductFromCart(int ProductId);

        void UpdateProductQuantity(int ProductId, int Quantity);

        void ConfirmOrder(string UserId);

        void AddToCart(int ProductId , int Quentity, string UserId);

    }
}