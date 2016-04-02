using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Epam.Wunderlist.WebApp.ViewModels.Categories
{
    public class KeysViewModel : ItemViewModel
    {

        public bool IsMechanical { get; set; }

        public int KeysAmount { get; set; }


    }
}
