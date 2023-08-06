using Microsoft.EntityFrameworkCore;
using OfferCounter.Domain.Accounts;
using OfferCounter.Domain.Currencies;
using OfferCounter.Domain.Portfolios;
using OfferCounter.Domain.Users;
using OfferCounter.Infrastructure.Context;

namespace OfferCounter.API.Seed
{

    public class OfferCounterContextSeed
    {
        public static async Task SeedAsync(IHost app)
        {

            try
            {
                using (var scope = app.Services.CreateScope())
                {
                    var service = scope.ServiceProvider;
                    var context = service.GetService<OfferCounterContex>();

                    context.Database.Migrate();

                    if (!context.CryptoCurrencies.Any())
                    {
                        context.CryptoCurrencies.AddRange(GetPreconfiguredCurrencies());
                        await context.SaveChangesAsync();
                    }
                    if (!context.Users.Any())
                    {
                        context.Users.AddRange(GetPreconfiguredUsers());
                        await context.SaveChangesAsync();
                    }
                    if (!context.Accounts.Any())
                    {
                        context.Accounts.AddRange(GetPreconfiguredAccounts());
                        await context.SaveChangesAsync();
                    }

                    if (!context.Portfolios.Any())
                    {
                        context.Portfolios.AddRange(GetPreconfiguredPortfolios());
                        await context.SaveChangesAsync();
                    }
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }
        static IEnumerable<CriptoCurrency> GetPreconfiguredCurrencies()
        {

            return new List<CriptoCurrency>()
            {
                new CriptoCurrency(){ Id ="8004036e-6451-49bb-8e66-c5a3b832bf9b", Name="BITCOIN", Abbreviation="BTC"},
                new CriptoCurrency(){ Id ="f4c9080b-58aa-4fed-938c-6734557979db", Name="LITCOIN", Abbreviation="LTC"},
                new CriptoCurrency(){ Id ="7e0721da-26d0-4550-b159-53aea5591487", Name="RIPPLE", Abbreviation="XRP"},
                new CriptoCurrency(){ Id ="b9223639-2aee-4483-b021-dbfc96b7e69c", Name="ETHEREUM", Abbreviation="ETH"}
            };
        }

        static IEnumerable<User> GetPreconfiguredUsers()
        {

            return new List<User>()
            {
                new User(){ Id ="27d5c71d-0cc3-4605-b639-c80ca6079073", Name="ROOT"},
                new User(){ Id ="337a427e-cac3-495f-af90-d5b1e7ae4264", Name="MASTER"},
                new User(){ Id ="460d7600-1692-4b90-8b48-5d591b135ce8", Name="LINUX"},
                new User(){ Id ="ca76d826-3f93-4b1c-bbc1-cdae2e31408c", Name="TEST"}
            };
        }

        static IEnumerable<Account> GetPreconfiguredAccounts()
        {

            return new List<Account>()
            {
                new Account(){ Id="1302876e-da49-4e61-a661-fea57b2ce20f", UserId ="27d5c71d-0cc3-4605-b639-c80ca6079073"},
                new Account(){ Id="15321f69-be94-42f7-afa8-bee29e88046b", UserId ="337a427e-cac3-495f-af90-d5b1e7ae4264"},
                new Account(){ Id="42ae87ef-657c-4f61-80c4-d670e8150014", UserId ="460d7600-1692-4b90-8b48-5d591b135ce8"},
                new Account(){ Id="8147da9b-972b-4154-b838-f8d011bf87a3", UserId ="ca76d826-3f93-4b1c-bbc1-cdae2e31408c"}
            };
        }

        static IEnumerable<Portfolio> GetPreconfiguredPortfolios()
        {
            return new List<Portfolio>() {
                new Portfolio { Id ="5104b8c5-260f-401b-8db9-04f6bc59e4ee", CurrencyId="8004036e-6451-49bb-8e66-c5a3b832bf9b", AccountId ="1302876e-da49-4e61-a661-fea57b2ce20f", Address = "", Quantity = 10000},
                new Portfolio { Id ="71318ce3-f948-4a59-84e7-be4a59319dcd", CurrencyId="f4c9080b-58aa-4fed-938c-6734557979db", AccountId ="1302876e-da49-4e61-a661-fea57b2ce20f", Address = "", Quantity = 10000},
                new Portfolio { Id ="fbd83c00-174a-4468-81d9-cc34521e7d64", CurrencyId="7e0721da-26d0-4550-b159-53aea5591487", AccountId ="1302876e-da49-4e61-a661-fea57b2ce20f", Address = "", Quantity = 10000},
                new Portfolio { Id ="c866a5e2-e660-41e2-b810-1e10cbc2cebe", CurrencyId="b9223639-2aee-4483-b021-dbfc96b7e69c", AccountId ="1302876e-da49-4e61-a661-fea57b2ce20f", Address = "", Quantity = 0},

                new Portfolio { Id ="3c5b8dda-b5d6-4456-904a-ca05ca2d5303", CurrencyId="8004036e-6451-49bb-8e66-c5a3b832bf9b", AccountId ="15321f69-be94-42f7-afa8-bee29e88046b", Address = "", Quantity = 0},
                new Portfolio { Id ="e867db6f-e2b1-4f3b-bbb1-defbb26007d2", CurrencyId="f4c9080b-58aa-4fed-938c-6734557979db", AccountId ="15321f69-be94-42f7-afa8-bee29e88046b", Address = "", Quantity = 10000},
                new Portfolio { Id ="c4b19902-2ad3-4624-bfa5-ae6f8c9bf124", CurrencyId="7e0721da-26d0-4550-b159-53aea5591487", AccountId ="15321f69-be94-42f7-afa8-bee29e88046b", Address = "", Quantity = 10000},
                new Portfolio { Id ="e9c5c5ce-404d-4319-9e22-e377dc861191", CurrencyId="b9223639-2aee-4483-b021-dbfc96b7e69c", AccountId ="15321f69-be94-42f7-afa8-bee29e88046b", Address = "", Quantity = 10000},

                new Portfolio { Id ="6a200201-aa90-4ff4-ab67-87389c2bafe9", CurrencyId="8004036e-6451-49bb-8e66-c5a3b832bf9b", AccountId ="42ae87ef-657c-4f61-80c4-d670e8150014", Address = "", Quantity = 10000},
                new Portfolio { Id ="5f5a0cf4-8279-4d94-bf4a-ed0e690c6d5c", CurrencyId="f4c9080b-58aa-4fed-938c-6734557979db", AccountId ="42ae87ef-657c-4f61-80c4-d670e8150014", Address = "", Quantity = 0},
                new Portfolio { Id ="2ce7dc2d-cf42-4e88-8c18-56ed9a9b44a4", CurrencyId="7e0721da-26d0-4550-b159-53aea5591487", AccountId ="42ae87ef-657c-4f61-80c4-d670e8150014", Address = "", Quantity = 10000},
                new Portfolio { Id ="5d407aa8-a6c3-471b-b0b4-2fc5ca91dd79", CurrencyId="b9223639-2aee-4483-b021-dbfc96b7e69c", AccountId ="42ae87ef-657c-4f61-80c4-d670e8150014", Address = "", Quantity = 10000},

                new Portfolio { Id ="c2907d7c-cdcf-4222-82ed-352ab6537afc", CurrencyId="8004036e-6451-49bb-8e66-c5a3b832bf9b", AccountId ="8147da9b-972b-4154-b838-f8d011bf87a3", Address = "", Quantity = 10000},
                new Portfolio { Id ="dd6bdad0-32c7-45a3-8fd0-2a01491ad2cd", CurrencyId="f4c9080b-58aa-4fed-938c-6734557979db", AccountId ="8147da9b-972b-4154-b838-f8d011bf87a3", Address = "", Quantity = 10000},
                new Portfolio { Id ="e1b75132-9154-4f44-b890-5297f10824cc", CurrencyId="7e0721da-26d0-4550-b159-53aea5591487", AccountId ="8147da9b-972b-4154-b838-f8d011bf87a3", Address = "", Quantity = 0},
                new Portfolio { Id ="ebc1badf-0041-47c3-a4c1-5584e4206ee6", CurrencyId="b9223639-2aee-4483-b021-dbfc96b7e69c", AccountId ="8147da9b-972b-4154-b838-f8d011bf87a3", Address = "", Quantity = 10000},
            };
        }
    }
}
