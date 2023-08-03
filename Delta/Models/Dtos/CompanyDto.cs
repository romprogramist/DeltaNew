﻿namespace Delta.Models.Dtos;

public class CompanyDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Logo { get; set; } = null!;
}