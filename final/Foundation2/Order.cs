using System;

public class Order
{
    private List<Product> products = new List<Product>();
    private Customer customer;
    private const decimal USA_SHIPPING_COST = 5.00m;
    private const decimal INTERNATIONAL_SHIPPING_COST = 35.00m;

    public Order(Customer customer)
    {
        this.customer = customer;
    }

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    private decimal CalculateShippingCost()
    {
        return customer.LivesInUSA() ? USA_SHIPPING_COST : INTERNATIONAL_SHIPPING_COST;
    }

    public decimal GetTotalPrice()
    {
        decimal totalCost = 0;
        foreach (Product product in products)
        {
            totalCost += product.GetTotalCost();
        }
        return totalCost + CalculateShippingCost();
    }

    public string GetPackingLabel()
    {
        string label = "Packing Label:\n";
        foreach (Product product in products)
        {
            label += $"{product.GetName()} (ID: {product.GetProductId()})\n";
        }
        return label;
    }

    public string GetShippingLabel()
    {
        return $"Shipping Label:\n{customer}";
    }

    public decimal GetShippingCost()
    {
        return CalculateShippingCost();
    }
}
