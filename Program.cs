using System;
using System.Collections.Generic;

// Simple CartItem representing a product in the cart
public class CartItem
{
    public string Name { get; set; }
    public double Price { get; set; }

    public CartItem(string name, double price)
    {
        Name = name;
        Price = price;
    }

    public override string ToString()
    {
        return $"{Name}: {Price:C}";
    }
}

// Cart class that represents a shopping cart
public class Cart
{
    private string _CartId;
    private Dictionary<string, double> _Items;
    private CartItem[] _items;

    public string CartId => _CartId;
    public IReadOnlyDictionary<string, double> Items => _Items;
    public CartItem[] ItemsArray => _items;

    // Default constructor
    public Cart() : this(Guid.NewGuid().ToString()) { }

    // Constructor with explicit cart id
    public Cart(string cartId)
    {
        _CartId = cartId ?? Guid.NewGuid().ToString();
        _Items = new Dictionary<string, double>(StringComparer.OrdinalIgnoreCase);
        _items = Array.Empty<CartItem>();
    }

    // Adds an item to the cart. If the item already exists, its price will be updated.
    public void AddItem(string name, double price)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Item name is required", nameof(name));

        _Items[name] = price;

        // Add to the array by creating a new array one element larger
        var newArr = new CartItem[_items.Length + 1];
        Array.Copy(_items, newArr, _items.Length);
        newArr[newArr.Length - 1] = new CartItem(name, price);
        _items = newArr;
    }

    // Removes an item by name. Returns true if removed, false if not found.
    public bool RemoveItem(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return false;

        var removed = _Items.Remove(name);
        if (!removed)
            return false;

        // Rebuild the array excluding the removed item (case-insensitive match)
        var list = new List<CartItem>(_items.Length);
        foreach (var it in _items)
        {
            if (!string.Equals(it.Name, name, StringComparison.OrdinalIgnoreCase))
                list.Add(it);
        }

        _items = list.ToArray();
        return true;
    }

    // Returns the total cost of items in the cart
    public double GetTotal()
    {
        double total = 0;
        foreach (var kv in _Items)
            total += kv.Value;
        return total;
    }

    public override string ToString()
    {
        return $"CartId: {_CartId}, Items: {_Items.Count}, Total: {GetTotal():C}";
    }
}

// Simple program demonstrating usage
public static class Program
{
    public static void Main()
    {
        var cart = new Cart("CART-1001");
        cart.AddItem("Lollypop", 2.5);
        cart.AddItem("Chocolate", 3.75);
        cart.AddItem("Soda", 1.5);

        Console.WriteLine(cart);
        foreach (var it in cart.ItemsArray)
            Console.WriteLine(it);

        Console.WriteLine($"Total: {cart.GetTotal():C}");

        cart.RemoveItem("Soda");
        Console.WriteLine("After removing Soda:");
        Console.WriteLine(cart);
    }
}

