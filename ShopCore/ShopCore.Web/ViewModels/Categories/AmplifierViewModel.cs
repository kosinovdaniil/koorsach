using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace ShopCore.Web.ViewModels.Categories
{
    public class AmplifierViewModel : ItemViewModel
    {

        public int Power { get; set; }

        public int CabinetSize { get; set; }

        

    }
}
