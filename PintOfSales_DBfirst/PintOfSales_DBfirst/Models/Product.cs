using System;
using System.Collections.Generic;

namespace PintOfSales_DBfirst.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string Name { get; set; }

    public string? Description { get; set; }

    public double Price { get; set; }

    public int CategoryId { get; set; }

    public virtual Category? Category { get; set; }
}
