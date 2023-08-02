﻿using OfferCount.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferCount.Domain.Accounts
{
    public class Account
    {
        public Account(User user)
        {
            User = user;
        }

        public int Id { get; set; }
        public User User { get; set; }


    }
}
