using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Epam.Wunderlist.DomainModel
{
    public class Guitar : Item
    {

        public override string Category
        {
            get
            {
                return "Guitar";
            }
        }

        public string Material { get; set; }

        public int StringsAmount { get; set; }

        public int FretsAmount { get; set; }

    }
}
