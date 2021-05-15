using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Blockchain.Core
{
    public class Hash
    {
        private readonly byte[] _bytes;

        public Hash()
        {
            var random = new Random(DateTime.Now.Millisecond);
            _bytes = new byte[20];
            random.NextBytes(_bytes);
        }

        public Hash(byte[] bytes)
        {
            _bytes = bytes;
        }

        public byte[] Bytes => _bytes;

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (this == obj)
                return true;

            if (!(obj is Hash))
                return false;

            Hash hash = (Hash)obj;

            return Bytes.SequenceEqual(hash.Bytes);
        }

        public override int GetHashCode()
        {
            int value = 0;

            for (int i = 0; i < _bytes.Length; i++)
            {
                value += _bytes[i];
                value <<= 1;
            }

            return value;
        }
    }
}
