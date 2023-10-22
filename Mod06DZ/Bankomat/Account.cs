using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bankomat
{
    public class Account
    {
        public string Password { get; set; }
        public string AccountNumber { get; set; }
        public double Balance { get; set; }
        
    }
}
