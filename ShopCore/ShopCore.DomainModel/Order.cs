using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Epam.Wunderlist.DomainModel
{
    public class Order : Entity
    {
        public User User { get; set; }

        public Item Item { get; set; }

        public uint Quantity { get; set; }

        public bool IsCompleted { get; set; }

        public DateTime? CompletionDate { get; set; }

        public DateTime OpeningDate { get; set; }

        public decimal Price
        {
            get
            {
                return Quantity * Item.Price;
            }
        }
    }
}
