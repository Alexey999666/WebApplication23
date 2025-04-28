using System;
using System.Collections.Generic;

namespace WebApplication23.ModelsDB;

public partial class PlantsInCountry
{
    public int Страна { get; set; }

    public int Растение { get; set; }

    public int КолвоКорней { get; set; }

    public virtual Plant РастениеNavigation { get; set; } = null!;

    public virtual Country СтранаNavigation { get; set; } = null!;
}
