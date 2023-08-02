using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferCounter.Domain.Users
{
    public class User
    {
        public User(string name)
        {
            Name = name;
        }

        public string Id { get; set; }
        public string Name { get; set; }
    }
}
