using System;
using System.Collections.Generic;

namespace Delta.Data;

public partial class Contact
{
    public int Id { get; set; }

    public string HeaderNumber { get; set; } = null!;

    public string NumberOne { get; set; } = null!;

    public string NumberTwo { get; set; } = null!;

    public string HeaderTimetable { get; set; } = null!;

    public string Monday { get; set; } = null!;

    public string Friday { get; set; } = null!;

    public string Saturday { get; set; } = null!;

    public string ImgBg { get; set; } = null!;

    public string Address { get; set; } = null!;
}
