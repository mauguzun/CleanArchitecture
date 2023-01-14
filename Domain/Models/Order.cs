using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Enums;

namespace Entities.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public OrderStatus Status { get; set; }

        public ICollection<OrderItem> Items { get; set; }

        //public decimal Total() => Items.Sum(x => x.Quantity * x.Product.Price);

    }
}
