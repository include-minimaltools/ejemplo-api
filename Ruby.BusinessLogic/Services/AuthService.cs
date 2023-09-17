using System.Runtime.ConstrainedExecution;
using Ruby.BusinessLogic.Models;
using Ruby.DataAccess.Models;

namespace Ruby.BusinessLogic.Services;

public class AuthService
{
    private readonly RubyContext _dbContext;
    public AuthService(RubyContext dbContext)
    {
        _dbContext = dbContext;
    }

    public bool Login(string email)
    {
        return _dbContext.AuthUsers.Any(x => x.Email == email);
    }

    public IEnumerable<ProductWithPriceDto> GetProductsWithPrice()
    {
        var result = (from p in _dbContext.ApiCoreProducts
                     join ppc in _dbContext.ApiCoreProductPriceCosts on p.IdProduct equals ppc.IdProduct
                     join c in _dbContext.ApiCoreCurrencyTypes on ppc.IdCurrency equals c.IdCurrency
                     join ce in _dbContext.ApiCoreCurrencyExchanges on c.IdCurrency equals ce.IdCurrency
                     select new ProductWithPriceDto
                     {
                        Name = p.Name,
                        Description = p.Description,
                        Currency = c.Currency,
                        Price = ppc.Price,
                        PriceDolar = ppc.Price * ce.ExchangeRateDolar,
                        PriceLocal = ppc.Price * ce.ExchangeRateLocal
                     }).ToList();

        return result;
    }
}
