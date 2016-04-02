using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Epam.Wunderlist.DomainModel
{
    public class Amplifier : Item
    {
        public override string Category
        {
            get
            {
                return "Amplifier";
            }
        }

        public int Power { get; set; }

        public int CabinetSize { get; set; }

        

    }
}
