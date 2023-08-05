using MediatR;
using Moq;
using Newtonsoft.Json;
using OfferCounter.Domain.Offers;
using OfferCounter.Domain.Portfolios;
using OfferCounter.Domain.Users;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OfferCount.Domain.Test.Offers
{
    public class OfferServiceTestBase
    {
        protected Mock<IPortfolioRepository> _portfolioRepository = new Mock<IPortfolioRepository>();
        protected Mock<IUserRepository> _userRepository = new Mock<IUserRepository>();
        protected Mock<IOfferRepository> _offerRepository = new Mock<IOfferRepository>();
        protected Mock<IMediator> mediator = new Mock<IMediator>();

        protected virtual void configurationUserRepository(Mock<IUserRepository> mock, string userId)
        {
            mock.Setup(x => x.Get(It.IsAny<string>())).Returns(() =>
            {
                using (StreamReader r = new StreamReader(@"Offers\Data\Users.json"))
                {

                    var json = r.ReadToEnd();
                    var results = JsonConvert.DeserializeObject<List<User>>(json);
                    var result = results.Where(x => x.Id == userId).FirstOrDefault();
                    return Task.FromResult(result);
                }
            });
        }
        protected virtual void configureGetPortfolioRepository(Mock<IPortfolioRepository> mock, string portfolioId)
        {
            mock.Setup(x => x.Get(It.IsAny<string>())).Returns(() =>
            {
                using (StreamReader r = new StreamReader(@"Offers\Data\Portfolio.json"))
                {

                    var json = r.ReadToEnd();
                    var results = JsonConvert.DeserializeObject<List<Portfolio>>(json);
                    var result = results.Where(x => x.Id == portfolioId).FirstOrDefault();
                    return Task.FromResult(result);
                }
            });
        }

        protected virtual void configureGetOffer(Mock<IOfferRepository> mock, string offerId)
        {
            mock.Setup(x => x.Get(It.IsAny<string>())).Returns(() =>
            {
                using (StreamReader r = new StreamReader(@"Offers\Data\Offers.json"))
                {

                    var json = r.ReadToEnd();
                    var results = JsonConvert.DeserializeObject<List<Offer>>(json);
                    var result = results.Where(x => x.Id == offerId).FirstOrDefault();
                    return Task.FromResult(result);
                }
            });
        }
    }
}
