﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferCounter.Domain.SharedKernel
{
    public class Entity : IEntity
    {
        public string Id { get; set; }

        public void GenerateId()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
