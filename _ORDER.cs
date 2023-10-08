using System;
using System.ComponentModel.DataAnnotations;

namespace SoumyaKart
{
    public class _ORDER
    {
        public int OrderId { get; set; }

        public string CartId { get; set; }

        public DateTime OrderDate{ get; set; }
        
        public int UserId { get; set; }
    }
}