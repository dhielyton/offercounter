﻿using OfferCounter.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferCounter.Domain.Accounts
{
    public class Account
    {
        public Account(User user)
        {
            User = user;
        }

        public string Id { get; set; }
        public User User { get; set; }
        public string UserId { get; set; }


    }
}