using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace ShopCore.Web.ViewModels
{
    public abstract class ItemViewModel
    {
        public string Manufacturer { get; set; }

        public virtual string Category { get; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public uint? Quantity { get; set; }

    }
}
