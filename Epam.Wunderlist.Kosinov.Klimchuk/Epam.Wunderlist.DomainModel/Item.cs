using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Epam.Wunderlist.DomainModel
{
    public abstract class Item : Entity
    {
        public string Manufacturer { get; set; }

        public virtual string Category { get; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public uint? Quantity { get; set; }

        public bool IsAvailable
        {
            get
            {
                return Quantity != 0;
            }
        }

    }
}
