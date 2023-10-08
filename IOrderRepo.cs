using System;
using System.Collections.Generic;

namespace SoumyaKart
{
    interface IOrderRepo
    {
        List<_ORDER> ViewOrdersByUserId (string UserId);
    }
}