using System;

public class Program
{
    public static void Main(string[] args)
    {
        
        Address address1 = new Address("333 Goat Ave", "Chicago", "IL", "USA");
        Address address2 = new Address("456 Burger Blvd", "Ljubljana", "Slovenia", "Slovenia");
        Address address3 = new Address("5656 Mamba Lane", "Los Angeles", "CA", "USA");
        Address address4 = new Address("222 Raptor Road", "Toronto", "ON", "Canada");

        
        Customer customer1 = new Customer("Michael Jordan", address1);
        Customer customer2 = new Customer("Luka Doncic", address2);
        Customer customer3 = new Customer("Kobe Bryant", address3);
        Customer customer4 = new Customer("Vince Carter", address4);

        
        Product product1 = new Product("Gaming PC", 101, 2999.99m, 1);
        Product product2 = new Product("Monitor", 102, 250.50m, 2);
        Product product3 = new Product("Controller", 103, 125.00m, 1);
        Product product4 = new Product("Headset", 104, 150.00m, 1);

        
        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);
        order1.AddProduct(product4);

        Order order2 = new Order(customer2);
        order2.AddProduct(product3);
        order2.AddProduct(product4);

        Order order3 = new Order(customer3);
        order1.AddProduct(product2);
        order1.AddProduct(product3);
        order1.AddProduct(product4);

        Order order4 = new Order(customer4);
        order4.AddProduct(product1);
        order4.AddProduct(product2);
        order4.AddProduct(product3);
        order4.AddProduct(product4);

        
        List<Order> orders = new List<Order> { order1, order2, order3, order4 };
        foreach (Order order in orders)
        {
            Console.WriteLine(order.GetPackingLabel());
            Console.WriteLine(order.GetShippingLabel());
            Console.WriteLine($"Shipping Cost: ${order.GetShippingCost()}");
            Console.WriteLine($"Total Price (including shipping): ${order.GetTotalPrice()}\n");
        }
    }
}