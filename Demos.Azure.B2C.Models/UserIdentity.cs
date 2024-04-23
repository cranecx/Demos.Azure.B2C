using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demos.Azure.B2C.Models
{
    public class UserIdentity
    {
        public SignInType SignInType { get; set; }
        public string? Value { get; set; }
    }
}
