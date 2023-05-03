using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    public class NoUserConnected : Exception
    {
        public NoUserConnected() : base("No user logged in") { }
    }
}
