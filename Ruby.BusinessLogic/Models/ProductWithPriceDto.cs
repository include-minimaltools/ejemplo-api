namespace Ruby.BusinessLogic.Models;

public class ProductWithPriceDto
{
    public string Name {get;set;}
	public string Description {get;set;}
	public decimal Price {get;set;}
	public string Currency {get;set;}
	public decimal PriceLocal {get;set;}
	public decimal PriceDolar {get;set;}
}