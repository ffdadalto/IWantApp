﻿namespace IWantApp.Domain.Products;

public class Category : Entity
{
    public int CategoryId { get; set; }
    public bool Active { get; set; } = true;
}