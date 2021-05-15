using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blockchain.Tests
{
    [TestClass]
    public class BlockchainTests
    {
        [TestMethod]
        public void VerifyGenesisHash()
        {
            var chain = new Core.Blockchain();
            Assert.AreEqual("4d2805c1fdb619380e1a59728a6974d31b8d7f4957034d71f9d874475607972b", chain.LatestBlock.Hash);
        }

        [TestMethod]
        public void VerifyGenesisCount()
        {
            var chain = new Core.Blockchain();
            Assert.AreEqual(1, chain.Blocks.Count);
        }
    }
}
