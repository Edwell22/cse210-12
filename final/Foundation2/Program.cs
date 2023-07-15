using System;

class Product
{
    private readonly string name;
    private readonly string id;
    private readonly decimal price;
    private readonly int quantity;

    public string Name => name;
    public string Id => id;
    public decimal Price => price;
    public int Quantity => quantity;

    public Product(string name, string id, decimal price, int quantity)
    {
        this.name = name;
        this.id = id;
        this.price = price;
        this.quantity = quantity;
    }

    public decimal GetTotalPrice()
    {
        return price * quantity;
    }
}

class Address
{
    private readonly string street;
    private readonly string city;
    private readonly string state;
    private readonly string country;

    public string Street => street;
    public string City => city;
    public string State => state;
    public string Country => country;

    public Address(string street, string city, string state, string country)
    {
        this.street = street;
        this.city = city;
        this.state = state;
        this.country = country;
    }

    public bool IsInUSA()
    {
        return country.ToUpper() == "USA";
    }

    public override string ToString()
    {
        return $"{street}\n{city}, {state} {country}";
    }
}

class Customer
{
    private readonly string name;
    private readonly Address address;

    public string Name => name;
    public Address Address => address;

    public Customer(string name, Address address)
    {
        this.name = name;
        this.address = address;
    }

    public bool LivesInUSA()
    {
        return address.IsInUSA();
    }
}

class Order
{
    private readonly List<Product> products;
    private readonly Customer customer;

    public List<Product> Products => products;
    public Customer Customer => customer;

    public Order(List<Product> products, Customer customer)
    {
        this.products = products;
        this.customer = customer;
    }

    public decimal GetTotalPrice()
    {
        decimal totalPrice = 0;

        foreach (var product in products)
        {
            totalPrice += product.GetTotalPrice();
        }

        if (customer.LivesInUSA())
        {
            totalPrice += 5;
        }
        else
        {
            totalPrice += 35;
        }

        return totalPrice;
    }

    public string GetPackingLabel()
    {
        string packingLabel = "";

        foreach (var product in products)
        {
            packingLabel += $"{product.Name} ({product.Id})\n";
        }

        return packingLabel;
    }

    public string GetShippingLabel()
    {
        string shippingLabel = "";

        shippingLabel += $"{customer.Name}\n";
        shippingLabel += $"{customer.Address}\n";

        return shippingLabel;
    }
}

class Program
{
    static void Main(string[] args)
    {
        var address1 = new Address("123 Main St", "Anytown", "CA", "USA");
        var customer1 = new Customer("John Smith", address1);

        var address2 = new Address("456 High St", "Anycity", "ON", "Canada");
        var customer2 = new Customer("Jane Doe", address2);

        var products1 = new List<Product>
        {
            new Product("Product A", "A1", 10.50m, 2),
            new Product("Product B", "B1", 5.25m, 3)
        };
        var order1 = new Order(products1, customer1);

        var products2 = new List<Product>
        {
            new Product("Product C", "C1", 15.75m, 1),
            new Product("Product D", "D1", 7.50m, 2),
            new Product("Product E", "E1", 2.25m, 5)
        };
        var order2 = new Order(products2, customer2);

        Console.WriteLine("Order 1");
        Console.WriteLine("Packing Label:");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.GetTotalPrice()}");

        Console.WriteLine();

        Console.WriteLine("Order 2");
        Console.WriteLine("Packing Label:");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.GetTotalPrice()}");

        Console.ReadLine();
    }
}