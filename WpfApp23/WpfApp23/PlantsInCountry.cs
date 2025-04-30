using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp23
{
    public partial class PlantsInCountry
    {
        public int Страна { get; set; }

        public int Растение { get; set; }

        public int КолвоКорней { get; set; }

        public virtual Plant РастениеNavigation { get; set; } = null!;

        public virtual Country СтранаNavigation { get; set; } = null!;
    }
}
