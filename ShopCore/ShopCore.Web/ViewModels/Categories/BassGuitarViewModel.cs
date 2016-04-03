using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace ShopCore.WebApp.ViewModels.Categories
{
    public class BassGuitarViewModel : ItemViewModel
    {

        public string Material { get; set; }

        public int StringsAmount { get; set; }

        public int FretsAmount { get; set; }

    }
}
