using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blockchain.Core
{
    public class TransactionOutput 
    {
        public Address Address { get; set; }
        public long Amount { get; set; }
    }
}
