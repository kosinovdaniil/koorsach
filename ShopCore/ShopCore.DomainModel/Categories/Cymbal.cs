using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Epam.Wunderlist.DomainModel
{
    public class Cymbal : Item
    {
        public override string Category
        {
            get
            {
                return "Cymbal";
            }
        }

        public string Material { get; set; }


        public int Radius { get; set; }

    }
}
