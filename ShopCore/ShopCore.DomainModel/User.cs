using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace ShopCore.DomainModel
{
    public class User : Entity
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public bool IsAdmin { get; set; }

        public virtual IList<Order> Orders { get; set; }
    }
}
