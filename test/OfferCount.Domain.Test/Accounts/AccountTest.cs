using FluentAssertions;
using OfferCounter.Domain.Accounts;
using OfferCounter.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OfferCounter.Domain.Test.Accounts
{
    public class AccountTest
    {

        [Fact]
        public void CreateAccountWithSucess()
        {
            var user = new User("User");
            var account = new Account(user);
            account.Should().NotBeNull();
            account.User.Should().NotBeNull();
        }
    }
}
