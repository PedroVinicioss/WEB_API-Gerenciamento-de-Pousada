﻿namespace GerenciadorHotel.Application.Models.InputModels;

public class CreateProductInputModel
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Category { get; set; }
    public bool IsAvailable { get; set; }
}