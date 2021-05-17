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
            Assert.AreEqual("499b06c6d39b4c1fe9305962a4cb858be2a172b3c51dbea02836f1235a0e4906", chain.Blocks[0].Hash);
        }

        [TestMethod]
        public void VerifyGenesisCount()
        {
            var chain = new Core.Blockchain();
            Assert.AreEqual(1, chain.Blocks.Count);
        }
    }
}
