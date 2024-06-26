﻿using System.ComponentModel.DataAnnotations;

namespace BoutiqueSoap.Models;

public class Soap
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Scent { get; set; }
    public string? Weight { get; set; }
    public string? Price { get; set; }
    public string? Description { get; set; }
}