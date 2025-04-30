using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp23
{
    public partial class User
    {
        public int UserId { get; set; }

        public string UserSurname { get; set; } = null!;

        public string UserName { get; set; } = null!;

        public string? UserPatronymic { get; set; }

        public string? UserLogin { get; set; }

        public string UserPassword { get; set; } = null!;

        public int UserRole { get; set; }
    }
}
