﻿using Delta.Data;

namespace Delta.Models.Dtos;

public class ReagentDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? KitComposition { get; set; } = null;
    public string InstructionPdf { get; set; } = string.Empty;
    public int CompanyId { get; set; }
    public string CompanyName { get; set; } = null!;
    public int[] ReagentCategoryIds { get; set; } = null!;
    public string[] ReagentCategoryNames { get; set; } = null!;
    public IEnumerable<ReagentCategoryDto> ReagentCategories { get; set; } = null!;
}