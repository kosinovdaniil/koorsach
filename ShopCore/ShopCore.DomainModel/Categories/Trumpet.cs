using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Epam.Wunderlist.DomainModel
{
    public class Trumpet : Item
    {
        public override string Category
        {
            get
            {
                return "Trumpet";
            }
        }

        public string Material { get; set; }

    }
}
