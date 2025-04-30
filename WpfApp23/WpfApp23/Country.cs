using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp23
{
    public partial class Country
    {
        public int Код { get; set; }

        public string Название { get; set; } = null!;

        public string Материк { get; set; } = null!;

        public string? Столица { get; set; }

        public virtual ICollection<PlantsInCountry> PlantsInCountries { get; set; } = new List<PlantsInCountry>();
    }
}
