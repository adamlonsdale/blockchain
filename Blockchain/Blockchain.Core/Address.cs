using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blockchain.Core
{
    public class Address : IEquatable<Address>
    {
        private readonly Random random;
        private byte[] bytes;

        public Address()
        {
            this.random = new Random();
            this.bytes = new byte[20];
            random.NextBytes(this.bytes);
        }

        public Address(byte[] bytes)
        {
            this.bytes = bytes;
        }

        public byte[] Bytes { get { return this.bytes; } }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (this == obj)
                return true;

            if (!(obj is Address))
                return false;

            Address h = (Address)obj;

            return this.bytes.SequenceEqual(h.bytes);
        }

        public override int GetHashCode()
        {
            int value = 0;

            for (int k = 0; k < this.bytes.Length; k++)
            {
                value += this.bytes[k];
                value <<= 1;
            }

            return value;
        }

        public override string ToString()
        {
            return Utils.ByteArrayToString(this.bytes);
        }

        public static Address Parse(string address)
        {
            return new Address(Utils.StringToByteArray(address));
        }

        public bool Equals(Address other)
        {
            return bytes.SequenceEqual(other.Bytes);
        }
    }
}
