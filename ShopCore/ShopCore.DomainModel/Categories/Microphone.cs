using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Epam.Wunderlist.DomainModel
{
    public class Microphone : Item
    {
        public override string Category
        {
            get
            {
                return "Microphone";
            }
        }

    }
}
