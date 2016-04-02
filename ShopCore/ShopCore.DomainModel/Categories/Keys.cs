using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Epam.Wunderlist.DomainModel
{
    public class Keys : Item
    {
        public override string Category
        {
            get
            {
                return "Keys";
            }
        }

        public bool IsMechanical { get; set; }

        public int KeysAmount { get; set; }


    }
}
