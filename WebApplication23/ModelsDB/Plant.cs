using System;
using System.Collections.Generic;

namespace WebApplication23.ModelsDB;

public partial class Plant
{
    public int Код { get; set; }

    public string Название { get; set; } = null!;

    public string Семейство { get; set; } = null!;

    public string? Раздел { get; set; }

    public virtual ICollection<PlantsInCountry> PlantsInCountries { get; set; } = new List<PlantsInCountry>();
}
