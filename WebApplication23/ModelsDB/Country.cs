using System;
using System.Collections.Generic;

namespace WebApplication23.ModelsDB;

public partial class Country
{
    public int Код { get; set; }

    public string Название { get; set; } = null!;

    public string Материк { get; set; } = null!;

    public string? Столица { get; set; }

    public virtual ICollection<PlantsInCountry> PlantsInCountries { get; set; } = new List<PlantsInCountry>();
}
