using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Epam.Wunderlist.DomainModel
{
    public class Strings : Item
    {
        public override string Category
        {
            get
            {
                return "Strings";
            }
        }

        public string Material { get; set; }

        public int StringsAmount { get; set; }

    }
}
