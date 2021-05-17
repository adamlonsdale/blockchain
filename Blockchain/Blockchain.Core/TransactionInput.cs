using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Blockchain.Core
{
    public class TransactionInput
    {
        public Address Address { get; set; }
        public long Amount { get; set; }
    }
}
