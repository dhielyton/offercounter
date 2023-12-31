﻿using OfferCounter.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferCounter.Domain.Offers
{
    public interface  IOfferService
    {
        Task<Offer> Create(string portfolioId, double quantity, double unitPrice, string userId);
        Task Delete(string offerId, string userId);
    }
}
