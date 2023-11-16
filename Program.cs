// See https://aka.ms/new-console-template for more information
using System.Diagnostics.CodeAnalysis;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;

List<Product> products = new List<Product>()
{
    new Product()
    {
        Name = "Football",
        Price = 15.00M,
        Sold = false,
        StockDate = new DateTime(2023, 10, 1),
        ManufactureYear = 2010,
        Condition = 4.5
    },
    new Product()
    {
        Name = "Hockey Stick",
        Price = 25.00M,
        Sold = false,
        StockDate = new DateTime(2023, 5, 10),
        ManufactureYear = 2010,
        Condition = 3.3
    },
    new Product()
    {
        Name = "Boomerang",
        Price = 30.50M,
        Sold = false,
        StockDate = new DateTime(2022, 9, 2),
        ManufactureYear = 2013,
        Condition = 2.7
    },
    new Product()
    {
        Name = "Frisbee",
        Price = 10.79M,
        Sold = false,
        StockDate = new DateTime(2023, 10, 20),
        ManufactureYear = 2015,
        Condition = 3.9
    },
    new Product()
    {
        Name = "Golf Putter",
        Price = 199.99M,
        Sold = false,
        StockDate = new DateTime(2033, 10, 20),
        ManufactureYear = 2000,
        Condition = 2.4
     }
};
string greeting = @"Welcome to Thrown For A Loop
Your one-stop shop for sporting equipment!";
Console.WriteLine(greeting);
string choice = null;
while (choice != "0")
{
    Console.WriteLine(@"Choose an option:
                        0. Exit
                        1. View All Products
                        2. View Product Details
                        3. View Latest Products
                        ");
    choice = Console.ReadLine();
    if (choice == "0")
    {
        Console.WriteLine("Goodbye!");
    }
    else if (choice == "1")
    {
        ListProducts();

    }
    else if (choice == "2")
    {
        ViewProductDetails();
    }
    else if (choice == "3")
    {
        ViewLatestProducts();
    }
}


void ViewProductDetails()
{
    //initializes tally as decimal zero
    ListProducts();

    Product chosenProduct = null;

    while (chosenProduct == null)
    {
        Console.WriteLine("Please enter a product number: ");
        try
        {
            int response = int.Parse(Console.ReadLine().Trim());
            chosenProduct = products[response - 1];
        }
        catch (FormatException)
        {
            Console.WriteLine("Please only type integers!");
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Please choose an extant item, you fool!");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            Console.WriteLine("Do better!");
        }
    }

    DateTime now = DateTime.Now;
    TimeSpan timeInStock = now - chosenProduct.StockDate;
    Console.WriteLine(@$"You chose:
{chosenProduct.Name} which costs ${chosenProduct.Price}
It is {now.Year - chosenProduct.ManufactureYear} years old.
It is {(chosenProduct.Sold ? "is not available" : $"has been in stock for {timeInStock.Days} days.")}
Its condition is at a {chosenProduct.Condition}");
}

void ListProducts()
{
    decimal totalValue = 0.0M;
    foreach (Product product in products)
    {
        if (!product.Sold)
        {
            totalValue += product.Price;
        }
    }
    Console.WriteLine($"Total inventory value: ${totalValue}");
    Console.WriteLine("Products:");
    for (int i = 0; i < products.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {products[i].Name}");
    }
}

void ViewLatestProducts()
{
    //create new list
    List<Product> latestProducts = new List<Product>();
    //calc a datetime 90 days in the past
    DateTime threeMonthsAgo = DateTime.Now - TimeSpan.FromDays(90);
    //loop the the products
    foreach (Product product in products)
    {
        //add if it fits the criteria
        if (product.StockDate > threeMonthsAgo && !product.Sold)
        {
            latestProducts.Add(product);
        }
    }
    //print latest items to console
    for (int i = 0; i < latestProducts.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {latestProducts[i].Name}");
    }
}

